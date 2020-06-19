using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StudentAPI.AppService.Contracts;
using StudentAPI.Core.Settings;
using System.Threading.Tasks;

namespace StudentAPI.Controllers
{
    [Route("api/documentpartage/{documentpartageId}/document")]
    [ApiController]

    public class DocumentFileController : ControllerBase
    {
        private readonly IDocumentFileAppService _appService;
        private readonly DocumentSettings _documentSettings;

        public DocumentFileController(IDocumentFileAppService appService, IOptionsSnapshot<DocumentSettings> options)
        {
            _appService = appService;
            _documentSettings = options.Value;
        }


        [HttpPost]
        public async Task<IActionResult> UploadDocument(int documentPartageId, IFormFile file)
        {
            if (file == null)
                return BadRequest("No File");
            if (file.Length == 0)
                return BadRequest("Empty File");
            if (file.Length > _documentSettings.MaxBytes)
                return BadRequest("File Too Large");
            if (!_documentSettings.IsSupported(file.FileName))
                return BadRequest("Invalid Type File");

            return Ok(await _appService.UploadDocumentFile(documentPartageId, file));

        }

    }
}