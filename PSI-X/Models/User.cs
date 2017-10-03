using System;
using System.ComponentModel.DataAnnotations;

namespace PSI_X.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Firstname is required")]
        public String FirstName { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        public String LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public String Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}