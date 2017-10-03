using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSI_X.Models;
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
        [Required(ErrorMessage = "email is required")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public String Username { get; set; }
        [Required(ErrorMessage = "password is required")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        public IList<UserPoints> points  { get; set; }

}
}