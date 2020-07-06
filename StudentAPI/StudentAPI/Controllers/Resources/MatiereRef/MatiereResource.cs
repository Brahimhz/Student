namespace StudentAPI.Controllers.Resources.MatiereRef
{
    public class MatiereResource
    {

        public int Id { get; set; }
        public double Coefficient { get; set; }
        public double Credit { get; set; }
        public int NiveauSpecialiteId { get; set; }

        public virtual MatiereRefResourceNoNav MatiereRef { get; set; }
    }
}
