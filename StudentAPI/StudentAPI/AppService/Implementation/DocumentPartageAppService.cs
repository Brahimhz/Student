using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using StudentAPI.AppService.Contracts;
using StudentAPI.Controllers.Resources.DocumentPartage;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;
using System.IO;

namespace StudentAPI.AppService.Implementation
{
    public class DocumentPartageAppService : GenericAppService<DocumentPartage, GetDocumentPartageResource, SetDocumentPartageResource, RequestQuery>, IDocumentPartageAppService
    {
        private readonly IMapper _mapper;
        private readonly IDocumentPartageRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<DocumentFile> _genericRepository;
        private readonly IHostingEnvironment _host;

        public DocumentPartageAppService(IMapper mapper, IDocumentPartageRepository repository, IUnitOfWork unitOfWork, IGenericRepository<DocumentFile> genericRepository, IHostingEnvironment host) : base(mapper, repository, unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
            _host = host;
        }

        public async void RemoveWithFile(int id)
        {
            var document = (await _repository.GetById(id)).Document;
            _genericRepository.Remove(document.Id);

            var documentFullPath = _host.WebRootPath + "/Documents/" + document.FileName;

            if (File.Exists(documentFullPath))
                File.Delete(documentFullPath);

            _repository.Remove(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
