using Voolt.Test.Data.Interfaces;
using Voolt.Test.Domain;

namespace Voolt.Test.Data
{
    public class AdRepository : IAdRepository
    {
        private readonly AdContext _context;

        public AdRepository(AdContext context)
        {
            _context = context;
        }

        public IEnumerable<Ad> GetAll()
        {
            return _context.Ads.ToList();
        }

        public void Create(Ad item)
        {
            _context.Ads.Add(item);
            _context.SaveChanges();
        }

        public void Update(Ad item)
        {
            _context.Ads.Update(item);
            _context.SaveChanges();
        }
    }
}