using AtlasControl.Models;

namespace AtlasControl.Repository.Interfaces
{
    public interface IDocumentationRepository
    {
        public List<DocumentationModel> GetAllDocumentations();
    }
}
