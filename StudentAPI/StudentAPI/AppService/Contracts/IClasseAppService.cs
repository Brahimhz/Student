using StudentAPI.Controllers.Resources.Classe.Groupe;
using StudentAPI.Controllers.Resources.Classe.Section;
using StudentAPI.Controllers.Resources.Classe.SousGroupe;
using StudentAPI.Controllers.Resources.Query;
using StudentAPI.Controllers.Resources.Section;
using System.Threading.Tasks;

namespace StudentAPI.AppService.Contracts
{
    public interface IClasseAppService
    {
        Task<QueryResultResource<GetSectionResource>> GetAllSections(ClasseQueryResource filterResource);

        Task<GetSectionResource> CreateSection(SetSectionResource sectionResource);
        Task<int> DeleteSection(int id);

        Task<GetGroupeResource> CreateGroupe(SetGroupeResource groupeResource);
        Task<int> DeleteGroupe(int id);

        Task<GetSousGroupeResource> CreateSousGroupe(SetSousGroupeResource sGroupeResource);
        Task<int> DeleteSousGroupe(int id);
    }
}
