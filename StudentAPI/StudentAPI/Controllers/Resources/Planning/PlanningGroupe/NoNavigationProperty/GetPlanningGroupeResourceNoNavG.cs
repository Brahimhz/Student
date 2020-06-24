using StudentAPI.Controllers.Resources.Planning.Planning;
using StudentAPI.Controllers.Resources.Planning.PlanningSection;

namespace StudentAPI.Controllers.Resources.Planning.PlanningGroupe
{
    public class GetPlanningGroupeResourceNoNavG : GetPlanningResource
    {
        public virtual GetPlanningSectionResourceNoNavP PlanningSection { get; set; }
    }
}
