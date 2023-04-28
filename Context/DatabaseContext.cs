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
        public DbSet<DocumentationModel> Documentations { get; set; }
        public DbSet<UserModel> User { get; set; }
        public DbSet<InstitutionModel> Institution { get; set; }
        public DbSet<AssociationsModel> Associations { get; set; }
        public DbSet<DenouncesModel> Denounces { get; set; }
        public DbSet<AvaliationModel> Avaliations { get; set; }
        public DbSet<AdminLevelModel> Level { get; set; }

        
    }
}
