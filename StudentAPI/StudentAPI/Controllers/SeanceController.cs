using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Controllers.Resources;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using System;
using System.Threading.Tasks;

namespace StudentAPI.Controllers
{
    [Route("api/seances")]
    public class SeanceController : ControllerBase
    {
        private IMapper mapper;
        private ISeanceRepository repository;
        private IUnitOfWork unitOfWork;
        private ITimeTableRepository timeTableRepository;

        public SeanceController(IMapper mapper, ISeanceRepository repository, IUnitOfWork unitOfWork, ITimeTableRepository timeTableRepository)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.timeTableRepository = timeTableRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeance([FromBody]SaveSeanceResource seanceResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            var seance = mapper.Map<SaveSeanceResource, Seance>(seanceResource);

            repository.Add(seance);

            //TimeTable Update 
            var timeTable = await timeTableRepository.GetTimeTable(seance.TimeTableId);

            if (timeTable == null)
                return NotFound();

            timeTable.LastUpdate = DateTime.Now;

            await unitOfWork.CompleteAsync();

            seance = await repository.GetSeance(seance.Id);
            var result = mapper.Map<Seance, GetSeanceResource>(seance);

            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeance(int id, [FromBody]SaveSeanceResource seanceResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var seance = await repository.GetSeance(id, eagerLoading: false);

            if (seance == null)
                return NotFound();

            mapper.Map<SaveSeanceResource, Seance>(seanceResource, seance);

            //TimeTable Update 
            var timeTable = await timeTableRepository.GetTimeTable(seance.TimeTableId);

            if (timeTable == null)
                return NotFound();

            timeTable.LastUpdate = DateTime.Now;

            await unitOfWork.CompleteAsync();

            seance = await repository.GetSeance(seance.Id);
            var result = mapper.Map<Seance, GetSeanceResource>(seance);

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeance(int id)
        {
            var seance = await repository.GetSeance(id, eagerLoading: false);

            if (seance == null)
                return NotFound();

            repository.Remove(seance);


            //TimeTable Update 
            var timeTable = await timeTableRepository.GetTimeTable(seance.TimeTableId);

            if (timeTable == null)
                return NotFound();

            timeTable.LastUpdate = DateTime.Now;

            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeance(int id)
        {

            var seance = await repository.GetSeance(id);

            if (seance == null)
                return NotFound();

            var result = mapper.Map<Seance, GetSeanceResource>(seance);

            return Ok(result);
        }

    }
}