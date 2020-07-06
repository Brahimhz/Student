using Microsoft.AspNetCore.Mvc;
using StudentAPI.AppService.Contracts;
using StudentAPI.Controllers.Resources.Resultat.ResultatMatiere;
using System.Threading.Tasks;

namespace StudentAPI.Controllers
{
    [Route("api/parcour/{parcourId}/resultat")]
    [ApiController]
    public class ResultatController : ControllerBase
    {
        private readonly IResultatAppService _appService;

        public ResultatController(IResultatAppService appService)
        {
            _appService = appService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateResultat(int parcourId)
        {
            return Ok(await _appService.Add(parcourId));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResultat(int id)
        {
            return Ok(await _appService.GetByIdFull(id));
        }

        [HttpPut("{idResultat}/{idResultatUnite}/{idResultatMatiere}")]
        public async Task<IActionResult> UpdateResultat(int idResultat, int idResultatUnite, int idResultatMatiere, [FromBody]SetResultatMatiereResource resultatMatiereResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _appService.Update(idResultat, idResultatUnite, idResultatMatiere, resultatMatiereResource));
        }
    }
}