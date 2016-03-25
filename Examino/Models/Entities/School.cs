using System.Collections.Generic;

namespace Examino.Models.Entities
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ApplicationUserId { get; set; }

        //Propriete de Navegation
        public ApplicationUser User { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}