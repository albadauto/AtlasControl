using AtlasControl.Models;
using Microsoft.EntityFrameworkCore;

namespace AtlasControl.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AdminModel> Admin { get; set; }
        public DbSet<AdminLevelModel> Level { get; set; }

        
    }
}
