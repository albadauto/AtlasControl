using AtlasControl.Models;

namespace AtlasControl.Repository.Interfaces
{
    public interface IAdminLevelRepository
    {
        public List<AdminLevelModel> getAllLevel();
        public List<AdminLevelModel> getAllLevelById(AdminLevelModel admin);

    }
}
