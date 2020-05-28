using StudentAPI.Core.Models;
using StudentAPI.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.AppService
{
    public interface IAppService<T,TGetResource,TSetResource,TQueryObject>
        where TQueryObject : IQueryObject
    {
        Task<TGetResource> GetById(int id, bool eagerLoading = true);
        Task<QueryResult<TGetResource>> GetAll(TQueryObject filter);

        Task<TGetResource> Add(TSetResource etudiant);
        Task<TGetResource> Update(TSetResource etudiant);
        void Remove(TSetResource etudiant);
    }
}
