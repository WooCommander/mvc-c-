using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConsoleAppStart.model;

namespace WebApplication1.Controllers
{
    public class ServicesController : Controller
    {
        private MyAppContext db = new MyAppContext();

        // GET: Services
        public async Task<ActionResult> Index()
        {
            return View(await db.Services.ToListAsync());
        }

        // GET: Services/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services services = await db.Services.FindAsync(id);
            if (services == null)
            {
                return HttpNotFound();
            }
            return View(services);
        }

        // GET: Services/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,NameSercvice,PrceService,ServiceCode")] Services services)
        {
            if (ModelState.IsValid)
            {
                db.Services.Add(services);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(services);
        }

        // GET: Services/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services services = await db.Services.FindAsync(id);
            if (services == null)
            {
                return HttpNotFound();
            }
            return View(services);
        }

        // POST: Services/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,NameSercvice,PrceService,ServiceCode")] Services services)
        {
            if (ModelState.IsValid)
            {
                db.Entry(services).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(services);
        }

        // GET: Services/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services services = await db.Services.FindAsync(id);
            if (services == null)
            {
                return HttpNotFound();
            }
            return View(services);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Services services = await db.Services.FindAsync(id);
            db.Services.Remove(services);
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
