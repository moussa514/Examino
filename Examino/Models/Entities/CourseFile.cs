using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examino.Models.Entities
{
    //C'est entitie garde la information des fichiers pour les cours
    [Table("CourseFiles")]
    public class CourseFile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Type Fichier")]
        public FileType FileType { get; set; }

        [Required]
        [Display(Name = "Lien")]
        public string Link { get; set; }

        //propriétés de Navegation
        public virtual List<Course> Courses { get; set; }
    }
}