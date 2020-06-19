using Microsoft.AspNetCore.Http;
using StudentAPI.Controllers.Resources.DocumentPartage;
using System.Threading.Tasks;

namespace StudentAPI.AppService.Contracts
{
    public interface IDocumentFileAppService
    {
        Task<DocumentFileResource> UploadDocumentFile(int documentPartageId, IFormFile file);
        Task DeleteFile(int documentPartageId);
    }
}
