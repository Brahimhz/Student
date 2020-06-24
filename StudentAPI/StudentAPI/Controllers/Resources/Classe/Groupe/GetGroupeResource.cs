using StudentAPI.Controllers.Resources.Classe.SousGroupe;
using System.Collections.Generic;

namespace StudentAPI.Controllers.Resources.Classe.Groupe
{
    public class GetGroupeResource
    {
        public GetGroupeResource()
        {
            this.SousGroupes = new HashSet<GetSousGroupeResource>();
        }

        public int Id { get; set; }
        public string RefGroupe { get; set; }


        public virtual ICollection<GetSousGroupeResource> SousGroupes { get; set; }
    }
}
