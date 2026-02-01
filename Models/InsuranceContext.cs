using System.Data.Entity;

namespace ASP_NET_MVC_Entity_Framework_Assignment.Models
{
    public class InsuranceContext : DbContext
    {
        public InsuranceContext() : base("InsuranceContext")
        {
        }

        public DbSet<Insuree> Insurees { get; set; }
    }
}
