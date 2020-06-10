using AutoMapper;
using StudentAPI.AppService.Contracts;
using StudentAPI.Controllers.Resources.DocumentPartage;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;

namespace StudentAPI.AppService.Implementation
{
    public class DocumentPartageAppService : GenericAppService<DocumentPartage, GetDocumentPartageResource, SetDocumentPartageResource, RequestQuery>, IDocumentPartageAppService
    {
        private readonly IMapper _mapper;
        private readonly IDocumentPartageRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DocumentPartageAppService(IMapper mapper, IDocumentPartageRepository repository, IUnitOfWork unitOfWork) : base(mapper, repository, unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
    }
}
