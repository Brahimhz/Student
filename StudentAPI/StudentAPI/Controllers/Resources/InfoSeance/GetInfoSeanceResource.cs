using StudentAPI.Controllers.Resources.MatiereRef;
using StudentAPI.Controllers.Resources.Personne;
using StudentAPI.Controllers.Resources.Planning;
using StudentAPI.Controllers.Resources.Salle;

namespace StudentAPI.Controllers.Resources.InfoSeance
{
    public class GetInfoSeanceResource
    {
        public int id { get; set; }
        public string Type { get; set; }


        public virtual SalleResource Salle { get; set; }
        public virtual MatiereResource Matiere { get; set; }
        public virtual EnseignantResource Enseignat { get; set; }
        public virtual SeanceResource Seance { get; set; }
        public virtual int JourneeId { get; set; }
    }
}
