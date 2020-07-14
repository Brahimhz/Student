using StudentAPI.Controllers.Resources.Planning.Planning;
using StudentAPI.Controllers.Resources.Planning.PlanningSection.NoNavigationProperty;

namespace StudentAPI.Controllers.Resources.Planning.PlanningGroupe.NoNavigationProperty
{
    public class GetPlanningGroupeResourceUp : GetPlanningResource
    {
        public GetPlanningSectionResourceUp PlanningSection { get; set; }
    }
}
