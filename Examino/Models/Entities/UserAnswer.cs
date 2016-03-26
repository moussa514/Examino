using System.ComponentModel.DataAnnotations;

namespace Examino.Models.Entities
{
    public class UserAnswer
    {
        //Cette Entitie garde la réponse de l'utilisateur pour un question d'un Quizz
        public int Id { get; set; }

        [Required]
        public int UserQuizId { get; set; }

        [Required]
        public int QuestionId { get; set; }

        [Required]
        public bool IsUserAnswer { get; set; } //si l'utilisateur l'a selectionnée ou non
        public string Development { get; set; }
        public int Point { get; set; } //valeur obtenu pour cette réponse

        //Propriete de Navegation
        public virtual UserQuiz UserQuiz { get; set; }
        public virtual Question Question { get; set; }
    }
}