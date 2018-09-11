using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bootcamp_18.Models;

namespace Bootcamp_18.Controllers
{
    public class MajorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Majors
        public async Task<ActionResult> Index()
        {
            var majors = db.Majors.Include(m => m.Faculties);
            return View(await majors.ToListAsync());
        }

        // GET: Majors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Major major = await db.Majors.FindAsync(id);
            if (major == null)
            {
                return HttpNotFound();
            }
            return View(major);
        }

        // GET: Majors/Create
        public ActionResult Create()
        {
            ViewBag.FacultyId = new SelectList(db.Faculties, "Id", "Name");
            return View();
        }

        // POST: Majors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,FacultyId,CreateDate,UpdateDate,DeleteDate,IsDelete")] Major major)
        {
            if (ModelState.IsValid)
            {
                db.Majors.Add(major);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FacultyId = new SelectList(db.Faculties, "Id", "Name", major.FacultyId);
            return View(major);
        }

        // GET: Majors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Major major = await db.Majors.FindAsync(id);
            if (major == null)
            {
                return HttpNotFound();
            }
            ViewBag.FacultyId = new SelectList(db.Faculties, "Id", "Name", major.FacultyId);
            return View(major);
        }

        // POST: Majors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,FacultyId,CreateDate,UpdateDate,DeleteDate,IsDelete")] Major major)
        {
            if (ModelState.IsValid)
            {
                db.Entry(major).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FacultyId = new SelectList(db.Faculties, "Id", "Name", major.FacultyId);
            return View(major);
        }

        // GET: Majors/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Major major = await db.Majors.FindAsync(id);
            if (major == null)
            {
                return HttpNotFound();
            }
            return View(major);
        }

        // POST: Majors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Major major = await db.Majors.FindAsync(id);
            db.Majors.Remove(major);
            await db.SaveChangesAsync();
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
