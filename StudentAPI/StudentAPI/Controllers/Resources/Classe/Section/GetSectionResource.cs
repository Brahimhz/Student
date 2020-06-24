using StudentAPI.Controllers.Resources.Classe.Groupe;
using StudentAPI.Controllers.Resources.NiveauSpecialite;
using System.Collections.Generic;

namespace StudentAPI.Controllers.Resources.Classe.Section
{
    public class GetSectionResource
    {
        public GetSectionResource()
        {
            this.Groupes = new HashSet<GetGroupeResource>();
        }

        public int Id { get; set; }
        public string RefSection { get; set; }
        public virtual NiveauSpecialiteResource NiveauSpecialite { get; set; }
        public virtual ICollection<GetGroupeResource> Groupes { get; set; }
    }
}
