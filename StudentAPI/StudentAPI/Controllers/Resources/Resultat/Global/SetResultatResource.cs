using System;

namespace StudentAPI.Controllers.Resources.Resultat.General
{
    public class SetResultatResource
    {
        public Nullable<double> MoyenneFinal { get; set; }
        public Nullable<double> TotalCredit { get; set; }
        public Nullable<double> Total { get; set; }
        public Nullable<double> TotalCoff { get; set; }
        public bool Acquit { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}
