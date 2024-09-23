using Voolt.Test.Domain;

namespace Voolt.Test.Data.Interfaces
{
    public interface IAdRepository
    {
        IEnumerable<Ad> GetAll();
        void Create(Ad item);
        void Update(Ad item);
    }
}
