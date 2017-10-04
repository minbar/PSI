using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PSI_X.Models;
namespace PSI_X.Models
{
    public class DbContentPSI: DbContext
    {
        public DbContentPSI(): base("PsiDatabase")
        {

        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyCode> Codes { get; set; }
        public DbSet<User> UserAccount { get; set; }
        public DbSet<UserPoints> UserPoints { get; set; }
    



    }
}