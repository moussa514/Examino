using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Examino.Models.Entities
{
    public class Group
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nom du Groupe")]
        public string NomGroupe { get; set; }

        //Propriètes de Navegation
        public virtual List<ApplicationUser> Users { get; set; }
        public virtual List<UserQuiz> UserQuizzes { get; set; }
    }
}