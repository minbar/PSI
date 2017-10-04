using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PSI_X.ViewModels
{
    public class CodeViewModel
    {
        [Required]
        public int CodeG { get; set; }
    }
}