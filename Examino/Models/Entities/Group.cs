using System.Collections.Generic;

namespace Examino.Models.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string NomGroupe { get; set; }

        //Propriètes de Navegation
        public List<ApplicationUser> Users { get; set; }
    }
}