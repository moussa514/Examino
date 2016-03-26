using System;
using System.Data.Entity;
using System.Linq;
using Examino.Models.Entities;

namespace Examino.Models.Managers
{
    public class GroupManager
    {
        //Ajoute un nouvel item et retourne son Id.  En cas d'erreur, ça retourne -1
        public static int Add(Group group)
        {
            int ret;
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    db.Groups.Add(group);
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
        public static Group GetById(int id, ApplicationDbContext db = null)
        {
            Group group;
            if (db != null)
            {
                group = db.Groups.FirstOrDefault(item => item.Id == id);
            }
            else
            {
                using (db = new ApplicationDbContext())
                {
                    group = db.Groups.FirstOrDefault(item => item.Id == id);
                }
            }
            return group;
        }

        //Rafraichir un item
        public static void Edit(Group group)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(group).State = EntityState.Modified;
                //SaveChanges                    
                db.SaveChanges();
            }
        }

        //Effacer un item par son Id
        public static void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var group = GetById(id, db);
                if (group != null)
                {
                    db.Groups.Remove(group);
                }
                db.SaveChanges();
            }
        }
    }
}