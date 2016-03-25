using System.Collections.Generic;

namespace Examino.Models.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public string QuestionLabel { get; set; }
        public int Weight { get; set; }
        public QuestionType QuestionType { get; set; }
        public string SolutionDescription { get; set; }
        public string Image { get; set; }

        //Proprietes de Navegation
        public Quiz Quiz { get; set; }
        public List<Answer> AnswerQuestions { get; set; }
    }
}