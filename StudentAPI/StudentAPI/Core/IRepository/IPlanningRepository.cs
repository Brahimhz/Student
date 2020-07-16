using StudentAPI.Core.Models;
using System.Threading.Tasks;

namespace StudentAPI.Core.IRepository
{
    public interface IPlanningRepository
    {
        Task<Planning> GetPlanningById(int id);
        Task<PlanningSGroupe> GetFullPlanningById(int id);

        Task<Section> GetFullBySectionId(int sectionId);

    }
}
