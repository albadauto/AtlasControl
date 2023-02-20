using AtlasControl.Models;

namespace AtlasControl.Repository.Interfaces
{
    public interface IAssociationRepository
    {
        public List<AssociationsModel> GetAllAssociations();
        public AssociationsModel SetAssociationToAccept(int idAssociation);
    }
}
