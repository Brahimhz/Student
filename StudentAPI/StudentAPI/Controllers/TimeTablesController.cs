using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Controllers.Resources;
using StudentAPI.Controllers.Resources.Query;
using StudentAPI.Controllers.Resources.TimeTableResource;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using StudentAPI.Core.Models.Query;
using System;
using System.Threading.Tasks;

namespace StudentAPI.Controllers
{
    [Route("api/timeTables")]
    public class TimeTablesController : ControllerBase
    {
        private IMapper mapper;
        private ITimeTableRepository repository;
        private IUnitOfWork unitOfWork;

        public TimeTablesController(IMapper mapper, ITimeTableRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody]SaveTimeTableResource tableResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            var timeTable = mapper.Map<SaveTimeTableResource, TimeTable>(tableResource);
            timeTable.LastUpdate = DateTime.Now;

            repository.AddTimeTable(timeTable);
            await unitOfWork.CompleteAsync();

            timeTable = await repository.GetTimeTable(timeTable.Id);
            var result = mapper.Map<TimeTable, GetTimeTableResource>(timeTable);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeTable(int id)
        {
            var timeTable = await repository.GetTimeTable(id, eagerLoading: false);

            if (timeTable == null)
                return NotFound();

            repository.RemoveTimeTable(timeTable);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody]SaveTimeTableResource tableResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var timeTable = await repository.GetTimeTable(id);

            if (timeTable == null)
                return NotFound();

            mapper.Map<SaveTimeTableResource, TimeTable>(tableResource, timeTable);
            timeTable.LastUpdate = DateTime.Now;

            await unitOfWork.CompleteAsync();

            timeTable = await repository.GetTimeTable(timeTable.Id);
            var result = mapper.Map<TimeTable, GetTimeTableResource>(timeTable);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTimeTable(int id)
        {

            var timeTable = await repository.GetTimeTable(id);

            if (timeTable == null)
                return NotFound();

            var timeTableR = mapper.Map<TimeTable, GetTimeTableResource>(timeTable);

            return Ok(timeTableR);
        }

        [HttpGet]
        public async Task<QueryResultResource<GetTimeTableResource>> GetTimeTables(TimeTableQueryResource filterResource)
        {
            var filter = mapper.Map<TimeTableQueryResource, TimeTableQuery>(filterResource);

            var queryResult = await repository.GetTimeTables(filter);


            return mapper.Map<QueryResult<TimeTable>, QueryResultResource<GetTimeTableResource>>(queryResult);
        }

    }
}