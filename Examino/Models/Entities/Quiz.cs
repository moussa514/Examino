using System;
using System.Collections.Generic;

namespace Examino.Models.Entities
{
    public class Quiz
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public DateTime Duration { get; set; }
        public bool IsRandom { get; set; }
        public string Description { get; set; }


        //Proprietes de Navegation
        public ApplicationUser User { get; set; }
        public List<Question> Questions { get; set; }
    }
}