using Microsoft.AspNetCore.Mvc;
using StudentAPI.AppService;
using StudentAPI.AppService.Contracts;
using StudentAPI.Controllers.Resources.InfoSeance;
using StudentAPI.Controllers.Resources.Planning.PlanningSection;
using StudentAPI.Core.Models;
using System.Threading.Tasks;

namespace StudentAPI.Controllers
{
    [Route("/api/")]
    [ApiController]
    public class PlanningController : ControllerBase
    {
        private readonly IPlanningAppService _planningAppService;
        private readonly IGenericAppService<InfoSeance, GetInfoSeanceResource, SetInfoSeanceResource> _infoSeanceAppService;

        public PlanningController
            (IPlanningAppService planningAppService,
             IGenericAppService<InfoSeance, GetInfoSeanceResource, SetInfoSeanceResource> infoSeanceAppService)
        {
            _planningAppService = planningAppService;
            _infoSeanceAppService = infoSeanceAppService;
        }


        [HttpPost("{sectionId}/plannings")]
        public async Task<IActionResult> CreatePlannings(int sectionId, [FromBody]SetPlanningSectionResource planningSectionResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            planningSectionResource.SectionId = sectionId;

            return Ok(await _planningAppService.CreatePlannings(planningSectionResource));
        }


        [HttpGet("planning/{planningId}")]
        public async Task<IActionResult> GetPlanning(int planningId)
        {
            var resultPlanning = await _planningAppService.GetPlanning(planningId);

            if (resultPlanning == null)
                return NotFound();
            else
                return Ok(resultPlanning);
        }

        [HttpGet("fullPlanning/{planningSGroupeId}")]
        public async Task<IActionResult> GetFullPlanning(int planningSGroupeId)
        {
            var resultPlanning = await _planningAppService.GetFullPlanning(planningSGroupeId);

            if (resultPlanning == null)
                return NotFound();
            else
                return Ok(resultPlanning);
        }


        //InfoSeanceCRUDOperation
        [HttpPost("planning/{planningId}")]
        public async Task<IActionResult> CreateInfoSeance(int planningId, [FromBody]SetInfoSeanceResource infoSeanceResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _planningAppService.UpdatePlanning(planningId);
            infoSeanceResource.PlanningId = planningId;


            return Ok(await _infoSeanceAppService.Add(infoSeanceResource));
        }

        [HttpPut("planning/{planningId}/infoSeance/{infoSeanceId}")]
        public async Task<IActionResult> UpdateInfoSeance(int planningId, int infoSeanceId, [FromBody]SetInfoSeanceResource infoSeanceResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            infoSeanceResource.PlanningId = planningId;
            await _planningAppService.UpdatePlanning(planningId);

            return Ok(await _infoSeanceAppService.Update(infoSeanceId, infoSeanceResource));
        }


        [HttpDelete("infoSeance/{infoSeanceId}")]
        public async Task<IActionResult> DeleteInfoSeanc(int infoSeanceId)
        {
            return Ok(await _infoSeanceAppService.Remove(infoSeanceId));
        }
    }
}