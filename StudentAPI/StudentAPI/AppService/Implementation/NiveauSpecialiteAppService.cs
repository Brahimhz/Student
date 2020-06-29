using AutoMapper;
using StudentAPI.AppService.Contracts;
using StudentAPI.Controllers.Resources.NiveauSpecialite;
using StudentAPI.Controllers.Resources.Query;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;
using System.Threading.Tasks;

namespace StudentAPI.AppService.Implementation
{
    public class NiveauSpecialiteAppService : GenericAppService<NiveauSpecialite, NiveauSpecialiteResource, NiveauSpecialiteResource>, INiveauSpecialiteAppService
    {
        private readonly IMapper _mapper;
        private readonly INiveauSpecialiteRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public NiveauSpecialiteAppService(IMapper mapper, INiveauSpecialiteRepository repository, IUnitOfWork unitOfWork) : base(mapper, repository, unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<QueryResultResource<NiveauSpecialiteResource>> GetAll(NiveauSpecialiteQueryResource filterResource)
        {
            var filter = _mapper.Map<NiveauSpecialiteQueryResource, NiveauSpecialiteQuery>(filterResource);

            var queryResult = await _repository.GetAll(filter);

            return _mapper.Map<QueryResult<NiveauSpecialite>, QueryResultResource<NiveauSpecialiteResource>>(queryResult);
        }
    }
}
