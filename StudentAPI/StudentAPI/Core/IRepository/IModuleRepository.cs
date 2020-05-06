using StudentAPI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAPI.Core.IRepository
{
    public interface IModuleRepository
    {
        Task<Module> GetModule(int id, bool eagerLoading = true);
        Task<IEnumerable<Module>> GetModules(string speciality);

        void Add(Module module);
        void Remove(Module module);

    }
}
