using System.Collections.Generic;

namespace Examino.Models.Entities
{
    //C'est entitie garde la information des fichiers pour les cours
    public class CourseFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FileType FileType { get; set; }
        public string Link { get; set; }

        //Proprieté de Navegation
        public List<Course> Courses { get; set; }
    }
}