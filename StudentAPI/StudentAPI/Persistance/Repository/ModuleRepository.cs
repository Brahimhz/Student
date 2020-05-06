using Microsoft.EntityFrameworkCore;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Persistance.Repository
{
    public class ModuleRepository : IModuleRepository
    {
        private StudentDbContext context;

        public ModuleRepository(StudentDbContext context)
        {
            this.context = context;
        }


        public void Add(Module module)
        {
            context.Modules.Add(module);
        }

        public async Task<Module> GetModule(int id, bool eagerLoading = true)
        {
            return await context.Modules.FindAsync(id);
        }

        public async Task<IEnumerable<Module>> GetModules(string speciality)
        {
            if(string.IsNullOrEmpty(speciality))
                return await context.Modules.ToListAsync();


            return await context.Modules.Where(m => m.Speciality.Equals(speciality)).ToListAsync();
        }

        public void Remove(Module module)
        {
            context.Modules.Remove(module);
        }
    }
}
