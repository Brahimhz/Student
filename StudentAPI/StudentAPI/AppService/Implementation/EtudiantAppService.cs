using AutoMapper;
using StudentAPI.AppService.Contracts;
using StudentAPI.Controllers.Resources.Etudiant;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAPI.AppService.Implementation
{
    public class EtudiantAppService : GenericAppService<Etudiant, GetEtudiantResource, SetEtudiantResource>, IEtudiantAppService
    {
        private readonly IMapper _mapper;
        private readonly IEtudiantRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public EtudiantAppService(IMapper mapper, IEtudiantRepository repository, IUnitOfWork unitOfWork) : base(mapper, repository, unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetEtudiantResource>> GetAll()
        {
            return _mapper.Map<IEnumerable<Etudiant>, IEnumerable<GetEtudiantResource>>(await _repository.GetAll());
        }

    }
}
