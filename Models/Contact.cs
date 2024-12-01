using System.ComponentModel.DataAnnotations;

namespace ContactManagementSystem_V2.Models
{

    public class Contact
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

    }
}