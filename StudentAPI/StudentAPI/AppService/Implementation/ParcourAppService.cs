using AutoMapper;
using StudentAPI.AppService.Contracts;
using StudentAPI.Controllers.Resources.Parcour;
using StudentAPI.Controllers.Resources.Query;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;
using System.Threading.Tasks;

namespace StudentAPI.AppService.Implementation
{
    public class ParcourAppService : GenericAppService<Parcour, GetParcourResource, SetParcourResource>, IParcourAppService
    {
        private readonly IMapper _mapper;
        private readonly IParcourRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public ParcourAppService(IMapper mapper, IParcourRepository repository, IUnitOfWork unitOfWork) : base(mapper, repository, unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<QueryResultResource<GetParcourResource>> GetAll(ParcourQueryResource filterResource)
        {
            var filter = _mapper.Map<ParcourQueryResource, ParcourQuery>(filterResource);

            var queryResult = await _repository.GetAll(filter);

            return _mapper.Map<QueryResult<Parcour>, QueryResultResource<GetParcourResource>>(queryResult);
        }

        public async Task<GetParcourResource> GetByIdFull(int id)
        {
            return _mapper.Map<Parcour, GetParcourResource>(await _repository.GetByIdFull(id));
        }
    }
}
