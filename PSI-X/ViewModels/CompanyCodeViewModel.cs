using PSI_X.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PSI_X.ViewModels
{
    public class CompanyCodeViewModel
    {
        public CompanyCode codesForCompany { get; set; }
        public IEnumerable<Company> companiesCodeView { get; set; }
    }
}