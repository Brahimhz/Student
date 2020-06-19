using Microsoft.AspNetCore.Mvc;
using StudentAPI.AppService.Contracts;
using StudentAPI.Controllers.Resources.DocumentPartage;
using StudentAPI.Controllers.Resources.Query;
using System;
using System.Threading.Tasks;

namespace StudentAPI.Controllers
{
    [Route("/api/documentpartage")]
    [ApiController]
    public class DocumentPartageController : ControllerBase
    {
        private readonly IDocumentPartageAppService _appService;

        public DocumentPartageController(IDocumentPartageAppService appService)
        {
            _appService = appService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateDocumentPartage([FromBody]SetDocumentPartageResource documentPartageResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            documentPartageResource.LastUpdate = DateTime.Now;

            return Ok(await _appService.Add(documentPartageResource));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentPartage(int id)
        {
            var documentPartageR = await _appService.GetById(id);

            if (documentPartageR == null)
                return NotFound();

            return Ok(await _appService.RemoveWithFile(id));

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocumentPartage(int id, [FromBody]SetDocumentPartageResource documentPartageResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            documentPartageResource.LastUpdate = DateTime.Now;

            return Ok(await _appService.Update(id, documentPartageResource));



        }

        [HttpGet]
        public async Task<QueryResultResource<GetDocumentPartageResource>> GetDocumentPartages([FromQuery]DocumentPartageQueryResource filterResource)
        {
            return await _appService.GetAllDP(filterResource);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentPartage(int id)
        {

            var documentPartageR = await _appService.GetByIdFull(id);

            if (documentPartageR == null)
                return NotFound();

            return Ok(documentPartageR);
        }
    }
}
