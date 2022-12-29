using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace WebApi6.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
    }
}
