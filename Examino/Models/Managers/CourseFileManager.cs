using System;
using System.Data.Entity;
using System.Linq;
using Examino.Models.Entities;

namespace Examino.Models.Managers
{
    public class CourseFileManager
    {
        //Ajoute un nouvel item et retourne son Id.  En cas d'erreur, ça retourne -1
        public static int Add(CourseFile courseFile)
        {
            int ret;
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    db.CourseFiles.Add(courseFile);
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
        public static CourseFile GetById(int id, ApplicationDbContext db = null)
        {
            CourseFile courseFile;
            if (db != null)
            {
                courseFile = db.CourseFiles.FirstOrDefault(item => item.Id == id);
            }
            else
            {
                using (db = new ApplicationDbContext())
                {
                    courseFile = db.CourseFiles.FirstOrDefault(item => item.Id == id);
                }
            }
            return courseFile;
        }

        //Rafraichir un item
        public static void Edit(CourseFile courseFile)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(courseFile).State = EntityState.Modified;
                //SaveChanges                    
                db.SaveChanges();
            }
        }

        //Effacer un item par son Id
        public static void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var courseFile = GetById(id, db);
                if (courseFile != null)
                {
                    db.CourseFiles.Remove(courseFile);
                }
                db.SaveChanges();
            }
        }
    }
}