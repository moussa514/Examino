namespace Examino.Models.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string AnswerLabel { get; set; }
        public bool IsRightAnswer { get; set; }
        public string Image { get; set; }

        //Proprietes de Navegation
        public Question Question { get; set; }
    }
}