using StudentAPI.Controllers.Resources.Classe.SousGroupe;
using StudentAPI.Controllers.Resources.Planning.PlanningGroupe;
using System.Collections.Generic;

namespace StudentAPI.Controllers.Resources.Classe.Groupe
{
    public class GetGroupeResourceNoNav
    {
        public GetGroupeResourceNoNav()
        {
            this.SousGroupes = new HashSet<GetSousGroupeResourceNoNav>();
            this.PlanningGroupes = new HashSet<GetPlanningGroupeResourceNoNavG>();
        }

        public int Id { get; set; }
        public string RefGroupe { get; set; }


        public virtual ICollection<GetSousGroupeResourceNoNav> SousGroupes { get; set; }
        public virtual ICollection<GetPlanningGroupeResourceNoNavG> PlanningGroupes { get; set; }
    }
}
