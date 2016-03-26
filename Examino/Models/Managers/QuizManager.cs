using System;
using System.Data.Entity;
using System.Linq;
using Examino.Models.Entities;

namespace Examino.Models.Managers
{
    public class QuizManager
    {
        //Ajoute un nouvel item et retourne son Id.  En cas d'erreur, ça retourne -1
        public static int Add(Quiz quiz)
        {
            int ret;
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    db.Quizzes.Add(quiz);
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
        public static Quiz GetById(int id, ApplicationDbContext db = null)
        {
            Quiz quiz;
            if (db != null)
            {
                quiz = db.Quizzes.Include(q => q.User).FirstOrDefault(item => item.Id == id);
            }
            else
            {
                using (db = new ApplicationDbContext())
                {
                    quiz = db.Quizzes.Include(q => q.User).FirstOrDefault(item => item.Id == id);
                }
            }
            return quiz;
        }

        //Rafraichir un item
        public static void Edit(Quiz quiz)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(quiz).State = EntityState.Modified;
                //SaveChanges                    
                db.SaveChanges();
            }
        }

        //Effacer un item par son Id
        public static void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var quiz = GetById(id, db);
                if (quiz != null)
                {
                    db.Quizzes.Remove(quiz);
                }
                db.SaveChanges();
            }
        }
    }
}