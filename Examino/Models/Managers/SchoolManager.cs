using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Examino.Models.Entities;

namespace Examino.Models.Managers
{
    public class SchoolManager
    {
        //Ajoute un nouvel item et retourne son Id.  En cas d'erreur, ça retourne -1
        public static int Add(School school)
        {
            int ret;
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    db.Schools.Add(school);
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
        public static School GetById(int id, ApplicationDbContext db = null)
        {
            School school;
            if (db != null)
            {
                school = db.Schools.Include(s => s.User).FirstOrDefault(item => item.Id == id);
            }
            else
            {
                using (db = new ApplicationDbContext())
                {
                    school = db.Schools.Include(s => s.User).FirstOrDefault(item => item.Id == id);
                }
            }
            return school;
        }

        //Rafraichir un item
        public static void Edit(School school)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(school).State = EntityState.Modified;
                //SaveChanges                    
                db.SaveChanges();
            }
        }

        //Effacer un item par son Id
        public static void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var school = GetById(id, db);
                if (school != null)
                {
                    db.Schools.Remove(school);
                }
                db.SaveChanges();
            }
        }
    }
}