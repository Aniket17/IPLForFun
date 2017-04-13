using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IPLForFun.Models;
using IPLForFun.Services;

namespace IPLForFun.Controllers
{
    public class MatchesController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private MatchesService matchesService;
        public MatchesController()
        {
            matchesService = matchesService ?? new MatchesService(db);
        }
        // GET: Matches
        public ActionResult Index()
        {
            var matches = db.Matches.Include(m => m.Guest).Include(m => m.Host);
            return View(matches.ToList());
        }

        // GET: Matches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // GET: Matches/Create
        public ActionResult Create()
        {
            ViewBag.GuestTeamId = new SelectList(db.Teams, "TeamId", "Name");
            ViewBag.HostTeamId = new SelectList(db.Teams, "TeamId", "Name");
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatchId,HostTeamId,GuestTeamId,IsApproved,Date,Time")] Match match)
        {
            if (ModelState.IsValid)
            {
                db.Matches.Add(match);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GuestTeamId = new SelectList(db.Teams, "TeamId", "Name", match.GuestTeamId);
            ViewBag.HostTeamId = new SelectList(db.Teams, "TeamId", "Name", match.HostTeamId);
            return View(match);
        }

        // GET: Matches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            ViewBag.GuestTeamId = new SelectList(db.Teams, "TeamId", "Name", match.GuestTeamId);
            ViewBag.HostTeamId = new SelectList(db.Teams, "TeamId", "Name", match.HostTeamId);
            return View(match);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatchId,HostTeamId,GuestTeamId,IsApproved,Date,Time")] Match match)
        {
            if (ModelState.IsValid)
            {
                db.Entry(match).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GuestTeamId = new SelectList(db.Teams, "TeamId", "Name", match.GuestTeamId);
            ViewBag.HostTeamId = new SelectList(db.Teams, "TeamId", "Name", match.HostTeamId);
            return View(match);
        }

        // GET: Matches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Match match = db.Matches.Find(id);
            db.Matches.Remove(match);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCurrentMatches()
        {

            return PartialView(matchesService.GetCurrentMatches(""));
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
