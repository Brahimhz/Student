using StudentAPI.Controllers.Resources.Classe.Groupe;
using StudentAPI.Controllers.Resources.Planning.Planning;
using StudentAPI.Controllers.Resources.Planning.PlanningSection;
using StudentAPI.Controllers.Resources.Planning.PlanningSGroupe;
using System.Collections.Generic;

namespace StudentAPI.Controllers.Resources.Planning.PlanningGroupe
{
    public class GetPlanningGroupeResource : GetPlanningResource
    {
        public GetPlanningGroupeResource()
        {
            this.PlanningSGroupes = new HashSet<GetPlanningSGroupeResource>();
        }

        public virtual GetPlanningSectionResource PlanningSection { get; set; }
        public virtual GetGroupeResourceNoNav Groupe { get; set; }
        public virtual ICollection<GetPlanningSGroupeResource> PlanningSGroupes { get; set; }
    }
}
