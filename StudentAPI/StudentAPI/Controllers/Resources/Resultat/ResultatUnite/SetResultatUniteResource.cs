using System;

namespace StudentAPI.Controllers.Resources.Resultat.ResultatUnite
{
    public class SetResultatUniteResource
    {

        public Nullable<double> MoyenneUnite { get; set; }
        public Nullable<double> CreditUnite { get; set; }
        public Nullable<double> TotalCoff { get; set; }
        public Nullable<double> TotalUnite { get; set; }


        public int UnitePedagogiqueId { get; set; }
        public int ResultatId { get; set; }
        public bool Acquit { get; set; }


    }
}
