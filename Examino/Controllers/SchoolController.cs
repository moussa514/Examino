using System.Net;
using System.Web.Mvc;
using Examino.Models.Entities;
using Examino.Models.Managers;
using Microsoft.AspNet.Identity;

namespace Examino.Controllers
{
    [Authorize(Roles = "Admin,Director")]
    public class SchoolController : Controller
    {
        // GET: School
        public ActionResult Index()
        {
            return View(SchoolManager.GetAll());
        }

        // GET: School/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var school = SchoolManager.GetById((int) id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }

        // GET: School/Create
        public ActionResult Create()
        {
            return View(new School {ApplicationUserId = User.Identity.GetUserId()});
        }

        // POST: School/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,Phone,Email,ApplicationUserId")] School school)
        {
            if (ModelState.IsValid)
            {
                SchoolManager.Add(school);
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(UserDetailManager.GetAll(), "Id", "Email",
                school.ApplicationUserId);
            return View(school);
        }

        // GET: School/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var school = SchoolManager.GetById((int) id);
            if (school == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(UserDetailManager.GetAll(), "Id", "Email",
                school.ApplicationUserId);
            return View(school);
        }

        // POST: School/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,Phone,Email,ApplicationUserId")] School school)
        {
            if (ModelState.IsValid)
            {
                SchoolManager.Edit(school);
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(UserDetailManager.GetAll(), "Id", "Email",
                school.ApplicationUserId);
            return View(school);
        }

        // GET: School/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var school = SchoolManager.GetById((int) id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }

        // POST: School/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SchoolManager.Delete(id);
            return RedirectToAction("Index");
        }
    }
}