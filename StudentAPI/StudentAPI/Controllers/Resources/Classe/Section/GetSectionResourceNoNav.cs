using StudentAPI.Controllers.Resources.Classe.Groupe;
using StudentAPI.Controllers.Resources.NiveauSpecialite;
using StudentAPI.Controllers.Resources.Planning.PlanningSection;
using System.Collections.Generic;

namespace StudentAPI.Controllers.Resources.Section
{
    public class GetSectionResourceNoNav
    {

        public GetSectionResourceNoNav()
        {
            this.Groupes = new HashSet<GetGroupeResourceNoNav>();
            this.PlanningSections = new HashSet<GetPlanningSectionResourceNoNavS>();
        }

        public int Id { get; set; }
        public string RefSection { get; set; }

        public virtual NiveauSpecialiteResource NiveauSpecialite { get; set; }
        public virtual ICollection<GetGroupeResourceNoNav> Groupes { get; set; }
        public virtual ICollection<GetPlanningSectionResourceNoNavS> PlanningSections { get; set; }

    }
}
