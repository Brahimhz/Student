using StudentAPI.Controllers.Resources.Resultat;
using StudentAPI.Controllers.Resources.Resultat.ResultatMatiere;
using System.Threading.Tasks;

namespace StudentAPI.AppService.Contracts
{
    public interface IResultatAppService
    {
        Task<GetResultatResource> GetByIdFull(int id);
        Task<GetResultatResource> Add(int idParcour);
        Task<GetResultatResource> Update(int idResultat, int idResultatUnite, int idResultatMatiere, SetResultatMatiereResource resultatMatiereResource);

    }
}
