using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSI_X.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TypeOfCompany { get; set; }
    }
}