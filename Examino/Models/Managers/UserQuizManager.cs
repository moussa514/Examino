using System;
using System.Data.Entity;
using System.Linq;
using Examino.Models.Entities;

namespace Examino.Models.Managers
{
    public class UserQuizManager
    {
        //Ajoute un nouvel item et retourne son Id.  En cas d'erreur, ça retourne -1
        public static int Add(UserQuiz userQuiz)
        {
            int ret;
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    db.UserQuizzes.Add(userQuiz);
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
        public static UserQuiz GetById(int id, ApplicationDbContext db = null)
        {
            UserQuiz userQuiz;
            if (db != null)
            {
                userQuiz =
                    db.UserQuizzes.Include(u => u.Course)
                        .Include(u => u.Group)
                        .Include(u => u.Quiz)
                        .Include(u => u.User)
                        .FirstOrDefault(item => item.Id == id);
            }
            else
            {
                using (db = new ApplicationDbContext())
                {
                    userQuiz =
                        db.UserQuizzes.Include(u => u.Course)
                            .Include(u => u.Group)
                            .Include(u => u.Quiz)
                            .Include(u => u.User)
                            .FirstOrDefault(item => item.Id == id);
                }
            }
            return userQuiz;
        }

        //Rafraichir un item
        public static void Edit(UserQuiz userQuiz)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(userQuiz).State = EntityState.Modified;
                //SaveChanges                    
                db.SaveChanges();
            }
        }

        //Effacer un item par son Id
        public static void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var userQuiz = GetById(id, db);
                if (userQuiz != null)
                {
                    db.UserQuizzes.Remove(userQuiz);
                }
                db.SaveChanges();
            }
        }
    }
}