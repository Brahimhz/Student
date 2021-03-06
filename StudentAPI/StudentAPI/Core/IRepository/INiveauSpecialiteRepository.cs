﻿using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;
using System.Threading.Tasks;

namespace StudentAPI.Core.IRepository
{
    public interface INiveauSpecialiteRepository : IGenericRepository<NiveauSpecialite>
    {
        Task<QueryResult<NiveauSpecialite>> GetAll(NiveauSpecialiteQuery documentPartageQuery);
    }
}
