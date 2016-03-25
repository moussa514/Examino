using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examino.Models.Entities
{
    //C'est entitie garde l'information d'un course
    public class Course
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Owner
        public string Code { get; set; }  //Code du course
        
        //Proprietes de Navegation
        public List<UserDetail> UsersDetails { get; set; }  //Prolongation de l'entitie User créé par ASP User
        public List<Quiz> Quizzes { get; set; }
        public List<Group> Groups { get; set; }
    }
}