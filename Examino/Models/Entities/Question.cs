using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examino.Models.Entities
{
    //Cette Entitie garde une question pour un Quizz
    [Table("Questions")]
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int QuizId { get; set; }

        [Required]
        [Display(Name = "Question")]
        public string QuestionLabel { get; set; }

        [Required]
        [Display(Name = "Poids")]
        public int Weight { get; set; }

        [Required]
        [Display(Name = "Type de Question")]
        public QuestionType QuestionType { get; set; }

        [Display(Name = "Description")]
        public string SolutionDescription { get; set; }

        public string Image { get; set; }

        //propriétés de Navegation
        [ForeignKey("QuizId")]
        public virtual Quiz Quiz { get; set; }

        public virtual List<Answer> Answers { get; set; }
    }
}