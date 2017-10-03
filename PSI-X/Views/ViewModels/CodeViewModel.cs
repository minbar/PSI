using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PSI_X.Views.ViewModels
{
    public class CodeViewModel
    {
        [Required]
        public int Code { get; set; }
    }
}