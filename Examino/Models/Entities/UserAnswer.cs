namespace Examino.Models.Entities
{
    public class UserAnswer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public bool IsUserAnswer { get; set; }  //si l'utilisateur l'a selectionnée ou non
        public string Development { get; set; } 
        public int Point { get; set; }  //valeur obtenu pour cette réponse
    }
}