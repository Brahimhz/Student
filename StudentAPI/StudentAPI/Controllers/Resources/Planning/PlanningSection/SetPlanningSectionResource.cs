using StudentAPI.Controllers.Resources.Planning.Planning;

namespace StudentAPI.Controllers.Resources.Planning.PlanningSection
{
    public class SetPlanningSectionResource : SetPlanningResource
    {

        public string Type { get; set; }
        public int SectionId { get; set; }

    }
}
