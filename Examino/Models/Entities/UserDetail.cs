using System.Collections.Generic;

namespace Examino.Models.Entities
{
    //Cette entitie est complement de l'information de l'entitie User créé par ASP
    public class UserDetail
    {
        public int Id { get; set; }        
        public int ApplicationUserId { get; set; } //Clé étangère
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public bool IsConfirmed { get; set; } //Pour savoir si c'est un utilisateur valide ou non
        public int? SchoolId { get; set; }  //Clé étangère

        //proprietes de Navegation
        public ApplicationUser User { get; set; }
        public List<Group> Groups { get; set; }
        public List<UserQuiz> PassedQuizzes { get; set; }
        public School School { get; set; }
    }
}