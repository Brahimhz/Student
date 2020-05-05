using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Controllers.Resources;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using System.Threading.Tasks;

namespace StudentAPI.Controllers
{
    [Route("api/seances")]
    public class SeanceController : ControllerBase
    {
        private IMapper mapper;
        private ISeanceRepository repository;
        private IUnitOfWork unitOfWork;

        public SeanceController(IMapper mapper, ISeanceRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeance([FromBody]SeanceResource seanceResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            var seance = mapper.Map<SeanceResource, Seance>(seanceResource);

            repository.Add(seance);
            await unitOfWork.CompleteAsync();

            seance = await repository.GetSeance(seance.Id);
            var result = mapper.Map<Seance, SeanceResource>(seance);

            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeance(int id, [FromBody]SeanceResource seanceResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var seance = await repository.GetSeance(id);

            if (seance == null)
                return NotFound();

            mapper.Map<SeanceResource, Seance>(seanceResource, seance);

            await unitOfWork.CompleteAsync();

            seance = await repository.GetSeance(seance.Id);
            var result = mapper.Map<Seance, SeanceResource>(seance);

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeance(int id)
        {
            var seance = await repository.GetSeance(id, eagerLoading: false);

            if (seance == null)
                return NotFound();

            repository.Remove(seance);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeance(int id)
        {

            var seance = await repository.GetSeance(id);

            if (seance == null)
                return NotFound();

            var result = mapper.Map<Seance, SeanceResource>(seance);

            return Ok(result);
        }

    }
}