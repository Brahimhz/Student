using Microsoft.AspNetCore.Mvc;
using StudentAPI.AppService.Contracts;
using StudentAPI.Controllers.Resources.NiveauSpecialite;
using StudentAPI.Controllers.Resources.Query;
using System.Threading.Tasks;

namespace StudentAPI.Controllers
{
    [Route("api/niveauSpecialite")]
    [ApiController]
    public class NiveauSpecialiteController : ControllerBase
    {
        private readonly INiveauSpecialiteAppService _appService;

        public NiveauSpecialiteController(INiveauSpecialiteAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public async Task<QueryResultResource<NiveauSpecialiteResource>> GetNiveauSpecialites([FromQuery]NiveauSpecialiteQueryResource filterResource)
        {
            return await _appService.GetAll(filterResource);
        }
    }
}