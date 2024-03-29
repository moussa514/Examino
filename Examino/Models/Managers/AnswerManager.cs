﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Examino.Models.Entities;

namespace Examino.Models.Managers
{
    public class AnswerManager
    {
        //Ajoute un nouvel item et retourne son Id.  En cas d'erreur, ça retourne -1
        public static int Add(Answer answer)
        {
            int ret;
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    db.Answers.Add(answer);
                    ret = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        //Lecture des tous les items par QuestionId
        public static List<Answer> GetAllByQuestionId(int id)
        {
            List<Answer> list;
            using (var db = new ApplicationDbContext())
            {
                try
                {
                    list =
                        db.Answers.Include(a => a.Question)
                            .Where(item => item.QuestionId == id)
                            .OrderBy(item => item.Id)
                            .ToList();
                }
                catch (Exception)
                {
                    list = null;
                }
            }
            return list;
        }


        //Lecture d'un item par son Id
        public static Answer GetById(int id, ApplicationDbContext db = null)
        {
            Answer answer;
            if (db != null)
            {
                answer = db.Answers.Include(a => a.Question).FirstOrDefault(item => item.Id == id);
            }
            else
            {
                using (db = new ApplicationDbContext())
                {
                    answer = db.Answers.Include(a => a.Question).FirstOrDefault(item => item.Id == id);
                }
            }
            return answer;
        }


        //Rafraichir un item
        public static void Edit(Answer answer)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(answer).State = EntityState.Modified;
                //SaveChanges                    
                db.SaveChanges();
            }
        }

        //Effacer un item par son Id
        public static void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var answer = GetById(id, db);
                if (answer != null)
                {
                    db.Answers.Remove(answer);
                }
                db.SaveChanges();
            }
        }
    }
}