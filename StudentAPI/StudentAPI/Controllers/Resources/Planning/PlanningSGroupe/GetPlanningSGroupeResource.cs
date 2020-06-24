using StudentAPI.Controllers.Resources.Classe.SousGroupe;
using StudentAPI.Controllers.Resources.Planning.Planning;
using StudentAPI.Controllers.Resources.Planning.PlanningGroupe;

namespace StudentAPI.Controllers.Resources.Planning.PlanningSGroupe
{
    public class GetPlanningSGroupeResource : GetPlanningResource
    {

        public virtual GetPlanningGroupeResource PlanningGroupe { get; set; }
        public virtual GetSousGroupeResourceNoNav SousGroupe { get; set; }
    }
}
