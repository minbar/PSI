using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSI_X.Models;
namespace PSI_X.Models
{
    public class UserPoints
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        //public int CompanyId { get; set; }
        public string NameOfCompany { get; set; }
        public int UserCompanyPoints { get; set; } /*by default at the begins it will be 0 */

    }
}