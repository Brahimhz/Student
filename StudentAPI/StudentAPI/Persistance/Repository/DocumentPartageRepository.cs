using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;

namespace StudentAPI.Persistance.Repository
{
    public class DocumentPartageRepository : GenericRepository<DocumentPartage>, IDocumentPartageRepository
    {
        private readonly StudentDbContext _context;

        public DocumentPartageRepository(StudentDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
