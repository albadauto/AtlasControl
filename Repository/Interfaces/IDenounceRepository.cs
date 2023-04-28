using AtlasControl.Models;

namespace AtlasControl.Repository.Interfaces
{
    public interface IDenounceRepository
    {
        public List<DenouncesModel> GetAllDenounces();
    }
}
