using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Examino.Models.Entities;

namespace Examino.Models.Managers
{
    public class UserDetailManager
    {
        //Ajoute un nouvel item et retourne son Id.  En cas d'erreur, ça retourne -1
        public static int Add(UserDetail userDetail)
        {
            int ret;
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    db.UserDetails.Add(userDetail);
                    ret = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                ret = -1;
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