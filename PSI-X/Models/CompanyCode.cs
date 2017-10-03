using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSI_X.Models
{
    public class CompanyCode
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; } /*for what kind of product the code is created, coffee, tea... */
        public int Code { get; set; }
        public int Points { get; set; }
    }
}