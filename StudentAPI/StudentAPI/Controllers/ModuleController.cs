using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Controllers.Resources;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAPI.Controllers
{
    [Route("api/module")]
    public class ModuleController : ControllerBase
    {
        private IMapper mapper;
        private IModuleRepository repository;
        private IUnitOfWork unitOfWork;

        public ModuleController(IMapper mapper, IModuleRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateModule([FromBody]ModuleResource moduleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            var module = mapper.Map<ModuleResource, Module>(moduleResource);
            module.LastUpdate = DateTime.Now;
            module.AbvNom = module.getAbvName();

            repository.Add(module);
            await unitOfWork.CompleteAsync();

            module = await repository.GetModule(module.Id);
            var result = mapper.Map<Module, ModuleResource>(module);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModule(int id)
        {
            var module = await repository.GetModule(id, eagerLoading: false);

            if (module == null)
                return NotFound();

            repository.Remove(module);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModule(int id, [FromBody]ModuleResource moduleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var module = await repository.GetModule(id, eagerLoading: false);

            if (module == null)
                return NotFound();

            mapper.Map<ModuleResource, Module>(moduleResource, module);
            module.LastUpdate = DateTime.Now;
            module.AbvNom = module.getAbvName();

            await unitOfWork.CompleteAsync();

            module = await repository.GetModule(module.Id);
            var result = mapper.Map<Module, ModuleResource>(module);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModule(int id)
        {

            var module = await repository.GetModule(id);

            if (module == null)
                return NotFound();

            var moduleR = mapper.Map<Module, ModuleResource>(module);

            return Ok(moduleR);
        }

        [HttpGet]
        public async Task<IEnumerable<ModuleResource>> GetModules(string speciality)
        {
            var queryResult = await repository.GetModules(speciality);
            return mapper.Map<IEnumerable<Module>, IEnumerable<ModuleResource>>(queryResult);
        }

    }
}