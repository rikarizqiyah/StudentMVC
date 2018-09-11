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
    public class ProvincesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Provinces
        public async Task<ActionResult> Index()
        {
            return View(await db.Provinces.ToListAsync());
        }

        // GET: Majors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Province province = await db.Provinces.FindAsync(id);
            if (province == null)
            {
                return HttpNotFound();
            }
            return View(province);
        }

        // GET: Provinces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Provinces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,CreateDate,UpdateDate,DeleteDate,IsDelete")] Province province)
        {
            if (ModelState.IsValid) //validasi model benar atau atribut sudah valid
            {
                db.Provinces.Add(province);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(province);
        }

        // GET: Provinces/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Province province = await db.Provinces.FindAsync(id);
            if (province == null)
            {
                return HttpNotFound();
            }
            return View(province);
        }

        // POST: Provinces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,CreateDate,UpdateDate,DeleteDate,IsDelete")] Province province)
        {
            if (ModelState.IsValid)
            {
                db.Entry(province).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(province);
        }

        // GET: Provinces/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Province province = await db.Provinces.FindAsync(id);
            if (province == null)
            {
                return HttpNotFound();
            }
            return View(province);
        }

        // POST: Provinces/Delete/5
        [HttpPost, ActionName("Delete")] //actionname adalah nama fungsi
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Province province = await db.Provinces.FindAsync(id);
            db.Provinces.Remove(province);
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