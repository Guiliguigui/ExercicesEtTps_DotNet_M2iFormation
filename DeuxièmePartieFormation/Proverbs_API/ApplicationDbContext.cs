using Microsoft.EntityFrameworkCore;
using Proverbs_API.Models;

namespace Proverbs_API
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Proverb> Proverbs { get; set; }
    }
}
