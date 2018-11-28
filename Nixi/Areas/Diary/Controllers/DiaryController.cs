using Nixi.Areas.Admin.Models;
using Nixi.Areas.Diary.Models;
using Nixi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nixi.Areas.Diary.Controllers
{
    public class DiaryController : Controller
    {
        private NixiContext db = new NixiContext();

        // GET: Diary
        public ActionResult Index()
        {
            List<Class> classes = db.Classes.ToList();
            return View(classes);
        }
        // GET: Diary/Diary/Diary
        public ActionResult Diary(Guid? c, DateTime date)
        {
            ViewBag.Class = c;
            List<AgreedDay> ads = db.AgreedDays.Where(d => (d.Date.Day == date.Day && d.Date.Month == date.Month && d.Date.Year == date.Year) && d.ClassId == c).ToList();
            List<ToddlerCard> tcs = new List<ToddlerCard>();
            foreach (AgreedDay ad in ads)
            {
                Toddler t = db.Toddlers.Find(ad.ToddlerId);
                if (t != null)
                {
                    DiaryEntry de = db.DiaryEntries.Where(en => (en.Date.Day == date.Day && en.Date.Month == date.Month && en.Date.Year == date.Year) && en.ToddlerId == t.Id && en.Status != DiaryEntryStatus.Other && en.Status != DiaryEntryStatus.VideoMessage).OrderByDescending(en => en.Date).FirstOrDefault();
                    ToddlerCard tc;
                    if (de != null)
                    {
                        tc = new ToddlerCard { Name = t.FirstName, ToddlerId = t.Id, Status = de.Status };
                    }
                    else
                    {
                        tc = new ToddlerCard { Name = t.FirstName, ToddlerId = t.Id, Status = DiaryEntryStatus.NotArrived };
                    }
                    tcs.Add(tc);
                }
            }
            return View(tcs);
        }

        // POST: Diary/Diary/DiaryEntry
        [HttpPost]
        public ActionResult DiaryEntry(string submitButton, FormCollection col, string commentInput, string c, string thetime)
        {
            try
            {
                DateTime time = DateTime.Parse(thetime);
                Guid cls = Guid.Parse(c);
                string comment = "";
                if (commentInput != null) comment = commentInput;
                
                List<Toddler> ts = new List<Toddler>();
                foreach (var tc in col)
                {
                    try
                    {
                        Guid toddlerid = Guid.Parse((string)tc);
                        Toddler t = db.Toddlers.Where(to => to.Id == toddlerid).FirstOrDefault();
                        if (t != null)
                        {
                            ts.Add(t);
                        }
                    }
                    catch
                    {

                    }
                }

                DiaryEntryStatus des = DiaryEntryStatus.NotArrived;
                
                foreach(Toddler t in ts)
                {
                    Boolean diaryEntryOK = false;
                    DiaryEntry lastknownDE = db.DiaryEntries.Where(en => (en.Date.Day == DateTime.Now.Day && en.Date.Month == DateTime.Now.Month && en.Date.Year == DateTime.Now.Year) && en.ToddlerId == t.Id && en.Status != DiaryEntryStatus.Other && en.Status != DiaryEntryStatus.VideoMessage).OrderByDescending(en => en.Date).FirstOrDefault();
                    if(lastknownDE == null)
                    {
                        lastknownDE = new DiaryEntry { ToddlerId = t.Id, Date = DateTime.Now, Id = Guid.NewGuid(), Status = DiaryEntryStatus.NotArrived };
                    }
                    switch (submitButton)
                    {
                        case "ToddlerArrived":
                            if(lastknownDE.Status == DiaryEntryStatus.NotArrived || lastknownDE.Status == DiaryEntryStatus.Exit)
                            {
                                des = DiaryEntryStatus.Entry;
                                diaryEntryOK = true;
                            }
                            break;
                        case "ToddlerSleeping":
                            if (lastknownDE.Status != DiaryEntryStatus.NotArrived && 
                                lastknownDE.Status != DiaryEntryStatus.Exit && 
                                lastknownDE.Status != DiaryEntryStatus.Sleeping)
                            {
                                des = DiaryEntryStatus.Sleeping;
                                diaryEntryOK = true;
                            }
                            else if(lastknownDE.Status == DiaryEntryStatus.Sleeping)
                            {
                                des = DiaryEntryStatus.Awake;
                                diaryEntryOK = true;
                            }
                            break;
                        case "ToddlerEating":
                            if (lastknownDE.Status != DiaryEntryStatus.NotArrived &&
                                lastknownDE.Status != DiaryEntryStatus.Exit &&
                                lastknownDE.Status != DiaryEntryStatus.Sleeping)
                            {
                                des = DiaryEntryStatus.Eating;
                                diaryEntryOK = true;
                            }
                                
                            break;
                        case "ToddlerComment":
                            des = DiaryEntryStatus.Other;
                            diaryEntryOK = true;
                            break;
                        case "ToddlerDiaper":
                            if (lastknownDE.Status != DiaryEntryStatus.NotArrived &&
                                lastknownDE.Status != DiaryEntryStatus.Exit &&
                                lastknownDE.Status != DiaryEntryStatus.Sleeping)
                            {
                                des = DiaryEntryStatus.Diaper;
                                diaryEntryOK = true;
                            }
                                
                            break;
                        case "ToddlerExit":
                            if (lastknownDE.Status != DiaryEntryStatus.Exit &&
                                lastknownDE.Status != DiaryEntryStatus.Sleeping)
                            {
                                des = DiaryEntryStatus.Exit;
                                diaryEntryOK = true;
                            }
                                
                            break;
                        default:
                            break;
                    }



                    DiaryEntry de = new DiaryEntry { Id = Guid.NewGuid(), ToddlerId = t.Id, Date = time, Status = des, Comment = comment };
                    if(diaryEntryOK) db.DiaryEntries.Add(de);
                }
                db.SaveChanges();
                
                return RedirectToAction("Diary", new { c = cls, Date = DateTime.Now });
            }
            catch
            {

                Guid cls = Guid.Parse(c);
                return RedirectToAction("Diary", new { c = cls, Date = DateTime.Now });
            }
        }

        [HttpGet]
        public ActionResult ToddlerInfo(Guid? subjectid)
        {
            ToddlerInfoViewModel tivm = new ToddlerInfoViewModel();
            
            Toddler t = db.Toddlers.Find(subjectid);
            if (t != null)
            {
                tivm.Id = t.Id;
                tivm.FirstName = t.FirstName;
                tivm.LastName = t.LastName;
                tivm.BirthDate = t.DayOfBirth;
                foreach(Person p in t.Parents)
                {
                    tivm.Parents.Add(p.FirstName + " " + p.LastName);
                }
                foreach (Toddler s in t.Siblings)
                {
                    tivm.Siblings.Add(s.FirstName + " " + s.LastName);
                }
            }
            else
            {
                return PartialView("_ToddlerInfo");
            }

            return PartialView("_ToddlerInfo", tivm);
        }

        public ActionResult ShowToddlerEntries(Guid? subjectid)
        {
            List<DiaryEntry> des = db.DiaryEntries.Where(d => (d.Date.Day == DateTime.Now.Day && d.Date.Month == DateTime.Now.Month && d.Date.Year == DateTime.Now.Year) && d.ToddlerId == subjectid).OrderBy(d => d.Date).ToList();
            return PartialView("_ToddlerEntries", des);
        }




        // GET: Diary/Diary/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Diary/Diary/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Diary/Diary/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Diary/Diary/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Diary/Diary/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Diary/Diary/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Diary/Diary/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
