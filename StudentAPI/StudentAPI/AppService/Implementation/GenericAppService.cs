using AutoMapper;
using StudentAPI.Core.IRepository;
using System.Threading.Tasks;

namespace StudentAPI.AppService.Implementation
{
    public class GenericAppService<T, TGetResource, TSetResource> : IGenericAppService<T, TGetResource, TSetResource>
        where T : class
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public GenericAppService(IMapper mapper, IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TGetResource> GetById(int id)
        {
            return _mapper.Map<T, TGetResource>(await _repository.GetById(id));
        }

        public async Task<TGetResource> Add(TSetResource entityResource)
        {
            var entity = _mapper.Map<TSetResource, T>(entityResource);
            _repository.Add(entity);

            await _unitOfWork.CompleteAsync();

            //etudiant = await _repository.GetById(etudiant.Id);

            return _mapper.Map<T, TGetResource>(entity);
        }

        public async Task<TGetResource> Update(int id, TSetResource entity)
        {
            var oldEntity = await _repository.GetById(id);

            if (oldEntity == null)
                return _mapper.Map<T, TGetResource>(oldEntity);


            _mapper.Map<TSetResource, T>(entity, oldEntity);
            await _unitOfWork.CompleteAsync();


            return _mapper.Map<T, TGetResource>(await _repository.GetById(id));
        }

        public async Task<int> Remove(int id)
        {
            _repository.Remove(id);
            await _unitOfWork.CompleteAsync();
            return id;
        }
    }
}
