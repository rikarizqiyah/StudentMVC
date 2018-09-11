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
    public class RegenciesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Regencies
        public async Task<ActionResult> Index()
        {
            var regencies = db.Regencies.Include(m => m.Provinces);
            return View(await db.Regencies.ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regency regency = await db.Regencies.FindAsync(id);
            if (regency == null)
            {
                return HttpNotFound();
            }
            return View(regency);
        }

        //GET: Majors/Create
        public ActionResult Create()
        {
            ViewBag.ProvinceId = new SelectList(db.Provinces, "Id", "Name");
            return View();
        }

        // POST: Regencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,ProvinceId,CreateDate,UpdateDate,DeleteDate,IsDelete")] Regency regency)
        {
            if (ModelState.IsValid)
            {
                db.Regencies.Add(regency);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProvinceId = new SelectList(db.Provinces, "Id", "Name", regency.ProvinceId);
            return View(regency);
        }

        // GET: Regencies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regency regency = await db.Regencies.FindAsync(id);
            if (regency == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProvinceId = new SelectList(db.Provinces, "Id", "Name", regency.ProvinceId);
            return View(regency);
        }

        // POST: Majors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,ProvinceId,CreateDate,UpdateDate,DeleteDate,IsDelete")] Regency regency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(regency).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProvinceId = new SelectList(db.Provinces, "Id", "Name", regency.ProvinceId);
            return View(regency);
        }

        // GET: Majors/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regency regency = await db.Regencies.FindAsync(id);
            if (regency == null)
            {
                return HttpNotFound();
            }
            return View(regency);
        }

        // POST: Regencies/Delete/5
        [HttpPost, ActionName("Delete")] //actionname adalah nama fungsi
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Regency regency = await db.Regencies.FindAsync(id);
            db.Regencies.Remove(regency);
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