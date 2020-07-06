using System;
using System.Collections.Generic;

namespace StudentAPI.Controllers.Resources.Resultat
{
    public class GetResultatResource
    {
        public GetResultatResource()
        {
            this.ResultatUnites = new HashSet<GetResultatUniteResource>();
        }

        public int Id { get; set; }
        public Nullable<double> MoyenneFinal { get; set; }
        public Nullable<double> TotalCredit { get; set; }
        public Nullable<double> Total { get; set; }
        public Nullable<double> TotalCoff { get; set; }
        public bool Acquit { get; set; }

        public DateTime LastUpdate { get; set; }

        public virtual ICollection<GetResultatUniteResource> ResultatUnites { get; set; }
    }
}
