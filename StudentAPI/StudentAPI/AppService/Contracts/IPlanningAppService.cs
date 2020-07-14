using StudentAPI.Controllers.Resources.InfoSeance;
using StudentAPI.Controllers.Resources.Planning.PlanningSection;
using System.Threading.Tasks;

namespace StudentAPI.AppService.Contracts
{
    public interface IPlanningAppService
    {
        //CreatePlannings
        Task<GetPlanningSectionResourceDown> CreatePlannings(SetPlanningSectionResource planningSectionResource);

        //UpdatePlannings
        Task<GetInfoSeanceResource> Add(SetInfoSeanceResource infoSeanceResource);
        Task<GetInfoSeanceResource> Update(int id, SetInfoSeanceResource infoSeanceResource);
        Task<int> Delete(int idInSe);
    }
}
