using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examino.Models.Entities
{
    //Cette entitie est complement de l'information de l'entitie User créé par ASP
    [Serializable]
    [Table("UserDetails")]
    public class UserDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ApplicationUserId { get; set; } //Clé étangère

        [Required]
        public string CodeUser { get; set; }

        [Required]
        [Display(Name = "Prenom")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string LastName { get; set; }

        public string Photo { get; set; }

        [Required]
        public bool IsConfirmed { get; set; } //Pour savoir si c'est un utilisateur valide ou non

        public int? SchoolId { get; set; } //Clé étangère

        //propriétés de Navegation
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("SchoolId")]
        public virtual School School { get; set; }

        [NotMapped]
        public virtual List<bool> Roles { get; set; }
    }
}