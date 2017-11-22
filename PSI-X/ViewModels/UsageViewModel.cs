using PSI_X.Models;
using System.Collections.Generic;

namespace PSI_X.ViewModels
{
    public class UsageViewModel
    {
        public List<Company> CompaniesList { get; set; }
        public string CompanyName { get; set; }
        public string CodeName { get; set; }
        public int TimesUsed { get; set; }
    }
}