using SpiritLink.Models;

namespace SpiritLink.Services
{
    public class DataService : IDataService
    {
        private readonly AtonsuDbContext _context;

        public DataService(AtonsuDbContext context)
        {
            _context = context;
        }
    }
}
