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

        public AdminModel FindUser(AdminModel admin)
        {
            var result = (from o in _context.Admin
                          join d in _context.Level
                          on o.AdminLevelId equals d.Id
                          where o.Email == admin.Email &&
                          o.Password == admin.Password
                          select o).FirstOrDefault();
            return result;
            
                
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
