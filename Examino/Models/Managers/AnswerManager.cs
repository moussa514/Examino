//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;
//using Examino.Models.Entities;

//namespace Examino.Models.Managers
//{
//    public class AnswerManager
//    {
//        //Create
//        public static int Add(Answer answer)
//        {
//            int ret;
//            try
//            {
//                using (var db = new ApplicationDbContext())
//                {
//                    db.Answers.Add(answer);
//                    ret = db.SaveChanges();
//                }
//            }
//            catch (Exception)
//            {
//                ret = -1;
//            }
//            return ret;
//        }

//        //Read
//        public static List<Answer> GetAllByVoitureId(int id)
//        {
//            List<Answer> list;
//            using (var db = new ApplicationDbContext())
//            {
//                try
//                {
//                    list = db.Answers.Where(item => item.Id == id).OrderBy(item => item.Id).ToList();
//                }
//                catch (Exception)
//                {
//                    list = null;
//                }
//            }
//            return list;
//        }


//        public static Answer GetById(int id, ApplicationDbContext db = null)
//        {
//            Answer answer;
//            if (db != null)
//            {
//                answer = db.Answers.FirstOrDefault(item => item.Id == id);
//            }
//            else
//            {
//                using (db = new ApplicationDbContext())
//                {
//                    answer = db.Answers.FirstOrDefault(item => item.Id == id);
//                }
//            }
//            return answer;
//        }


//        //Update
//        public static void Edit(Answer answer)
//        {
//            using (var db = new ApplicationDbContext())
//            {
//                db.Entry(answer).State = EntityState.Modified;
//                //SaveChanges                    
//                db.SaveChanges();

//                //SaveChanges                    
//                db.SaveChanges();
//            }
//        }

//        //Delete
//        public static void Delete(int id)
//        {
//            using (var db = new ApplicationDbContext())
//            {
//                var answer = GetById(id, db);
//                if (answer != null)
//                {
//                    db.Answers.Remove(answer);
//                }
//                db.SaveChanges();
//            }
//        }
//    }
//}