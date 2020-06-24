using StudentAPI.Controllers.Resources.Planning.Planning;

namespace StudentAPI.Controllers.Resources.Planning.PlanningSGroupe
{
    public class SetPlanningSGroupeResource : GetPlanningResource
    {
        public int PlanningGroupeId { get; set; }
        public int SousGroupeId { get; set; }

    }
}
