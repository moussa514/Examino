using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examino.Models.Entities
{
    [Table("Answers")]
    public class Answer
    {
        //Cette entitie garde une réponse pour une question du Quizz
        [Key]
        public int Id { get; set; }

        [Required]
        public int QuestionId { get; set; }

        [Required]
        public string AnswerLabel { get; set; }

        [Required]
        public bool IsRightAnswer { get; set; }

        public string Image { get; set; }

        //propriétés de Navegation
        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
    }
}