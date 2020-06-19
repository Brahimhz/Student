namespace StudentAPI.Controllers.Resources.NiveauSpecialite
{
    public class NiveauSpecialiteResource
    {
        public int Id { get; set; }
        public string Niveau { get; set; }
        public virtual SpecialiteResource Specialite { get; set; }

    }
}
