using StudentAPI.Controllers.Resources.Planning.Planning;
using StudentAPI.Controllers.Resources.Planning.PlanningGroupe;
using StudentAPI.Controllers.Resources.Section;
using System.Collections.Generic;

namespace StudentAPI.Controllers.Resources.Planning.PlanningSection
{
    public class GetPlanningSectionResource : GetPlanningResource
    {
        public GetPlanningSectionResource()
        {
            this.PlanningGroupes = new HashSet<GetPlanningGroupeResource>();
        }

        public string Type { get; set; }

        public virtual GetSectionResourceNoNav Section { get; set; }
        public virtual ICollection<GetPlanningGroupeResource> PlanningGroupes { get; set; }
    }
}
