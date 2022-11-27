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
        //JOIN USANDO A FUNCAO LINQ
        public List<AdminViewModel> FindUser(AdminModel admin)
        {
            List<AdminViewModel> adm = new List<AdminViewModel>();  //NOVA LISTA A PARTIR DA VIEW MODEL
            var result = (from o in _context.Admin
                                       join d in _context.Level
                                       on o.AdminLevelId equals d.Id
                                       where o.Email == admin.Email &&
                                       o.Password == admin.Password
                                       select new { o.Email, o.Password, d.LevelName, o.Name }); //QUERY FEITA (JOIN TABELA ADMIN COM LEVEL ADMIN)
            foreach(var item in result)
            {
                adm.Add(new AdminViewModel()
                {
                    Email = item.Email,
                    Password = item.Password,   
                    AdminLevelName = item.LevelName,    
                    Name = item.Name

                }); //ADICIONA NA LISTA DE ADM

            }
            return adm;
            
                
        }

        public List<AdminViewModel> FindAllUsers()
        {
            List<AdminViewModel> viewmodel = new List<AdminViewModel>();
            var result = (from o in _context.Admin
                            join d in _context.Level
                            on o.AdminLevelId equals d.Id
                            select new { o.Email, o.Cpf, o.Name, d.LevelName, o.Id }
                          );
            foreach(var item in result)
            {
                viewmodel.Add(new AdminViewModel()
                {
                    Name = item.Name,
                    Email = item.Email,
                    AdminLevelName = item.LevelName,
                    Admin = new AdminModel() { Id = item.Id }
                });
            }
            return viewmodel;
        }

        public AdminModel InsertUser(AdminModel admin)
        {
            _context.Admin.Add(admin);
            _context.SaveChanges();
            return admin;
        }

        public void DeleteUser(int id)
        {
            if(id != 0)
            {
                var result = _context.Admin.SingleOrDefault(x => x.Id == id);
                _context.Admin.Remove(result);
                _context.SaveChanges();
            }
            else
            {
                _context.SaveChanges();
            }
        }

        
    }
}
