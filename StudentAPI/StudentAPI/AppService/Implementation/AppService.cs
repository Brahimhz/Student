using AutoMapper;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;
using StudentAPI.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.AppService.Implementation
{
    public abstract class AppService<T,TGetResource,TSetResource,TQueryObject>:IAppService<T,TGetResource,TSetResource,TQueryObject>
        where T:class
        where TQueryObject : IQueryObject
    {
        private readonly IMapper _mapper;
        private readonly IRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AppService(IMapper mapper, IRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<QueryResult<TGetResource>> GetAll(TQueryObject filter)
        {
            return _mapper.Map<QueryResult<T>, QueryResult<TGetResource>>(await _repository.GetAll(filter));
        }
        public Task<TGetResource> GetById(int id, bool eagerLoading = true)
        {
            throw new NotImplementedException();
        }

        public async Task<TGetResource> Add(TSetResource entityResource)
        {
            var entity = _mapper.Map<TSetResource, T>(entityResource);

            _repository.Add(entity);

            await _unitOfWork.CompleteAsync();

            //etudiant = await _repository.GetById(etudiant.Id);

            return _mapper.Map<T, TGetResource>(entity);
        }
        public Task<TGetResource> Update(TSetResource etudiant)
        {
            throw new NotImplementedException();
        }
        public void Remove(TSetResource etudiant)
        {
            throw new NotImplementedException();
        }        
    }
}
