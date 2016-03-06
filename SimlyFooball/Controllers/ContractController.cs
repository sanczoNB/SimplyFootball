using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SimlyFooball.DataAccess;
using SimlyFooball.Models;

namespace SimlyFooball.Controllers
{
    public class ContractController : Controller
    {

        private readonly ITeamRepository _teamRepository = new TeamRepository();

        private readonly IPlayerRepository _playerRepository = new PlayerRepository();
        
        private readonly IContractRepository _contractRepository = new ContractRepository();

        // GET: EmployeesInClubs
        public ActionResult Index()
        {
          var employeesInClub = _contractRepository.GetAll().ToList();
            return View(employeesInClub);
        }

        // GET: EmployeesInClubs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract employeesInClub = _contractRepository.GetById(id.Value);
            if (employeesInClub == null)
            {
                return HttpNotFound();
            }
            return View(employeesInClub);
        }

        // GET: EmployeesInClubs/Create
        public ActionResult Create()
        {
            ViewBag.PlayerId = new SelectList(_playerRepository.GetAviable(), "Id", "FirstName");
            ViewBag.TeamId = new SelectList(_teamRepository.GetAll(), "Id", "FullName");
            return View();
        }

        // POST: EmployeesInClubs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeamId,PlayerId,Salary,SignDate")] Contract employeesInClub)
        {
            if (ModelState.IsValid)
            {
                _contractRepository.Add(employeesInClub);
                return RedirectToAction("Index");
            }

            ViewBag.PlayerId = new SelectList(_playerRepository.GetAviable(), "Id", "FirstName", employeesInClub.PlayerId);
            ViewBag.TeamId = new SelectList(_teamRepository.GetAll(), "Id", "FullName", employeesInClub.TeamId);
            return View(employeesInClub);
        }

        // GET: EmployeesInClubs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract employeesInClub = _contractRepository.GetById(id.Value);
            if (employeesInClub == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerId = new SelectList(_playerRepository.GetAviable(), "Id", "FirstName", employeesInClub.PlayerId);
            ViewBag.TeamId = new SelectList(_teamRepository.GetAll(), "Id", "FullName", employeesInClub.TeamId);
            return View(employeesInClub);
        }

        // POST: EmployeesInClubs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeamId,PlayerId,Salary,SignDate")] Contract employeesInClub)
        {
            if (ModelState.IsValid)
            {
                _contractRepository.Update(employeesInClub);
                return RedirectToAction("Index");
            }
            ViewBag.PlayerId = new SelectList(_playerRepository.GetAviable(), "Id", "FirstName", employeesInClub.PlayerId);
            ViewBag.TeamId = new SelectList(_teamRepository.GetAll(), "Id", "FullName", employeesInClub.TeamId);
            return View(employeesInClub);
        }

        // GET: EmployeesInClubs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract employeesInClub = _contractRepository.GetById(id.Value);
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
            _contractRepository.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _contractRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
