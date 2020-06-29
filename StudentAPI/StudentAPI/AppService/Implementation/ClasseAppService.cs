using AutoMapper;
using StudentAPI.AppService.Contracts;
using StudentAPI.Controllers.Resources.Classe.Section;
using StudentAPI.Controllers.Resources.Query;
using StudentAPI.Controllers.Resources.Section;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;
using System.Threading.Tasks;

namespace StudentAPI.AppService.Implementation
{
    public class ClasseAppService : GenericAppService<Section, GetSectionResource, SetSectionResource>, IClasseAppService
    {
        private readonly IMapper _mapper;
        private readonly ISectionRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ClasseAppService(IMapper mapper, ISectionRepository repository, IUnitOfWork unitOfWork) : base(mapper, repository, unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<QueryResultResource<GetSectionResource>> GetAllSections(ClasseQueryResource filterResource)
        {
            var filter = _mapper.Map<ClasseQueryResource, ClasseQuery>(filterResource);

            var queryResult = await _repository.GetAll(filter);

            return _mapper.Map<QueryResult<Section>, QueryResultResource<GetSectionResource>>(queryResult);
        }
    }
}
