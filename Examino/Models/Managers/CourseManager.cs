using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Examino.Models.Entities;

namespace Examino.Models.Managers
{
    public class CourseManager
    {
        //Ajoute un nouvel item et retourne son Id.  En cas d'erreur, ça retourne -1
        public static int Add(Course course)
        {
            int ret;
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    db.Courses.Add(course);
                    ret = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        //Lecture des tous les items
        public static List<Course> GetAll(int id)
        {
            List<Course> list;
            using (var db = new ApplicationDbContext())
            {
                try
                {
                    list = db.Courses.Include(c => c.User).OrderBy(item => item.Id).ToList();
                }
                catch (Exception)
                {
                    list = null;
                }
            }
            return list;
        }


        //Lecture d'un item par son Id
        public static Course GetById(int id, ApplicationDbContext db = null)
        {
            Course course;
            if (db != null)
            {
                course = db.Courses.Include(c => c.User).FirstOrDefault(item => item.Id == id);
            }
            else
            {
                using (db = new ApplicationDbContext())
                {
                    course = db.Courses.Include(c => c.User).FirstOrDefault(item => item.Id == id);
                }
            }
            return course;
        }


        //Rafraichir un item
        public static void Edit(Course course)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(course).State = EntityState.Modified;
                //SaveChanges                    
                db.SaveChanges();
            }
        }

        //Effacer un item par son Id
        public static void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var course = GetById(id, db);
                if (course != null)
                {
                    db.Courses.Remove(course);
                }
                db.SaveChanges();
            }
        }
    }
}