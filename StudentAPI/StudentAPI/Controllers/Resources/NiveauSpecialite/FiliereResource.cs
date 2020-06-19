namespace StudentAPI.Controllers.Resources.NiveauSpecialite
{
    public class FiliereResource
    {
        public int Id { get; set; }
        public string NomFiliere { get; set; }
        public string DescriptionFiliere { get; set; }

        public virtual DomaineFormationResource DomaineFormation { get; set; }
    }
}
