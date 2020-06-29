using StudentAPI.Controllers.Resources.Classe.SousGroupe;
using StudentAPI.Controllers.Resources.Etudiant;
using StudentAPI.Controllers.Resources.NiveauSpecialite;
using StudentAPI.Controllers.Resources.Resultat;
using System;

namespace StudentAPI.Controllers.Resources.Parcour
{
    public class GetParcourResource
    {
        public int Id { get; set; }

        public DateTime LastUpdate { get; set; }


        public virtual GetEtudiantResource Etudient { get; set; }
        public virtual NiveauSpecialiteResource NiveauSpecialite { get; set; }
        public virtual GetSousGroupeResourceNoNav SousGroupe { get; set; }
        public virtual GetResultatResource Resultat { get; set; }
    }
}
