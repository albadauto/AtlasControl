using AtlasControl.Context;
using AtlasControl.Models;
using AtlasControl.Repository.Interfaces;

namespace AtlasControl.Repository
{
    public class AdminLevelRepository : IAdminLevelRepository
    {
        private readonly DatabaseContext _context;
        public AdminLevelRepository(DatabaseContext context)
        {
            _context = context;
        }
        public List<AdminLevelModel> getAllLevel()
        {
            return _context.Level.ToList();
        }

        public List<AdminLevelModel> getAllLevelById(AdminLevelModel admin)
        {
            throw new NotImplementedException();
        }
    }
}
