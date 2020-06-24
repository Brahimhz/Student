using StudentAPI.Controllers.Resources.Classe.SousGroupe;
using StudentAPI.Controllers.Resources.Planning.Planning;

namespace StudentAPI.Controllers.Resources.Planning.PlanningSGroupe.NoNavigationProperty
{
    public class GetPlanningSGroupeResourceNoNavP : GetPlanningResource
    {
        public virtual GetSousGroupeResourceNoNav SousGroupe { get; set; }
    }
}
