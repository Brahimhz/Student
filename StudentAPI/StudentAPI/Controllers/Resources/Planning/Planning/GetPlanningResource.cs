using StudentAPI.Controllers.Resources.InfoSeance;
using System;
using System.Collections.Generic;

namespace StudentAPI.Controllers.Resources.Planning.Planning
{
    public class GetPlanningResource
    {
        public GetPlanningResource()
        {
            this.InfoSeances = new HashSet<GetInfoSeanceResource>();
        }
        public int Id { get; set; }
        public DateTime LastUpdate { get; set; }
        public virtual ICollection<GetInfoSeanceResource> InfoSeances { get; set; }
    }
}
