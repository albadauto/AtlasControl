using AtlasControl.Context;
using AtlasControl.Models;
using AtlasControl.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AtlasControl.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DatabaseContext _context;
        public AdminRepository(DatabaseContext context)
        {
            _context = context;
        }

        public List<AdminModel> FindUser(AdminModel admin)
        {
            List<AdminModel> adm= new List<AdminModel>();    
            var result = (from o in _context.Admin
                                       join d in _context.Level
                                       on o.AdminLevelId equals d.Id
                                       where o.Email == o.Email &&
                                       o.Password == o.Password
                                       select new { o.Email, o.Password, d.LevelName });
            foreach(var item in result)
            {
                AdminModel ad = new AdminModel();
                ad.Email = item.Email;
                ad.Password = item.Password;
                ad.AdminLevelName = item.LevelName;
                adm.Add(ad);
            }
            return adm;
            
                
        }

        public AdminModel FindUserByEmail(AdminModel admin)
        {
            var result = _context.Admin.FirstOrDefault(x => x.Email == admin.Email && x.Password == admin.Password);
            return result;
        }

        public AdminModel InsertUser(AdminModel admin)
        {
            _context.Admin.Add(admin);
            _context.SaveChanges();
            return admin;
        }

        
    }
}
