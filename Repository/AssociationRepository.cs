using AtlasControl.Context;
using AtlasControl.Models;
using AtlasControl.Repository.Interfaces;

namespace AtlasControl.Repository
{
    public class AssociationRepository : IAssociationRepository
    {
        private readonly DatabaseContext _context;
        public AssociationRepository(DatabaseContext context)
        {
            _context = context;
        }
        public List<AssociationsModel> GetAllAssociations()
        {
            List<AssociationsModel> list = new List<AssociationsModel>();
            var result = (from a in _context.Associations
                          join i in _context.Institution
                          on a.InstitutionId equals i.Id
                          join u in _context.User
                          on a.UserId equals u.Id
                          where a.Status != "A"
                          select new { a.Status, i.InstitutionName, u.Name, u.Cpf, u.Id, AssociationId = a.Id });
            foreach(var i in result)
            {
                list.Add(new AssociationsModel()
                {
                    Id = i.AssociationId, 
                    Status = i.Status,
                    Institution = new InstitutionModel()
                    {
                        InstitutionName = i.InstitutionName,
                    },
                    User = new UserModel()
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Cpf = i.Cpf
                    }
                });
            }
            return list;
        }

        public AssociationsModel SetAssociationToAccept(int id)
        {
            var result = _context.Associations.FirstOrDefault(x => x.UserId == id && x.Status == "P");
            if(result != null)
            {
                result.Status = "A";
                _context.Associations.Update(result);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("é nulo");
            }
            return result;
        }
    }
}
