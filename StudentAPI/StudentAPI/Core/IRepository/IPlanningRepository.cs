using StudentAPI.Core.Models;
using System.Threading.Tasks;

namespace StudentAPI.Core.IRepository
{
    public interface IPlanningRepository
    {
        Task<PlanningSection> GetPlanningSectionById(int id);
        Task<PlanningGroupe> GetPlanningGroupeById(int id);
        Task<PlanningSGroupe> GetPlanningSGroupeById(int id);
        Task<PlanningSGroupe> GetFullPlanningById(int id);

        Task<Section> GetBySectionId(int sectionId);

    }
}
