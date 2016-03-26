using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examino.Models.Entities
{
    //Quiz template
    [Table("Quizzes")]
    public class Quiz
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [Required]
        [Display(Name = "Actif")]
        public bool IsActive { get; set; }

        [Display(Name = "Mot de Passe")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime Duration { get; set; }

        [Display(Name = "Questions Randomizés")]
        public bool IsRandom { get; set; }

        [Display(Name = "Description Quiz")]
        public string Description { get; set; }

        //propriétés de Navegation
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser User { get; set; }

        public virtual List<Question> Questions { get; set; }
        public virtual List<UserQuiz> UserQuizzes { get; set; }
    }
}