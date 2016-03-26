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
    public class UserQuizController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserQuiz
        public ActionResult Index()
        {
            var userQuizzes = db.UserQuizzes.Include(u => u.Course).Include(u => u.Group).Include(u => u.Quiz).Include(u => u.User);
            return View(userQuizzes.ToList());
        }

        // GET: UserQuiz/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserQuiz userQuiz = db.UserQuizzes.Find(id);
            if (userQuiz == null)
            {
                return HttpNotFound();
            }
            return View(userQuiz);
        }

        // GET: UserQuiz/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "ApplicationUserId");
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "NomGroupe");
            ViewBag.QuizId = new SelectList(db.Quizzes, "Id", "ApplicationUserId");
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: UserQuiz/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,QuizId,ApplicationUserId,CourseId,GroupId")] UserQuiz userQuiz)
        {
            if (ModelState.IsValid)
            {
                db.UserQuizzes.Add(userQuiz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "Id", "ApplicationUserId", userQuiz.CourseId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "NomGroupe", userQuiz.GroupId);
            ViewBag.QuizId = new SelectList(db.Quizzes, "Id", "ApplicationUserId", userQuiz.QuizId);
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", userQuiz.ApplicationUserId);
            return View(userQuiz);
        }

        // GET: UserQuiz/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserQuiz userQuiz = db.UserQuizzes.Find(id);
            if (userQuiz == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "ApplicationUserId", userQuiz.CourseId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "NomGroupe", userQuiz.GroupId);
            ViewBag.QuizId = new SelectList(db.Quizzes, "Id", "ApplicationUserId", userQuiz.QuizId);
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", userQuiz.ApplicationUserId);
            return View(userQuiz);
        }

        // POST: UserQuiz/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,QuizId,ApplicationUserId,CourseId,GroupId")] UserQuiz userQuiz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userQuiz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "ApplicationUserId", userQuiz.CourseId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "NomGroupe", userQuiz.GroupId);
            ViewBag.QuizId = new SelectList(db.Quizzes, "Id", "ApplicationUserId", userQuiz.QuizId);
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", userQuiz.ApplicationUserId);
            return View(userQuiz);
        }

        // GET: UserQuiz/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserQuiz userQuiz = db.UserQuizzes.Find(id);
            if (userQuiz == null)
            {
                return HttpNotFound();
            }
            return View(userQuiz);
        }

        // POST: UserQuiz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserQuiz userQuiz = db.UserQuizzes.Find(id);
            db.UserQuizzes.Remove(userQuiz);
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
