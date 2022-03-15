using Microsoft.EntityFrameworkCore;
using TotvsChallengeApp.Core.Entities;

namespace TotvsChallengeApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
