namespace StudentAPI.Controllers.Resources.Salle
{
    public class SalleResource
    {
        public int Id { get; set; }
        public string TypeSalle { get; set; }
        public string RefSalle { get; set; }
        public int BlocId { get; set; }

        public virtual BlocResource Bloc { get; set; }
    }
}
