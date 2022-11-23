using AtlasControl.Models;

namespace AtlasControl.Repository.Interfaces
{
    public interface IAdminRepository
    {
        public AdminModel InsertUser(AdminModel admin);

        public List<AdminViewModel> FindUser(AdminModel admin);

        public List<AdminViewModel> FindAllUsers();
    }
}
