using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Examino.Models.Entities
{
    public class UserQuiz
    {
        //Cette Entitie garde l'information des quizzes que les utilisateur ont pris
        public int Id { get; set; }

        //[Required]
        //public int QuizId { get; set; } //Clé Étangère

        //[Required]
        //public int GroupeId { get; set; } //Clé Étangère

        //[Required]
        //public string ApplicationUserId { get; set; } //Clé Étangère

        //[Required]
        //public int CourseId { get; set; } //Clé Étangère

        ////Proprietes de Navegation
        //public virtual Quiz Quiz { get; set; }
        //public virtual Group Group { get; set; }
        //public virtual ApplicationUser User { get; set; }
        //public virtual Course Course { get; set; }
        //public virtual List<UserAnswer> UserAnswers { get; set; }
    }
}