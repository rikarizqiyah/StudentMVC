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
    public class VillagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Village
        public async Task<ActionResult> Index()
        {
            var villages = db.Villages.Include(m => m.Districts);
            return View(await db.Villages.ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Village village = await db.Villages.FindAsync(id);
            if (village == null)
            {
                return HttpNotFound();
            }
            return View(village);
        }

        //GET: Villages/Create
        public ActionResult Create()
        {
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "Name");
            return View();
        }

        // POST: Villages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,DistrictId,CreateDate,UpdateDate,DeleteDate,IsDelete")] Village village)
        {
            if (ModelState.IsValid)
            {
                db.Villages.Add(village);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "Name");
            return View(village);
        }

        // GET: Villages/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Village village = await db.Villages.FindAsync(id);
            if (village == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "Name");
            return View(village);
        }

        // POST: Villages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,DistrictId,CreateDate,UpdateDate,DeleteDate,IsDelete")] Village village)
        {
            if (ModelState.IsValid)
            {
                db.Entry(village).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "Name");
            return View(village);
        }

        // GET: Villages/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Village village = await db.Villages.FindAsync(id);
            if (village == null)
            {
                return HttpNotFound();
            }
            return View(village);
        }

        // POST: Villages/Delete/5
        [HttpPost, ActionName("Delete")] //actionname adalah nama fungsi
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Village village = await db.Villages.FindAsync(id);
            db.Villages.Remove(village);
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