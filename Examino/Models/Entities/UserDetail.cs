using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Examino.Models.Entities
{
    //Cette entitie est complement de l'information de l'entitie User créé par ASP
    public class UserDetail
    {
        public int Id { get; set; }

        [Required]
        public string ApplicationUserId { get; set; } //Clé étangère

        [Required]
        public string Code { get; set; }

        [Required]
        [Display(Name = "Prenom")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string LastName { get; set; }

        public string Photo { get; set; }

        [Required]
        public bool IsConfirmed { get; set; } //Pour savoir si c'est un utilisateur valide ou non

        [Required]
        public int? SchoolId { get; set; } //Clé étangère

        //proprietes de Navegation
        public virtual ApplicationUser User { get; set; }
        public virtual School School { get; set; }
    }
}