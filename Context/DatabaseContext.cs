using Microsoft.EntityFrameworkCore;

namespace AtlasControl.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
    }
}
