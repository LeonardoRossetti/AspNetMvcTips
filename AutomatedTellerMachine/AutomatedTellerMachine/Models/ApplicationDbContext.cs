using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace AutomatedTellerMachine.Models
{
    public interface IApplicationDbContext
    {
        IDbSet<CheckingAccount> CheckingAccounts { get; set; }

        IDbSet<Transaction> Transactions { get; set; }

        int SaveChanges();
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<CheckingAccount> CheckingAccounts { get; set; }

        public IDbSet<Transaction> Transactions { get; set; }
    }

    public class FakeApplicationDbContext : IApplicationDbContext
    {
        public IDbSet<CheckingAccount> CheckingAccounts { get; set; }

        public IDbSet<Transaction> Transactions { get; set; }

        public int SaveChanges()
        {
            return 0;
        }
    }
}