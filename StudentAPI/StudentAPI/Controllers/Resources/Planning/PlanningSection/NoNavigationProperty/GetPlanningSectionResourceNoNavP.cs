using StudentAPI.Controllers.Resources.Planning.Planning;
using StudentAPI.Controllers.Resources.Section;

namespace StudentAPI.Controllers.Resources.Planning.PlanningSection
{
    public class GetPlanningSectionResourceNoNavP : GetPlanningResource
    {
        public string Type { get; set; }

        public virtual GetSectionResourceNoNav Section { get; set; }
    }
}
