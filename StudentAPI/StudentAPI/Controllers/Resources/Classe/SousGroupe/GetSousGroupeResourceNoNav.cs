using StudentAPI.Controllers.Resources.Planning.PlanningSGroupe;
using System.Collections.Generic;

namespace StudentAPI.Controllers.Resources.Classe.SousGroupe
{
    public class GetSousGroupeResourceNoNav
    {
        public GetSousGroupeResourceNoNav()
        {
            this.PlanningSGroupes = new HashSet<GetPlanningSGroupeResourceNoNavG>();
        }

        public int Id { get; set; }
        public string RefSousGroupe { get; set; }
        public virtual ICollection<GetPlanningSGroupeResourceNoNavG> PlanningSGroupes { get; set; }
    }
}
