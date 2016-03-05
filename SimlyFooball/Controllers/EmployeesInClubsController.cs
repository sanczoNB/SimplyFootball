using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimlyFooball.Models;

namespace SimlyFooball.Controllers
{
    public class EmployeesInClubsController : Controller
    {
        private FootballDbEntities db = new FootballDbEntities();

        // GET: EmployeesInClubs
        public ActionResult Index()
        {
            var employeesInClub = db.EmployeesInClub.Include(e => e.Player).Include(e => e.Team);
            return View(employeesInClub.ToList());
        }

        // GET: EmployeesInClubs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeesInClub employeesInClub = db.EmployeesInClub.Find(id);
            if (employeesInClub == null)
            {
                return HttpNotFound();
            }
            return View(employeesInClub);
        }

        // GET: EmployeesInClubs/Create
        public ActionResult Create()
        {
            ViewBag.PlayerId = new SelectList(db.Player, "Id", "FirstName");
            ViewBag.TeamId = new SelectList(db.Team, "Id", "FullName");
            return View();
        }

        // POST: EmployeesInClubs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeamId,PlayerId,Salary,SignDate")] EmployeesInClub employeesInClub)
        {
            if (ModelState.IsValid)
            {
                db.EmployeesInClub.Add(employeesInClub);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlayerId = new SelectList(db.Player, "Id", "FirstName", employeesInClub.PlayerId);
            ViewBag.TeamId = new SelectList(db.Team, "Id", "FullName", employeesInClub.TeamId);
            return View(employeesInClub);
        }

        // GET: EmployeesInClubs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeesInClub employeesInClub = db.EmployeesInClub.Find(id);
            if (employeesInClub == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerId = new SelectList(db.Player, "Id", "FirstName", employeesInClub.PlayerId);
            ViewBag.TeamId = new SelectList(db.Team, "Id", "FullName", employeesInClub.TeamId);
            return View(employeesInClub);
        }

        // POST: EmployeesInClubs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeamId,PlayerId,Salary,SignDate")] EmployeesInClub employeesInClub)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeesInClub).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerId = new SelectList(db.Player, "Id", "FirstName", employeesInClub.PlayerId);
            ViewBag.TeamId = new SelectList(db.Team, "Id", "FullName", employeesInClub.TeamId);
            return View(employeesInClub);
        }

        // GET: EmployeesInClubs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeesInClub employeesInClub = db.EmployeesInClub.Find(id);
            if (employeesInClub == null)
            {
                return HttpNotFound();
            }
            return View(employeesInClub);
        }

        // POST: EmployeesInClubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            EmployeesInClub employeesInClub = db.EmployeesInClub.Find(id);
            db.EmployeesInClub.Remove(employeesInClub);
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
