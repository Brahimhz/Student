using StudentAPI.Controllers.Resources.Etudiant;
using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.AppService.Contracts
{
    public interface IEtudiantAppService : IAppService<Etudiant,GetEtudiantResource, SetEtudiantResource, RequestQuery>
    {
        Task<GetEtudiantResource> GetByMatricule(string matricule);
    }
}
