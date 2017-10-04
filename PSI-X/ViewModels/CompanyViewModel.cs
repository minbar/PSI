using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PSI_X.ViewModels
{
    public class CompanyViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Too short name")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Too short name")]
        public string Address { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Too short name")]
        public string TypeOfCompany { get; set; }
    }
}