using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Examino.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Examino.Models.Managers
{
    public class UserDetailManager
    {
        //Ajoute un nouvel item et retourne son Id.  En cas d'erreur, ça retourne -1
        public static int Add(UserDetail userDetail)
        {
            int ret;
            //try
            //{
                using (var db = new ApplicationDbContext())
                {
                    db.UserDetails.Add(userDetail);
                    ret = db.SaveChanges();
                }
            //}
            //catch (Exception)
            //{
            //    ret = -1;
            //}
            return ret;
        }

        public static IdentityResult AddRoleUser(ApplicationUser user, string role)
        {
            //Ajoute Role pour l'utilisateur
            IdentityResult ret;
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var userStore = new UserStore<ApplicationUser>(db);
                    var userManager = new UserManager<ApplicationUser>(userStore);
                    ret = userManager.AddToRole(user.Id, role);
                }
            }
            catch (Exception)
            {
                ret = IdentityResult.Failed();
            }
            return ret;

        }

        //Lecture d'un item par son Id
        public static UserDetail GetById(int id, ApplicationDbContext db = null)
        {
            UserDetail userDetail;
            if (db != null)
            {
                userDetail = db.UserDetails.Include(u => u.School).Include(u => u.User).FirstOrDefault(item => item.Id == id);
            }
            else
            {
                using (db = new ApplicationDbContext())
                {
                    userDetail = db.UserDetails.Include(u => u.School).Include(u => u.User).FirstOrDefault(item => item.Id == id);
                }
            }
            return userDetail;
        }

        //Lecture de tous les roles disponibles
        public static List<SelectListItem> GetAllRoles(ApplicationDbContext db = null)
        {
            List<SelectListItem> roles;
            if (db != null)
            {
                roles = db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            }
            else
            {
                using (db = new ApplicationDbContext())
                {
                    roles = db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                }
            }
            return roles;
        }

        //Rafraichir un item
        public static void Edit(UserDetail userDetail)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(userDetail).State = EntityState.Modified;
                //SaveChanges                    
                db.SaveChanges();
            }
        }

        //Effacer un item par son Id
        public static void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var userDetail = GetById(id, db);
                if (userDetail != null)
                {
                    db.UserDetails.Remove(userDetail);
                }
                db.SaveChanges();
            }
        }
    }
}