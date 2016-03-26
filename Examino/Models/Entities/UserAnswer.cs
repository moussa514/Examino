using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examino.Models.Entities
{
    //Cette Entitie garde la réponse de l'utilisateur pour un question d'un Quizz
    [Table("UserAnswers")]
    public class UserAnswer
    {        
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserQuizId { get; set; }

        [Required]
        public int QuestionId { get; set; }

        [Required]
        public bool IsUserAnswer { get; set; } //si l'utilisateur l'a selectionnée ou non
        public string Development { get; set; }
        public int Point { get; set; } //valeur obtenu pour cette réponse

        //propriétés de Navegation
        [ForeignKey("UserQuizId")]
        public virtual UserQuiz UserQuiz { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
    }
}