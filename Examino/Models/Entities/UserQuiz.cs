using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examino.Models.Entities
{
    //Cette Entitie garde l'information des quizzes que les utilisateur ont pris
    [Serializable]
    [Table("UserQuizzes")]
    public class UserQuiz
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int QuizId { get; set; } //Clé Étangère

        [Required]
        public string ApplicationUserId { get; set; } //Clé Étangère

        [Required]
        public int CourseId { get; set; } //Clé Étangère

        [Required]
        public int GroupId { get; set; } //Clé Étangère

        //propriétés de Navegation
        [ForeignKey("QuizId")]
        public virtual Quiz Quiz { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }

        public virtual List<UserAnswer> UserAnswers { get; set; }
    }
}