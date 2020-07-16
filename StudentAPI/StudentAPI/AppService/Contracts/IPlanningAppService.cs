using StudentAPI.Controllers.Resources.Planning.Planning;
using StudentAPI.Controllers.Resources.Planning.PlanningSection;
using StudentAPI.Controllers.Resources.Planning.PlanningSGroupe.UpDown;
using System.Threading.Tasks;

namespace StudentAPI.AppService.Contracts
{
    public interface IPlanningAppService
    {
        //CreatePlannings
        Task<GetPlanningSectionResourceDown> CreatePlannings(SetPlanningSectionResource planningSectionResource);
        Task<GetPlanningResource> GetPlanning(int id);
        Task<GetPlanningSGroupeResourceUp> GetFullPlanning(int id);
        Task UpdatePlanning(int id);

    }
}
