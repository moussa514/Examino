namespace Examino.Models.Entities
{
    public class UserQuiz
    {
        //Cette Entitie garde l'information des quizzes que les utilisateur ont pris
        public int Id { get; set; }
        public int QuizId { get; set; } //Clé Étangère
        public int GroupeId { get; set; } //Clé Étangère
        public string ApplicationUserId { get; set; } //Clé Étangère
        public int CourseId { get; set; } //Clé Étangère

        //Proprietes de Navegation
        public Quiz Quiz { get; set; }
        public Group Group { get; set; }
        public ApplicationUser User { get; set; }
        public Course Course { get; set; }
    }
}