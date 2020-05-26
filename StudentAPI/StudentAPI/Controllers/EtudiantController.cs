using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Controllers.Resources.Etudiant;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using System.Threading.Tasks;

namespace StudentAPI.Controllers
{
    [Route("api/etudiants")]
    [ApiController]
    public class EtudiantController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IEtudiantRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public EtudiantController(IMapper mapper, IEtudiantRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {

            var etudiant = await repository.GetEtudiant(id);

            if (etudiant == null)
                return NotFound();

            var etudiantR = mapper.Map<Etudiant, GetEtudiantResource>(etudiant);

            return Ok(etudiantR);
        }

        [HttpPost]

        public async Task<IActionResult> CreateEtudiant([FromBody]SetEtudiantResource etudiantResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            var etudiant = mapper.Map<SetEtudiantResource, Etudiant>(etudiantResource);

            repository.Add(etudiant);
            await unitOfWork.CompleteAsync();

            etudiant = await repository.GetEtudiant(etudiant.Id);
            var result = mapper.Map<Etudiant, GetEtudiantResource>(etudiant);

            return Ok(result);
        }
    }
}