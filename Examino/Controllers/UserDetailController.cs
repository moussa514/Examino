using System.Net;
using System.Web.Mvc;
using Examino.Models.Entities;
using Examino.Models.Managers;

namespace Examino.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserDetailController : Controller
    {
        // GET: UserDetail
        public ActionResult Index()
        {
            return View(UserDetailManager.GetAll());
        }

        // GET: UserDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userDetail = UserDetailManager.GetById(id ?? 0);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }

        // GET: UserDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userDetail = UserDetailManager.GetById(id ?? 0);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }

        // POST: UserDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,ApplicationUserId,Code,FirstName,LastName,Photo,IsConfirmed,SchoolId")] UserDetail
                userDetail)
        {
            if (ModelState.IsValid)
            {
                UserDetailManager.Edit(userDetail);
                return RedirectToAction("Index");
            }
            return View(userDetail);
        }

        // GET: UserDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userDetail = UserDetailManager.GetById(id ?? 0);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }

        // POST: UserDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {            
            UserDetailManager.Delete(id);
            return RedirectToAction("Index");
        }
    }
}