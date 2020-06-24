using StudentAPI.Controllers.Resources.Planning.PlanningGroupe;
using System.Collections.Generic;

namespace StudentAPI.Controllers.Resources.Planning.PlanningSection
{
    public class GetPlanningSectionResourceNoNavS
    {
        public GetPlanningSectionResourceNoNavS()
        {
            this.PlanningGroupes = new HashSet<GetPlanningGroupeResource>();
        }

        public string Type { get; set; }

        public virtual ICollection<GetPlanningGroupeResource> PlanningGroupes { get; set; }
    }
}
