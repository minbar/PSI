using System.Data.Entity;

namespace PSI_X.Models
{
    public class DbContentPSI: DbContext
    {
        public DbContentPSI(): base("PsiDatabase")
        {

        }
        public DbSet<Company> companies { get; set; }
        public DbSet<CompanyCode> codes { get; set; }
        public DbSet<User> UserAccount { get; set; }
        public DbSet<UserPoints> userPoints { get; set; }
    



    }
}