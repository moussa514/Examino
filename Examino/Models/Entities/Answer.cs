using System.ComponentModel.DataAnnotations;

namespace Examino.Models.Entities
{
    public class Answer
    {
        //Cette entitie garde une réponse pour une question du Quizz
        public int Id { get; set; }

        [Required]
        public int QuestionId { get; set; }

        [Required]
        public string AnswerLabel { get; set; }

        [Required]
        public bool IsRightAnswer { get; set; }

        public string Image { get; set; }

        //Proprietes de Navegation
        public virtual Question Question { get; set; }
    }
}