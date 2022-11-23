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
                                       select new { o.Email, o.Password, d.LevelName, o.Name}); //QUERY FEITA (JOIN TABELA ADMIN COM LEVEL ADMIN)
            foreach(var item in result)
            {
                AdminViewModel ad = new AdminViewModel(); //CHAMA A VIEW MODEL (UMA MODEL COM TODOS OS DADOS NECESSARIOS PARA GUARDAR O JOIN)
                ad.Email = item.Email;
                ad.Password = item.Password;
                ad.AdminLevelName = item.LevelName;
                ad.Name = item.Name;
                adm.Add(ad); //ADICIONA NA LISTA DE ADM
            }
            return adm;
            
                
        }

        public List<AdminViewModel> FindAllUsers()
        {
            List<AdminViewModel> viewmodel = new List<AdminViewModel>();
            var result = (from o in _context.Admin
                            join d in _context.Level
                            on o.AdminLevelId equals d.Id
                            select new { o.Email, o.Cpf, o.Name, d.LevelName }
                          );
            foreach(var item in result)
            {
                AdminViewModel ad = new AdminViewModel();   
                ad.Name = item.Name;
                ad.Email = item.Email;
                ad.AdminLevelName = item.LevelName;
                viewmodel.Add(ad);
            }
            return viewmodel;
        }

        public AdminModel InsertUser(AdminModel admin)
        {
            _context.Admin.Add(admin);
            _context.SaveChanges();
            return admin;
        }

        
    }
}
