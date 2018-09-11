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
    public class DistrictsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: District
        public async Task<ActionResult> Index()
        {
            var districts = db.Districts.Include(m => m.Regencies);
            return View(await db.Districts.ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = await db.Districts.FindAsync(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        //GET: Districts/Create
        public ActionResult Create()
        {
            ViewBag.RegencyId = new SelectList(db.Regencies, "Id", "Name");
            return View();
        }

        // POST: Districts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,RegencyId,CreateDate,UpdateDate,DeleteDate,IsDelete")] District district)
        {
            if (ModelState.IsValid)
            {
                db.Districts.Add(district);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RegencyId = new SelectList(db.Regencies, "Id", "Name");
            return View(district);
        }

        // GET: Districts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = await db.Districts.FindAsync(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegencyId = new SelectList(db.Regencies, "Id", "Name");
            return View(district);
        }

        // POST: Districts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,RegencyId,CreateDate,UpdateDate,DeleteDate,IsDelete")] District district)
        {
            if (ModelState.IsValid)
            {
                db.Entry(district).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RegencyId = new SelectList(db.Regencies, "Id", "Name");
            return View(district);
        }

        // GET: Majors/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = await db.Districts.FindAsync(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        // POST: Districts/Delete/5
        [HttpPost, ActionName("Delete")] //actionname adalah nama fungsi
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            District district = await db.Districts.FindAsync(id);
            db.Districts.Remove(district);
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