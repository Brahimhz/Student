using StudentAPI.Controllers.Resources.Planning.Planning;

namespace StudentAPI.Controllers.Resources.Planning.PlanningGroupe
{
    public class SetPlanningGroupeResource : SetPlanningResource
    {
        public int PlanningSectionId { get; set; }
        public int GroupeId { get; set; }

    }
}
