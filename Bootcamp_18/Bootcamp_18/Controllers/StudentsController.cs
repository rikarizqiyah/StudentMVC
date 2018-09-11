using Bootcamp_18.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bootcamp_18.Controllers
{
    public class StudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Student
        public async Task<ActionResult> Index()
        {
            var students = db.Students.Include(m => m.Majors).Include(n => n.Villages);
            return View(await db.Students.ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.MajorId = new SelectList(db.Majors, "Id", "Name");
            ViewBag.VillageId = new SelectList(db.Villages, "Id", "Name");
            List<SelectListItem> gender = new List<SelectListItem>();
            gender.Add(new SelectListItem { Text = "Male", Value = true.ToString() });
            gender.Add(new SelectListItem { Text = "Female", Value = false.ToString() });
            ViewBag.Gender = new SelectList(gender, "Value", "Text", "Male");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Gender,PostalCode,Street,FinalScore,MajorId,VillageId,CreateDate,UpdateDate,DeleteDate,IsDelete")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MajorId = new SelectList(db.Majors, "Id", "Name");
            ViewBag.VillageId = new SelectList(db.Villages, "Id", "Name");
            List<SelectListItem> gender = new List<SelectListItem>();
            gender.Add(new SelectListItem { Text = "Male", Value = true.ToString() });
            gender.Add(new SelectListItem { Text = "Female", Value = false.ToString() });
            ViewBag.Gender = new SelectList(gender, "Value", "Text", "Male");
            return View(student);
        }

        // GET: Villages/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.MajorId = new SelectList(db.Majors, "Id", "Name");
            ViewBag.VillageId = new SelectList(db.Villages, "Id", "Name");
            List<SelectListItem> gender = new List<SelectListItem>();
            gender.Add(new SelectListItem { Text = "Male", Value = true.ToString() });
            gender.Add(new SelectListItem { Text = "Female", Value = false.ToString() });
            ViewBag.Gender = new SelectList(gender, "Value", "Text", "Male");
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,Gender,PostalCode,Street,FinalScore,MajorId,VillageId,CreateDate,UpdateDate,DeleteDate,IsDelete")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MajorId = new SelectList(db.Majors, "Id", "Name");
            ViewBag.VillageId = new SelectList(db.Villages, "Id", "Name");
            List<SelectListItem> gender = new List<SelectListItem>();
            gender.Add(new SelectListItem { Text = "Male", Value = true.ToString() });
            gender.Add(new SelectListItem { Text = "Female", Value = false.ToString() });
            ViewBag.Gender = new SelectList(gender, "Value", "Text", "Male");
            return View(student);
        }

        // GET: Villages/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")] //actionname adalah nama fungsi
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Student student = await db.Students.FindAsync(id);
            db.Students.Remove(student);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) //untuk menutup koneksi yang berhubungan dengan database
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}