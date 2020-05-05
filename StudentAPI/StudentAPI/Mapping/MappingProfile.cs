using AutoMapper;
using StudentAPI.Controllers.Resources;
using StudentAPI.Controllers.Resources.Query;
using StudentAPI.Controllers.Resources.TimeTableResource;
using StudentAPI.Core.Models;
using StudentAPI.Core.Models.Query;
using System.Linq;

namespace StudentAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domaine => API

            CreateMap<Seance, SeanceResource>();

            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));


            CreateMap<TimeTable, SaveTimeTableResource>()
                .ForMember(str => str.Seances, opt => opt.MapFrom(t => t.Seances.Select(s => s.Id)));



            CreateMap<TimeTable, GetTimeTableResource>()
                .ForMember(gtr => gtr.Seances, opt => opt.MapFrom(t => t.Seances.Select(s => new SeanceResource
                {

                    Id = s.Id,
                    Module = s.Module,
                    Type = s.Type,
                    Lieu = s.Lieu,
                    Heure = s.Heure,
                    Jour = s.Jour,
                    TimeTableId = s.TimeTableId

                })));

            // API => Domaine

            CreateMap<SeanceResource, Seance>()
                .ForMember(s => s.Id, opt => opt.Ignore());

            CreateMap<TimeTableQueryResource, TimeTableQuery>();

            CreateMap<SaveTimeTableResource, TimeTable>()
                .ForMember(t => t.Id, opt => opt.Ignore())
                .ForMember(t => t.Seances, opt => opt.Ignore())
                .AfterMap((str, t) =>
                {
                    //Remove Deleted Seances

                    var removedS = t.Seances.Where(s => !str.Seances.Contains(s.Id));

                    foreach (Seance s in removedS.ToList())
                        t.Seances.Remove(s);


                    //Add new Seance
                    var addedS = str.Seances.Where(id => !t.Seances.Any(s => s.Id == id)).Select(id => new Seance { Id = id });
                    foreach (var s in addedS.ToList())
                        t.Seances.Add(s);
                }
                );

        }
    }
}
