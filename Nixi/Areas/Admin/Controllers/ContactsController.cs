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
    public class ContactsController : Controller
    {
        private NixiContext db = new NixiContext();
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddParent()
        {
            return RedirectToAction("Index");
        }
        public ActionResult CreateParent()
        {
            return RedirectToAction("Index");
        }

        public ActionResult ToddlerIndex()
        {
            var toddlers = db.Toddlers;
            return View(toddlers.ToList());
        }
        public ActionResult PersonIndex()
        {
            var people = db.People;
            return View(people.ToList());
        }

        // GET: Contact Toddler First Step
        public ActionResult CreateToddlerShortInfo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateToddlerShortInfo([Bind(Include = "FirstName, LastName, Gender, DayOfBirth")]Toddler toddler)
        {
            Guid id = Guid.NewGuid();
            toddler.Id = id;
            db.Toddlers.Add(toddler);
            db.SaveChanges();

            return RedirectToAction("ToddlerDetails", new { id = id });
        }
        // GET: Contact/Details/5
        public ActionResult ToddlerDetails(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toddler toddler = GetToddler(id);
            if (toddler == null)
            {
                return HttpNotFound();
            }
            return View(toddler);
        }
        [HttpPost]
        public ActionResult ToddlerDetails([Bind(Include = "Id, FirstName, LastName, Gender, DayOfBirth, GuaranteePrice")]Toddler toddler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toddler).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("ToddlerDetails", toddler.Id);
        }
        // GET: Contact/Details/5
        public ActionResult PersonDetails(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = GetPerson(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }
        [HttpPost]
        public ActionResult PersonDetails([Bind(Include = "Id, FirstName, LastName, Gender")]Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("PersonDetails", person.Id);
        }

        [HttpGet]
        public ActionResult ShowParentList(Guid? subjectid)
        {
            AddParentViewModel apvm = new AddParentViewModel();
            apvm.SubjectId = subjectid.Value;
            apvm.People = db.People.ToList();
            return PartialView("_AddParent", apvm);
        }
        public ActionResult ShowToddlerList(Guid? subjectid)
        {
            AddToddlerViewModel asvm = new AddToddlerViewModel();
            asvm.SubjectId = subjectid.Value;
            asvm.Toddlers = db.Toddlers.ToList();
            return PartialView("_AddToddler", asvm);
        }
        
        public ActionResult AddAssociation(Guid subject, Guid add)
        {
            Boolean siblings = true;
            Toddler toddler = GetToddler(subject);
            Toddler sibling = GetToddler(add);
            Person parent;
            ContactAssociation ca = new ContactAssociation();
            if (toddler == null)
            {
                siblings = false;
                parent = GetPerson(subject);
                ca.Contact1Id = sibling.Id;
                ca.Contact2Id = parent.Id;
                ca.Association = Association.Parent;
                db.ContactAssociations.Add(ca);
                db.SaveChanges();
                return RedirectToAction("PersonDetails", new { id = subject });
            }
            if(sibling == null)
            {
                siblings = false;
                parent = GetPerson(add);
                ca.Contact1Id = toddler.Id;
                ca.Contact2Id = parent.Id;
                ca.Association = Association.Parent;
                db.ContactAssociations.Add(ca);
                db.SaveChanges();
                return RedirectToAction("ToddlerDetails", new { id = subject });
            }
            if (siblings)
            {
                ca.Contact1Id = toddler.Id;
                ca.Contact2Id = sibling.Id;
                ca.Association = Association.Sibling;
                db.ContactAssociations.Add(ca);
                db.SaveChanges();
                return RedirectToAction("ToddlerDetails", new { id = subject });
            }
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult CreateParentFromToddler(Guid? subjectid)
        {
            ViewBag.subjectid = subjectid;

            return PartialView("_CreateParent");
        }
        [HttpPost]
        public ActionResult CreateParentFromToddler(CreateParentViewModel cpvm)
        {
            Person parent = new Person();
            parent.Id = Guid.NewGuid();
            parent.FirstName = cpvm.FirstName;
            parent.LastName = cpvm.LastName;
            parent.Gender = cpvm.Gender;
            db.People.Add(parent);


            Toddler toddler = GetToddler(cpvm.SubjectId);
            if (toddler == null)
            {
                db.SaveChanges();
                return RedirectToAction("PersonIndex");
            }
            

            ContactAssociation ca = NewContactAssociation(toddler.Id, parent.Id, Association.Parent);

            db.ContactAssociations.Add(ca);
            db.SaveChanges();
            return RedirectToAction("ToddlerDetails", new { id = toddler.Id });
        }
        
        public ActionResult DeleteFromAssociation(Guid subject, Guid delete)
        {
            ContactAssociation thisAssociation = FindContactAssociation(subject, delete);
            if(thisAssociation != null)
            {
                db.ContactAssociations.Remove(thisAssociation);
                db.SaveChanges();
            }
            if(GetToddler(subject) == null)
            {
                return RedirectToAction("PersonDetails", new { id = subject });
            }

            return RedirectToAction("ToddlerDetails", new { id = subject });
        }
        [HttpGet]
        public ActionResult Delete(Guid? subjectid, bool? saveChangesError = false)
        {
            if (subjectid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            DeleteSubjectViewModel dsvm = new DeleteSubjectViewModel();
            Toddler t = db.Toddlers.Find(subjectid);
            if (t != null)
            {
                
                dsvm.id = t.Id;
                dsvm.Line1 = t.FirstName;
                dsvm.Line2 = t.LastName;
                dsvm.Line3 = t.DayOfBirth.ToShortDateString();
                return PartialView("_Delete", dsvm);
            }
            else
            {
                Person p = db.People.Find(subjectid);
                dsvm.id = p.Id;
                dsvm.Line1 = p.FirstName;
                dsvm.Line2 = p.LastName;
                return PartialView("_Delete", dsvm);
            }
        }
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            try
            {
                Toddler t = db.Toddlers.Find(id);
                if (t != null)
                {
                    List<ContactAssociation> tcas = GetContactAssociations(id);
                    foreach (ContactAssociation ca in tcas)
                    {
                        db.ContactAssociations.Remove(ca);
                    }
                    db.Toddlers.Remove(t);
                    db.SaveChanges();
                    return RedirectToAction("ToddlerIndex");
                }
                else
                {
                    Person p = db.People.Find(id);
                    
                    List<ContactAssociation> pcas = GetContactAssociations(id);
                    foreach (ContactAssociation ca in pcas)
                    {
                        db.ContactAssociations.Remove(ca);
                    }
                    db.People.Remove(p);
                    db.SaveChanges();
                }
            }
            catch (DataException dex )
            {
                Console.WriteLine(dex);
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { subjectid = id, saveChangesError = true });
            }
            return RedirectToAction("PersonIndex");
        }

        private Toddler GetToddler(Guid? id)
        {
            Toddler t = db.Toddlers.Find(id);
            if (t == null)
            {
                return null;
            }

            t.AgreedPeriods = db.AgreedPeriods.Where(ap => ap.ToddlerId == id).ToList();

            List<ContactAssociation> Associations = GetContactAssociations(t.Id);
            foreach (ContactAssociation ca in Associations)
            {
                switch (ca.Association)
                {
                    case Association.Parent:
                        if (ca.Contact1Id == id) t.Parents.Add(db.People.Find(ca.Contact2Id));
                        else t.Parents.Add(db.People.Find(ca.Contact1Id));
                        break;
                    case Association.Pickup:
                        if (ca.Contact1Id == id) t.Pickups.Add(db.People.Find(ca.Contact2Id));
                        else t.Pickups.Add(db.People.Find(ca.Contact1Id));
                        break;
                    case Association.Sibling:
                        if (ca.Contact1Id == id) t.Siblings.Add(db.Toddlers.Find(ca.Contact2Id));
                        else t.Siblings.Add(db.Toddlers.Find(ca.Contact1Id));
                        break;
                }
            }
            return t;
        }
        private Person GetPerson(Guid? id)
        {
            Person p = db.People.Find(id);
            if (p == null)
            {
                return null;
            }
            List<ContactAssociation> Associations = db.ContactAssociations
                                        .Where(a => a.Contact1Id == id || a.Contact2Id == id)
                                        .ToList();
            foreach (ContactAssociation ca in Associations)
            {
                switch (ca.Association)
                {
                    case Association.Parent:
                        if (ca.Contact2Id == id) p.Children.Add(db.Toddlers.Find(ca.Contact1Id));
                        else p.Children.Add(db.Toddlers.Find(ca.Contact2Id));
                        break;
                    case Association.Pickup:
                        break;
                    case Association.Sibling:
                        break;
                }
            }

            return p;
        }
        private ContactAssociation NewContactAssociation(Guid subject, Guid create, Association a)
        {
            ContactAssociation ca = new ContactAssociation() { Contact1Id = subject, Contact2Id = create, Association = a };
            return ca;
        }
        private ContactAssociation FindContactAssociation(Guid subject, Guid delete)
        {
            ContactAssociation foundca = db.ContactAssociations
                                                    .Where(ca => (ca.Contact1Id == subject && ca.Contact2Id == delete) || (ca.Contact2Id == subject && ca.Contact1Id == delete))
                                                    .FirstOrDefault();
            if(foundca == null)
            {
                return null;
            }
            return foundca;
        }
        private List<ContactAssociation> GetContactAssociations(Guid subject)
        {
            List<ContactAssociation> foundcas = db.ContactAssociations
                                                    .Where(ca => (ca.Contact1Id == subject) || (ca.Contact2Id == subject))
                                                    .ToList();
            return foundcas;
        }
    }
}
