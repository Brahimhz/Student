using Microsoft.AspNetCore.Mvc;
using StudentAPI.AppService.Contracts;
using StudentAPI.Controllers.Resources.Parcour;
using StudentAPI.Controllers.Resources.Query;
using System;
using System.Threading.Tasks;

namespace StudentAPI.Controllers
{
    [Route("api/parcour")]
    [ApiController]
    public class ParcourController : ControllerBase
    {
        private readonly IParcourAppService _appService;

        public ParcourController(IParcourAppService appService)
        {
            _appService = appService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateParcour([FromBody]SetParcourResource parcourResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            parcourResource.LastUpdate = DateTime.Now;

            return Ok(await _appService.Add(parcourResource));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParcour(int id)
        {
            var parcourR = await _appService.GetById(id);

            if (parcourR == null)
                return NotFound();

            return Ok(await _appService.Remove(id));

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParcour(int id, [FromBody]SetParcourResource parcourResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            parcourResource.LastUpdate = DateTime.Now;

            return Ok(await _appService.Update(id, parcourResource));



        }

        [HttpGet]
        public async Task<QueryResultResource<GetParcourResource>> GetParcours([FromQuery]ParcourQueryResource filterResource)
        {
            return await _appService.GetAll(filterResource);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetParcour(int id)
        {

            var parcourR = await _appService.GetByIdFull(id);

            if (parcourR == null)
                return NotFound();

            return Ok(parcourR);
        }

    }
}