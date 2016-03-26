using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examino.Models.Entities
{
    //C'est entitie garde l'information d'un course
    [Table("Courses")]
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ApplicationUserId { get; set; } // Owner

        [Required]
        public string Code { get; set; } //Code du course

        //propriétés de Navegation
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser User { get; set; }

        public virtual List<ApplicationUser> Users { get; set; } //Prolongation de l'entitie User créé par ASP User
        public virtual List<CourseFile> CourseFiles { get; set; }
        public virtual List<Quiz> Quizzes { get; set; }
        public virtual List<UserQuiz> UserQuizzes { get; set; }
        public virtual List<Group> Groups { get; set; }
    }
}