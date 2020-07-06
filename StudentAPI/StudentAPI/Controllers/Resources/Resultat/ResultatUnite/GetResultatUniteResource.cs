using StudentAPI.Controllers.Resources.MatiereRef;
using StudentAPI.Controllers.Resources.Resultat.ResultatMatiere;
using System;
using System.Collections.Generic;

namespace StudentAPI.Controllers.Resources.Resultat
{
    public class GetResultatUniteResource
    {
        public GetResultatUniteResource()
        {
            this.ResultatMatieres = new HashSet<GetResultatMatiereResource>();
        }

        public int Id { get; set; }
        public Nullable<double> MoyenneUnite { get; set; }
        public Nullable<double> CreditUnite { get; set; }
        public Nullable<double> TotalCoff { get; set; }
        public Nullable<double> TotalUnite { get; set; }


        public bool Acquit { get; set; }


        public virtual UnitePedagogiqueResource UnitePedagogique { get; set; }
        public virtual ICollection<GetResultatMatiereResource> ResultatMatieres { get; set; }
    }
}
