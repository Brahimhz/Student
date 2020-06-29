using StudentAPI.Controllers.Resources.Personne;

namespace StudentAPI.Controllers.Resources.Etudiant
{
    public class GetEtudiantResource : GetPersonneResourceNoNav
    {
        public string Matricule { get; set; }
    }
}
