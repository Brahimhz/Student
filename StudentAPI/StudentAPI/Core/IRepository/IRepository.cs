using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;
using StudentAPI.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Core.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id, bool eagerLoading = true);
        Task<QueryResult<T>> GetAll(IQueryObject filter);

        void Add(T etudiant);
        void Remove(T etudiant);
    }
}
