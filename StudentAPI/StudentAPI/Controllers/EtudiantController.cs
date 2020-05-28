using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.AppService.Contracts;
using StudentAPI.Controllers.Resources.Etudiant;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
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
        public async Task<IActionResult> Get(int id)
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

            var result = _etudiantAppService.Add(etudiantResource);
           
            return Ok(result);
        }
    }
}