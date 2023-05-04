using AtlasControl.Context;
using AtlasControl.Models;
using AtlasControl.Repository.Interfaces;

namespace AtlasControl.Repository
{
    public class DenounceRepository : IDenounceRepository
    {
        private readonly DatabaseContext _context;
        public DenounceRepository(DatabaseContext context)
        {
            _context = context;
        }
        public List<DenouncesModel> GetAllDenounces()
        {
            List<DenouncesModel> denouncesModels = new List<DenouncesModel>();
            var result = (from i in _context.Denounces
                          join a in _context.Avaliations
                          on i.AvaliationId equals a.Id
                          join c in _context.User
                          on a.UserId equals c.Id
                          join l in _context.Institution
                          on a.InstitutionId equals l.Id
                          select new { i.Comment, c.Name, a.Note, l.InstitutionName, DenounceId = i.Id }).ToList();

            foreach ( var d in result )
            {
                denouncesModels.Add(new DenouncesModel
                {
                    Id = d.DenounceId,
                    Comment = d.Comment,
                    Avaliation = new AvaliationModel
                    {
                        Note = d.Note,

                        User = new UserModel
                        {
                            Name = d.Name,
                        },
                        Institution = new InstitutionModel
                        {
                            InstitutionName = d.InstitutionName,
                        }
                    }
                });
            }

            return denouncesModels;
        }

        public bool RemoveDenounce(int Id)
        {
            var result = _context.Denounces.FirstOrDefault(x => x.Id == Id);
            if (result == null) return false;
            _context.Denounces.Remove(result);
            _context.SaveChanges();
            return true;
        }
    }
}
