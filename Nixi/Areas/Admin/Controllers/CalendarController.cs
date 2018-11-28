using Nixi.DAL;
using Nixi.Models;
using Nixi.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Web.UI;

namespace Nixi.Areas.Admin.Controllers
{
    public class CalendarController : Controller
    {
        private NixiContext db = new NixiContext();

        // GET: Admin/Calendar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialToddlerCalendar(Guid id, int? year)
        {
            if(year == null)
            {
                year = DateTime.Now.Year;
            }
            List<AgreedDay> days = db.AgreedDays.Where(ad => ad.ToddlerId == id && ad.Date.Year == year).ToList();
            return PartialView("_ToddlerCalendar", days);
        }
        public ActionResult PartialToddlerMonthCalendar(Guid id, int? month, int? year)
        {
            DateTime start = new DateTime();
            if(month == null || year == null)
            {
                start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            }
            else
            {
                start = new DateTime((int)year, (int)month, 1);
            }
            List<AgreedDay> days = db.AgreedDays.Where(ad => ad.ToddlerId == id && ad.Date.Year == start.Year && ad.Date.Month == start.Month).ToList();
            ViewBag.year = start.Year;
            ViewBag.month = start.Month;
            ViewBag.currentperiod = new DateTime(start.Year, start.Month, 1);
            return PartialView("_ToddlerMonthCalendar", days);
        }

        public ActionResult ToddlerCalendar(Guid id, DateTime period)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toddler t = db.Toddlers.Find(id);
            if (t == null)
            {
                return HttpNotFound();
            }
            ToddlerCalendarViewModel tcvm = new ToddlerCalendarViewModel();
            tcvm.Toddler = t;
            tcvm.AgreedPeriods = db.AgreedPeriods.Where(ap => ap.ToddlerId == t.Id).ToList();

            tcvm.AgreedDays = db.AgreedDays.Where(ad => ad.ToddlerId == id && ad.Date.Year == period.Year && ad.Date.Month == period.Month).ToList();
            tcvm.Period = period;



            return View(tcvm);
        }

        public ActionResult HeadcountMonthCalendar(DateTime period)
        {
            ViewBag.period = period;
            List<HeadcountByDay> hbd = db.AgreedDays
                                        .Where((x => x.Date.Month == period.Month && x.Date.Year == period.Year && (x.DayType == DayType.AM || x.DayType == DayType.FullDay)))
                                        .GroupBy(x => x.Date)
                                        .Select(x => new HeadcountByDay { AM_Count = x.Count(), Date = (DateTime)x.Key }).ToList();
            return View(hbd);
        }
        [HttpGet]
        public ActionResult Headcount_MonthCalendar(Guid? classId, DateTime period)
        {
            if(period == null)
            {
                period = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            }

            ViewBag.period = period;

            HeadCountMonthCalendarViewModel hcmcvm = new HeadCountMonthCalendarViewModel();
            hcmcvm.AllClasses = db.Classes.ToList();

            if(classId == null)
            {
                hcmcvm.TheClass = hcmcvm.AllClasses.First();
            }
            else
            {
                hcmcvm.TheClass = db.Classes.Find(classId);
            }
            DateTime firstday = new DateTime(period.Year, period.Month, 1);
            DateTime startofCalendar = firstday;
            switch (firstday.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    startofCalendar = firstday;
                    break;
                case DayOfWeek.Tuesday:
                    startofCalendar = firstday.AddDays(-1); ;
                    break;
                case DayOfWeek.Wednesday:
                    startofCalendar = firstday.AddDays(-2); ;
                    break;
                case DayOfWeek.Thursday:
                    startofCalendar = firstday.AddDays(-3); ;
                    break;
                case DayOfWeek.Friday:
                    startofCalendar = firstday.AddDays(-4); ;
                    break;
                case DayOfWeek.Saturday:
                    startofCalendar = firstday.AddDays(-5); ;
                    break;
                case DayOfWeek.Sunday:
                    startofCalendar = firstday.AddDays(-6); ;
                    break;
            }
            DateTime endofCalendar = startofCalendar.AddDays(41);
            
            List<HeadcountByDay> hbd_AM = db.AgreedDays
                                        .Where(x => (x.Date >= startofCalendar && x.Date <= endofCalendar) && (x.DayType == DayType.AM || x.DayType == DayType.FullDay) && x.ClassId == hcmcvm.TheClass.Id)
                                        .GroupBy(x => x.Date)
                                        .Select(x => new HeadcountByDay { AM_Count = x.Count(), Date = (DateTime)x.Key }).ToList();
            List<HeadcountByDay> hbd_PM = db.AgreedDays
                                        .Where(x => (x.Date >= startofCalendar && x.Date <= endofCalendar) && (x.DayType == DayType.PM || x.DayType == DayType.FullDay) && x.ClassId == hcmcvm.TheClass.Id)
                                        .GroupBy(x => x.Date)
                                        .Select(x => new HeadcountByDay { PM_Count = x.Count(), Date = (DateTime)x.Key }).ToList();
            List<HeadcountByDay> hbd_joined = new List<HeadcountByDay>();
            for(DateTime d = startofCalendar; d<= endofCalendar; d = d.AddDays(1))
            {
                HeadcountByDay hbdn = new HeadcountByDay();
                hbdn.Date = d;
                if(hbd_AM.Exists(x => x.Date == d))
                {
                    hbdn.AM_Count = hbd_AM.Where(x => x.Date == d).First().AM_Count;
                }
                else
                {
                    hbdn.AM_Count = 0;
                }
                if (hbd_PM.Exists(x => x.Date == d))
                {
                    hbdn.PM_Count = hbd_PM.Where(x => x.Date == d).First().PM_Count;
                }
                else
                {
                    hbdn.PM_Count = 0;
                }
                hbd_joined.Add(hbdn);
            }


            hcmcvm.HeadCountByDay = hbd_joined;
            
            return View(hcmcvm);
        }

        [HttpPost]
        public ActionResult Headcount_MonthCalendar(FormCollection form)
        {
            string theclass = Convert.ToString(form["selecteer"]);
            string period = Convert.ToString(form["period"]);
            Guid theclassid = Guid.Parse(theclass);
            DateTime theperiod = DateTime.Parse(period);

            ViewBag.period = theperiod;
            HeadCountMonthCalendarViewModel hcmcvm = new HeadCountMonthCalendarViewModel();
            hcmcvm.AllClasses = db.Classes.ToList();
            hcmcvm.TheClass = db.Classes.Find(theclass);

            DateTime firstday = new DateTime(theperiod.Year, theperiod.Month, 1);
            DateTime startofCalendar = firstday;
            switch (firstday.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    startofCalendar = firstday;
                    break;
                case DayOfWeek.Tuesday:
                    startofCalendar = firstday.AddDays(-1); ;
                    break;
                case DayOfWeek.Wednesday:
                    startofCalendar = firstday.AddDays(-2); ;
                    break;
                case DayOfWeek.Thursday:
                    startofCalendar = firstday.AddDays(-3); ;
                    break;
                case DayOfWeek.Friday:
                    startofCalendar = firstday.AddDays(-4); ;
                    break;
                case DayOfWeek.Saturday:
                    startofCalendar = firstday.AddDays(-5); ;
                    break;
                case DayOfWeek.Sunday:
                    startofCalendar = firstday.AddDays(-6); ;
                    break;
            }
            DateTime endofCalendar = startofCalendar.AddDays(42);


            List<HeadcountByDay> hbd_AM = db.AgreedDays
                                        .Where(x => (x.Date >= startofCalendar && x.Date <= endofCalendar) && (x.DayType == DayType.AM || x.DayType == DayType.FullDay) && x.ClassId == hcmcvm.TheClass.Id)
                                        .GroupBy(x => x.Date)
                                        .Select(x => new HeadcountByDay { AM_Count = x.Count(), Date = (DateTime)x.Key }).ToList();
            List<HeadcountByDay> hbd_PM = db.AgreedDays
                                        .Where(x => (x.Date >= startofCalendar && x.Date <= endofCalendar) && (x.DayType == DayType.PM || x.DayType == DayType.FullDay) && x.ClassId == hcmcvm.TheClass.Id)
                                        .GroupBy(x => x.Date)
                                        .Select(x => new HeadcountByDay { PM_Count = x.Count(), Date = (DateTime)x.Key }).ToList();

            hcmcvm.HeadCountByDay = hbd_AM;
            hcmcvm.HeadCountByDay.AddRange(hbd_PM);

            return View(hcmcvm);
        }

        public ActionResult Test_Headcount(DateTime period)
        {
            ViewBag.period = period;



            return View();
        }


    }
}