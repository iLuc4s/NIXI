using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nixi.Areas.Admin.Models;
using Nixi.DAL;
using Nixi.Models;

namespace Nixi.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private NixiContext db = new NixiContext();

        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Groups()
        {
            return View();
        }

        // GET: Admin/Admin/Details/5
        public ActionResult SettingsDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Settings settings = db.Settings.Find(1);
            if (settings == null)
            {
                return HttpNotFound();
            }
            return View(settings);
        }

        // GET: Admin/Admin/Edit/5
        public ActionResult SettingsEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Settings settings = db.Settings.Find(1);
            if (settings == null)
            {
                return HttpNotFound();
            }
            return View(settings);
        }

        // POST: Admin/Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SettingsEdit([Bind(Include = "Id,CompanyName,Locations,Classes,WeWorkWithHalfDays,PayWhenIllness,WeBuyDiapers,SecondChildDiscount,SiblingNoGuarantee,PriceToPaycheck,DayPrice,HalfDayPrice,DiaperPrice,SecondChildDiscountPrice,PriceToPayCheckFactor")] Settings settings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(settings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(settings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
