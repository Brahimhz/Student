using Microsoft.AspNetCore.Mvc;
using StudentAPI.AppService;
using StudentAPI.AppService.Contracts;
using StudentAPI.Controllers.Resources.Classe.Groupe;
using StudentAPI.Controllers.Resources.Classe.Section;
using StudentAPI.Controllers.Resources.Classe.SousGroupe;
using StudentAPI.Controllers.Resources.Query;
using StudentAPI.Controllers.Resources.Section;
using StudentAPI.Core.Models;
using System.Threading.Tasks;

namespace StudentAPI.Controllers
{
    [Route("api/section")]
    [ApiController]
    public class ClasseController : ControllerBase
    {
        private readonly IClasseAppService _sectionAppService;
        private readonly IGenericAppService<Groupe, GetGroupeResource, SetGroupeResource> _groupeAppService;
        private readonly IGenericAppService<SousGroupe, GetSousGroupeResource, SetSousGroupeResource> _sGroupeAppService;

        public ClasseController(
            IClasseAppService sectionAppService,
            IGenericAppService<Groupe, GetGroupeResource, SetGroupeResource> groupeAppService,
            IGenericAppService<SousGroupe, GetSousGroupeResource, SetSousGroupeResource> sGroupeAppService
            )
        {
            _sectionAppService = sectionAppService;
            _groupeAppService = groupeAppService;
            _sGroupeAppService = sGroupeAppService;
        }




        [HttpGet]
        public async Task<QueryResultResource<GetSectionResource>> GetSections([FromQuery]ClasseQueryResource filterResource)
        {
            return await _sectionAppService.GetAllSections(filterResource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSection([FromBody]SetSectionResource sectionResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var resultGroupe = new GetGroupeResource();
            var resultSousGroupe = new GetSousGroupeResource();

            var resultSection = await _sectionAppService.Add(sectionResource);

            if (resultSection != null)
            {
                resultGroupe = await _groupeAppService.Add(
                    new SetGroupeResource
                    {
                        RefGroupe = "G1",
                        SectionId = resultSection.Id
                    }
                    );

                if (resultGroupe != null)
                    resultSousGroupe = await _sGroupeAppService.Add(
                        new SetSousGroupeResource
                        {
                            RefSousGroupe = "SG1",
                            GroupeId = resultGroupe.Id
                        }
                       );
            }

            resultGroupe.SousGroupes.Add(resultSousGroupe);
            resultSection.Groupes.Add(resultGroupe);

            return Ok(resultSection);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSection(int id)
        {
            if (await _sectionAppService.GetById(id) == null)
                return NotFound();

            return Ok(await _sectionAppService.Remove(id));
        }

        [HttpPost("{sectionId}/groupe")]
        public async Task<IActionResult> CreateGroupe(int sectionId, [FromBody]SetGroupeResource groupeResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var resultSousGroupe = new GetSousGroupeResource();

            groupeResource.SectionId = sectionId;
            var resultGroupe = await _groupeAppService.Add(groupeResource);

            if (resultGroupe != null)
            {
                resultSousGroupe = await _sGroupeAppService.Add(
                    new SetSousGroupeResource
                    {
                        RefSousGroupe = "SG1",
                        GroupeId = resultGroupe.Id
                    }
                   );
            }

            resultGroupe.SousGroupes.Add(resultSousGroupe);

            return Ok(resultGroupe);

        }

        [HttpDelete("groupe/{id}")]
        public async Task<IActionResult> DeleteGroupe(int id)
        {
            if (await _groupeAppService.GetById(id) == null)
                return NotFound();

            return Ok(await _groupeAppService.Remove(id));
        }

        [HttpPost("groupe/{groupeId}/sgroupe")]
        public async Task<IActionResult> CreateSousGroupe(int groupeId, [FromBody]SetSousGroupeResource sGroupeResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            sGroupeResource.GroupeId = groupeId;
            return Ok(await _sGroupeAppService.Add(sGroupeResource));

        }

        [HttpDelete("groupe/sgroupe/{id}")]
        public async Task<IActionResult> DeleteSousGroupe(int id)
        {
            if (await _sGroupeAppService.GetById(id) == null)
                return NotFound();

            return Ok(await _sGroupeAppService.Remove(id));
        }


    }
}