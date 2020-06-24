﻿using StudentAPI.Controllers.Resources.Classe.Section;
using StudentAPI.Controllers.Resources.Query;
using StudentAPI.Controllers.Resources.Section;
using StudentAPI.Core.Models;
using System.Threading.Tasks;

namespace StudentAPI.AppService.Contracts
{
    public interface ISectionAppService : IGenericAppService<Section, GetSectionResource, SetSectionResource>
    {
        Task<QueryResultResource<GetSectionResource>> GetAllSections(SectionQueryResource filterResource);
    }
}
