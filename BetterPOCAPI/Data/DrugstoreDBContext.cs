using BetterPOCAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BetterPOCAPI.Data
{
    public class DrugstoreDBContext : DbContext
    {
        public DrugstoreDBContext(DbContextOptions options) : base(options)
        {

        }

        //Dbset
        public DbSet<Drugstore> Drugstores { get; set; }
    }
}
