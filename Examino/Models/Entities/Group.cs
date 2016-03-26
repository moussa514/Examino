using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examino.Models.Entities
{
    [Table("Groups")]
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nom du Groupe")]
        public string NomGroupe { get; set; }

        //propriétés de Navegation
        public virtual List<ApplicationUser> Users { get; set; }
        public virtual List<UserQuiz> UserQuizzes { get; set; }
    }
}