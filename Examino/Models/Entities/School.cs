using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examino.Models.Entities
{
    [Serializable]
    [Table("Schools")]
    public class School
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string Name { get; set; }

        [Display(Name = "Adresse")]
        public string Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
            ErrorMessage = "Il faut entrer un numero de téléphone valide")]
        [Display(Name = "Téléphone")]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(
            @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",
            ErrorMessage = "Il faut entrer un courriel valide")]
        [Display(Name = "Courriel")]
        public string Email { get; set; }

        [Required]
        public string ApplicationUserId { get; set; } //Clé Étangère

        //propriétés de Navegation
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser User { get; set; }

        public virtual List<ApplicationUser> Users { get; set; }
        public virtual List<UserDetail> UserDetails { get; set; }
    }
}