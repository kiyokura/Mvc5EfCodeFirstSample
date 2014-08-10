using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyRecipes.Models;

namespace MyRecipes.Controllers
{
    public class FoodstuffsController : Controller
    {
        private RecipesDbContext db = new RecipesDbContext();

        // GET: Foodstuffs
        public ActionResult Index()
        {
            return View(db.Foodstuffs.ToList());
        }

        // GET: Foodstuffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Foodstuff foodstuff = db.Foodstuffs.Find(id);
            if (foodstuff == null)
            {
                return HttpNotFound();
            }
            return View(foodstuff);
        }

        // GET: Foodstuffs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Foodstuffs/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Foodstuff foodstuff)
        {
            if (ModelState.IsValid)
            {
                db.Foodstuffs.Add(foodstuff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(foodstuff);
        }

        // GET: Foodstuffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Foodstuff foodstuff = db.Foodstuffs.Find(id);
            if (foodstuff == null)
            {
                return HttpNotFound();
            }
            return View(foodstuff);
        }

        // POST: Foodstuffs/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Foodstuff foodstuff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodstuff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foodstuff);
        }

        // GET: Foodstuffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Foodstuff foodstuff = db.Foodstuffs.Find(id);
            if (foodstuff == null)
            {
                return HttpNotFound();
            }
            return View(foodstuff);
        }

        // POST: Foodstuffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Foodstuff foodstuff = db.Foodstuffs.Find(id);
            db.Foodstuffs.Remove(foodstuff);
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
