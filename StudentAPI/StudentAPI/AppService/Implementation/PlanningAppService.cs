using StudentAPI.AppService.Contracts;
using StudentAPI.Controllers.Resources.InfoSeance;
using StudentAPI.Controllers.Resources.Planning.PlanningSection;
using System;
using System.Threading.Tasks;

namespace StudentAPI.AppService.Implementation
{
    public class PlanningAppService : IPlanningAppService
    {

        public Task<GetPlanningSectionResourceDown> CreatePlannings(SetPlanningSectionResource planningSectionResource)
        {
            throw new NotImplementedException();
        }

        public Task<GetInfoSeanceResource> Add(SetInfoSeanceResource infoSeanceResource)
        {
            throw new NotImplementedException();
        }


        public Task<int> Delete(int idInSe)
        {
            throw new NotImplementedException();
        }

        public Task<GetInfoSeanceResource> Update(int id, SetInfoSeanceResource infoSeanceResource)
        {
            throw new NotImplementedException();
        }
    }
}
