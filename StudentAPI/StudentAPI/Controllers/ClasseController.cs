using Microsoft.AspNetCore.Mvc;
using StudentAPI.AppService.Contracts;
using StudentAPI.Controllers.Resources.Classe.Groupe;
using StudentAPI.Controllers.Resources.Classe.Section;
using StudentAPI.Controllers.Resources.Classe.SousGroupe;
using StudentAPI.Controllers.Resources.Query;
using StudentAPI.Controllers.Resources.Section;
using System.Threading.Tasks;

namespace StudentAPI.Controllers
{
    [Route("api/section")]
    [ApiController]
    public class ClasseController : ControllerBase
    {
        private readonly IClasseAppService _classAppService;

        public ClasseController(
            IClasseAppService classAppService
            )
        {
            _classAppService = classAppService;
        }




        [HttpGet]
        public async Task<QueryResultResource<GetSectionResource>> GetSections([FromQuery]ClasseQueryResource filterResource)
        {
            return await _classAppService.GetAllSections(filterResource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSection([FromBody]SetSectionResource sectionResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(await _classAppService.CreateSection(sectionResource));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSection(int id)
        {
            return Ok(await _classAppService.DeleteSection(id));
        }

        [HttpPost("{sectionId}/groupe")]
        public async Task<IActionResult> CreateGroupe(int sectionId, [FromBody]SetGroupeResource groupeResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            groupeResource.SectionId = sectionId;

            return Ok(await _classAppService.CreateGroupe(groupeResource));

        }

        [HttpDelete("groupe/{id}")]
        public async Task<IActionResult> DeleteGroupe(int id)
        {
            return Ok(await _classAppService.DeleteGroupe(id));
        }

        [HttpPost("groupe/{groupeId}/sgroupe")]
        public async Task<IActionResult> CreateSousGroupe(int groupeId, [FromBody]SetSousGroupeResource sGroupeResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            sGroupeResource.GroupeId = groupeId;
            return Ok(await _classAppService.CreateSousGroupe(sGroupeResource));

        }

        [HttpDelete("groupe/sgroupe/{id}")]
        public async Task<IActionResult> DeleteSousGroupe(int id)
        {
            return Ok(await _classAppService.DeleteSousGroupe(id));
        }


    }
}