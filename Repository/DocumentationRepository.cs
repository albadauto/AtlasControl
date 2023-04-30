using AtlasControl.Context;
using AtlasControl.Models;
using AtlasControl.Repository.Interfaces;

namespace AtlasControl.Repository
{
    public class DocumentationRepository : IDocumentationRepository
    {

        private readonly DatabaseContext _context;
        public DocumentationRepository(DatabaseContext context)
        {
            _context = context;          
        }
        public List<DocumentationModel> GetAllDocumentations()
        {
            List<DocumentationModel> model = new List<DocumentationModel>();
            var result = (from i in _context.Documentations
                          join a in _context.Associations
                          on i.AssociationsId equals a.Id
                          where a.Status == "P"
                          select new { i.doc_uri }).ToList();
            foreach (var modelItem in result) 
            {
                model.Add(new DocumentationModel
                {
                    doc_uri = modelItem.doc_uri
                });
            }

            return model;

        }
    }
}
