using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Examino.Models.Entities;

namespace Examino.Models.Managers
{
    public class UserAnswerManager
    {
        //Ajoute un nouvel item et retourne son Id.  En cas d'erreur, ça retourne -1
        public static int Add(UserAnswer userAnswer)
        {
            int ret;
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    db.UserAnswers.Add(userAnswer);
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
        public static UserAnswer GetById(int id, ApplicationDbContext db = null)
        {
            UserAnswer userAnswer;
            if (db != null)
            {
                userAnswer = db.UserAnswers.Include(u => u.Question).Include(u => u.UserQuiz).FirstOrDefault(item => item.Id == id);
            }
            else
            {
                using (db = new ApplicationDbContext())
                {
                    userAnswer = db.UserAnswers.Include(u => u.Question).Include(u => u.UserQuiz).FirstOrDefault(item => item.Id == id);
                }
            }
            return userAnswer;
        }

        //Rafraichir un item
        public static void Edit(UserAnswer userAnswer)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(userAnswer).State = EntityState.Modified;
                //SaveChanges                    
                db.SaveChanges();
            }
        }

        //Effacer un item par son Id
        public static void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var userAnswer = GetById(id, db);
                if (userAnswer != null)
                {
                    db.UserAnswers.Remove(userAnswer);
                }
                db.SaveChanges();
            }
        }
    }
}