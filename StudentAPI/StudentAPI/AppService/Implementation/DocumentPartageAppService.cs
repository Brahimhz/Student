using AutoMapper;
using StudentAPI.AppService.Contracts;
using StudentAPI.Controllers.Resources.DocumentPartage;
using StudentAPI.Controllers.Resources.Query;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;
using System.Threading.Tasks;

namespace StudentAPI.AppService.Implementation
{
    public class DocumentPartageAppService : GenericAppService<DocumentPartage, GetDocumentPartageResource, SetDocumentPartageResource, DocumentPartageQuery>, IDocumentPartageAppService
    {
        private readonly IMapper _mapper;
        private readonly IDocumentPartageRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDocumentFileAppService _appService;

        public DocumentPartageAppService(IMapper mapper, IDocumentPartageRepository repository, IUnitOfWork unitOfWork, IDocumentFileAppService appService) : base(mapper, repository, unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
            _appService = appService;
        }

        public async Task<QueryResultResource<GetDocumentPartageResource>> GetAllDP(DocumentPartageQueryResource filterResource)
        {
            var filter = _mapper.Map<DocumentPartageQueryResource, DocumentPartageQuery>(filterResource);

            var queryResult = await _repository.GetAll(filter);

            return _mapper.Map<QueryResult<DocumentPartage>, QueryResultResource<GetDocumentPartageResource>>(queryResult);
        }

        public async Task<int> RemoveWithFile(int id)
        {
            await _appService.DeleteFile(id);
            _repository.Remove(id);
            await _unitOfWork.CompleteAsync();

            return id;
        }

        public async Task<GetDocumentPartageResource> GetByIdFull(int id)
        {
            return _mapper.Map<DocumentPartage, GetDocumentPartageResource>(await _repository.GetByIdFull(id));
        }
    }
}
