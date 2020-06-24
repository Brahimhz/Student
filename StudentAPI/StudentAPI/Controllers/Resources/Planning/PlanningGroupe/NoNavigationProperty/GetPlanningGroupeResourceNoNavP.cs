using StudentAPI.Controllers.Resources.Classe.Groupe;
using StudentAPI.Controllers.Resources.Planning.Planning;

namespace StudentAPI.Controllers.Resources.Planning.PlanningGroupe.NoNavigationProperty
{
    public class GetPlanningGroupeResourceNoNavP : GetPlanningResource
    {
        public virtual GetGroupeResourceNoNav Groupe { get; set; }

    }
}
