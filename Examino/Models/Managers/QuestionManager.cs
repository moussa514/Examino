using System;
using System.Data.Entity;
using System.Linq;
using Examino.Models.Entities;

namespace Examino.Models.Managers
{
    public class QuestionManager
    {
        //Ajoute un nouvel item et retourne son Id.  En cas d'erreur, ça retourne -1
        public static int Add(Question question)
        {
            int ret;
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    db.Questions.Add(question);
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
        public static Question GetById(int id, ApplicationDbContext db = null)
        {
            Question question;
            if (db != null)
            {
                question = db.Questions.FirstOrDefault(item => item.Id == id);
            }
            else
            {
                using (db = new ApplicationDbContext())
                {
                    question = db.Questions.FirstOrDefault(item => item.Id == id);
                }
            }
            return question;
        }

        //Rafraichir un item
        public static void Edit(Question question)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(question).State = EntityState.Modified;
                //SaveChanges                    
                db.SaveChanges();
            }
        }

        //Effacer un item par son Id
        public static void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var question = GetById(id, db);
                if (question != null)
                {
                    db.Questions.Remove(question);
                }
                db.SaveChanges();
            }
        }
    }
}