using Microsoft.AspNetCore.Mvc;
using StudentAPI.AppService.Contracts;
using StudentAPI.Controllers.Resources.Etudiant;
using System;
using System.Threading.Tasks;

namespace StudentAPI.Controllers
{
    [Route("api/etudiants")]
    [ApiController]
    public class EtudiantController : ControllerBase
    {
        private readonly IEtudiantAppService _etudiantAppService;

        public EtudiantController(IEtudiantAppService etudiantAppService)
        {
            _etudiantAppService = etudiantAppService;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetEtudiant(int id)
        {

            var etudiantR = await _etudiantAppService.GetById(id);

            if (etudiantR == null)
                return NotFound();

            return Ok(etudiantR);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEtudiant([FromBody]SetEtudiantResource etudiantResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            etudiantResource.LastUpdate = DateTime.Now;

            return Ok(await _etudiantAppService.Add(etudiantResource));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtudiant(int id)
        {
            var etudiantR = await _etudiantAppService.GetById(id);

            if (etudiantR == null)
                return NotFound();

            _etudiantAppService.Remove(id);

            return Ok(id);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEtudiant(int id, [FromBody]SetEtudiantResource etudiantResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            etudiantResource.LastUpdate = DateTime.Now;

            return Ok(await _etudiantAppService.Update(id, etudiantResource));



        }

    }
}