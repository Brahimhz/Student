using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StudentAPI.AppService;
using StudentAPI.Controllers.Resources.DocumentPartage;
using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;
using StudentAPI.Core.Settings;
using System;
using System.IO;
using System.Threading.Tasks;

namespace StudentAPI.Controllers
{
    [Route("api/documentpartage/{documentpartageId}/document")]
    [ApiController]

    public class DocumentController : ControllerBase
    {
        private readonly IHostingEnvironment _host;
        private readonly IGenericAppService<DocumentFile, DocumentFileResource, DocumentFileResource, RequestQuery> _appService;
        private readonly DocumentSettings _documentSettings;

        public DocumentController(IHostingEnvironment host, IGenericAppService<DocumentFile, DocumentFileResource, DocumentFileResource, RequestQuery> appService, IOptionsSnapshot<DocumentSettings> options)
        {
            _host = host;
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

            var uploadsFolderPath = Path.Combine(_host.WebRootPath, "Documents");
            if (!Directory.Exists(uploadsFolderPath))
                Directory.CreateDirectory(uploadsFolderPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var filePath = Path.Combine(uploadsFolderPath, fileName);


            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }


            var document = new DocumentFileResource { FileName = fileName, DocumentPartageId = documentPartageId };
            return Ok(await _appService.Add(document));

        }

    }
}