using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class registrationController : Controller
    {
        private SchoolEntities db = new SchoolEntities();

        // GET: registration
        public ActionResult Index()
        {
            var registrations = db.registrations.Include(r => r.Assessment).Include(r => r.Course).Include(r => r.Student);
            return View(registrations.ToList());
        }

        // GET: registration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registration registration = db.registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // GET: registration/Create
        public ActionResult Create()
        {
            ViewBag.Assessment_Id = new SelectList(db.Assessments, "Assessment_Id", "ICAM");
            ViewBag.Course_ID = new SelectList(db.Courses, "Id", "Course_Code");
            ViewBag.Student_ID = new SelectList(db.Students, "Student_ID", "First_Name");
            return View();
        }

        // POST: registration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,First_Name,Last_Name,CNIC,Course_ID,Student_ID,Assessment_Id,telNo")] registration registration)
        {
            if (ModelState.IsValid)
            {
                db.registrations.Add(registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Assessment_Id = new SelectList(db.Assessments, "Assessment_Id", "ICAM", registration.Assessment_Id);
            ViewBag.Course_ID = new SelectList(db.Courses, "Id", "Course_Code", registration.Course_ID);
            ViewBag.Student_ID = new SelectList(db.Students, "Student_ID", "First_Name", registration.Student_ID);
            return View(registration);
        }

        // GET: registration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registration registration = db.registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.Assessment_Id = new SelectList(db.Assessments, "Assessment_Id", "ICAM", registration.Assessment_Id);
            ViewBag.Course_ID = new SelectList(db.Courses, "Id", "Course_Code", registration.Course_ID);
            ViewBag.Student_ID = new SelectList(db.Students, "Student_ID", "First_Name", registration.Student_ID);
            return View(registration);
        }

        // POST: registration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,First_Name,Last_Name,CNIC,Course_ID,Student_ID,Assessment_Id,telNo")] registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Assessment_Id = new SelectList(db.Assessments, "Assessment_Id", "ICAM", registration.Assessment_Id);
            ViewBag.Course_ID = new SelectList(db.Courses, "Id", "Course_Code", registration.Course_ID);
            ViewBag.Student_ID = new SelectList(db.Students, "Student_ID", "First_Name", registration.Student_ID);
            return View(registration);
        }

        // GET: registration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registration registration = db.registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // POST: registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            registration registration = db.registrations.Find(id);
            db.registrations.Remove(registration);
            db.SaveChanges();
            return RedirectToAction("Index");
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
