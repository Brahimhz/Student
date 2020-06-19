namespace StudentAPI.Controllers.Resources.NiveauSpecialite
{
    public class SpecialiteResource
    {
        public int Id { get; set; }
        public string NomSpecialite { get; set; }
        public string Durée { get; set; }

        public virtual FiliereResource Filiere { get; set; }
    }
}
