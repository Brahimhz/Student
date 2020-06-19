using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using StudentAPI.AppService.Contracts;
using StudentAPI.Controllers.Resources.DocumentPartage;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace StudentAPI.AppService.Implementation
{
    public class DocumentFileAppService : IDocumentFileAppService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<DocumentFile> _dfRepository;
        private readonly IDocumentPartageRepository _dpRepository;
        private readonly IHostingEnvironment _host;

        public DocumentFileAppService(IMapper mapper, IGenericRepository<DocumentFile> dfRepository, IDocumentPartageRepository dpRepository, IUnitOfWork unitOfWork, IHostingEnvironment host)
        {
            _mapper = mapper;
            _dfRepository = dfRepository;
            _dpRepository = dpRepository;
            _unitOfWork = unitOfWork;
            _host = host;
        }
        public async Task DeleteFile(int documentPartageId)
        {
            var document = (await _dpRepository.GetByIdFull(documentPartageId)).Document;
            if (document != null)
            {
                _dfRepository.Remove(document.Id);

                var documentFullPath = _host.WebRootPath + "/Documents/" + document.FileName;

                if (File.Exists(documentFullPath))
                    File.Delete(documentFullPath);

            }
        }

        public async Task<DocumentFileResource> UploadDocumentFile(int documentPartageId, IFormFile file)
        {
            await DeleteFile(documentPartageId);


            var uploadsFolderPath = Path.Combine(_host.WebRootPath, "Documents");
            if (!Directory.Exists(uploadsFolderPath))
                Directory.CreateDirectory(uploadsFolderPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var filePath = Path.Combine(uploadsFolderPath, fileName);


            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var document = new DocumentFile { FileName = fileName, DocumentPartageId = documentPartageId };
            _dfRepository.Add(document);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<DocumentFile, DocumentFileResource>(document);
        }
    }
}
