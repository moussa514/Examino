using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Examino.Models.Entities
{
    //C'est entitie garde la information des fichiers pour les cours
    public class CourseFile
    {
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

        //Proprieté de Navegation
        public virtual List<Course> Courses { get; set; }
    }
}