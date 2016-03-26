using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Examino.Models.Entities
{
    public class Quiz
    {
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


        //Proprietes de Navegation
        public virtual ApplicationUser User { get; set; }
        public virtual List<Question> Questions { get; set; }
        public virtual List<UserQuiz> UserQuizzes { get; set; }
    }
}