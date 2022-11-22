using AtlasControl.Models;

namespace AtlasControl.Repository.Interfaces
{
    public interface IAdminRepository
    {
        public AdminModel InsertUser(AdminModel admin);

        public AdminModel FindUser(AdminModel admin);

        public AdminModel FindUserByEmail(AdminModel admin);
    }
}
