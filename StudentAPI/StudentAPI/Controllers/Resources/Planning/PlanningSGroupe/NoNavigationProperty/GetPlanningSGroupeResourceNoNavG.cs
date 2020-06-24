using StudentAPI.Controllers.Resources.Planning.Planning;
using StudentAPI.Controllers.Resources.Planning.PlanningGroupe;

namespace StudentAPI.Controllers.Resources.Planning.PlanningSGroupe
{
    public class GetPlanningSGroupeResourceNoNavG : GetPlanningResource
    {
        public virtual GetPlanningGroupeResourceNoNavG PlanningGroupe { get; set; }
    }
}
