using StudentAPI.Controllers.Resources.MatiereRef;
using System;

namespace StudentAPI.Controllers.Resources.Resultat.ResultatMatiere
{
    public class GetResultatMatiereResource
    {
        public int Id { get; set; }
        public Nullable<double> NoteControl { get; set; }
        public Nullable<double> NoteExamen { get; set; }
        public Nullable<double> MoyenneMatiere { get; set; }
        public Nullable<double> TotalMatiere { get; set; }

        public Nullable<double> CreditMatiere { get; set; }
        public bool Acquit { get; set; }
        public virtual MatiereResource Matiere { get; set; }
    }
}
