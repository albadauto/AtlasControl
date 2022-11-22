using AtlasControl.Models;

namespace AtlasControl.Repository.Interfaces
{
    public interface IAdminRepository
    {
        public AdminModel InsertUser(AdminModel admin);

        public List<AdminModel> FindUser(AdminModel admin);

        public AdminModel FindUserByEmail(AdminModel admin);
    }
}
