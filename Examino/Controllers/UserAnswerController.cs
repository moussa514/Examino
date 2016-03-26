using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Examino.Models;
using Examino.Models.Entities;

namespace Examino.Controllers
{
    public class UserAnswerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserAnswer
        public ActionResult Index()
        {
            var userAnswers = db.UserAnswers.Include(u => u.Question).Include(u => u.UserQuiz);
            return View(userAnswers.ToList());
        }

        // GET: UserAnswer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAnswer userAnswer = db.UserAnswers.Find(id);
            if (userAnswer == null)
            {
                return HttpNotFound();
            }
            return View(userAnswer);
        }

        // GET: UserAnswer/Create
        public ActionResult Create()
        {
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "QuestionLabel");
            ViewBag.UserQuizId = new SelectList(db.UserQuizzes, "Id", "ApplicationUserId");
            return View();
        }

        // POST: UserAnswer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserQuizId,QuestionId,IsUserAnswer,Development,Point")] UserAnswer userAnswer)
        {
            if (ModelState.IsValid)
            {
                db.UserAnswers.Add(userAnswer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "QuestionLabel", userAnswer.QuestionId);
            ViewBag.UserQuizId = new SelectList(db.UserQuizzes, "Id", "ApplicationUserId", userAnswer.UserQuizId);
            return View(userAnswer);
        }

        // GET: UserAnswer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAnswer userAnswer = db.UserAnswers.Find(id);
            if (userAnswer == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "QuestionLabel", userAnswer.QuestionId);
            ViewBag.UserQuizId = new SelectList(db.UserQuizzes, "Id", "ApplicationUserId", userAnswer.UserQuizId);
            return View(userAnswer);
        }

        // POST: UserAnswer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserQuizId,QuestionId,IsUserAnswer,Development,Point")] UserAnswer userAnswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAnswer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "QuestionLabel", userAnswer.QuestionId);
            ViewBag.UserQuizId = new SelectList(db.UserQuizzes, "Id", "ApplicationUserId", userAnswer.UserQuizId);
            return View(userAnswer);
        }

        // GET: UserAnswer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAnswer userAnswer = db.UserAnswers.Find(id);
            if (userAnswer == null)
            {
                return HttpNotFound();
            }
            return View(userAnswer);
        }

        // POST: UserAnswer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserAnswer userAnswer = db.UserAnswers.Find(id);
            db.UserAnswers.Remove(userAnswer);
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
