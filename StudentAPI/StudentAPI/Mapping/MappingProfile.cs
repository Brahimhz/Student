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
            // *************   Domaine => API   ***************

            CreateMap<Module, ModuleResource>();

            CreateMap<Seance, SaveSeanceResource>()
                .ForMember(ssr => ssr.ModuleId, opt => opt.MapFrom(s => s.ModuleId));

            CreateMap<Seance, GetSeanceResource>()
                .ForMember(ssr => ssr.Module, opt => opt.MapFrom(s => s.Module));


            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));


            CreateMap<TimeTable, SaveTimeTableResource>()
                .ForMember(str => str.Seances, opt => opt.MapFrom(t => t.Seances.Select(s => s.Id)));



            CreateMap<TimeTable, GetTimeTableResource>()
                .ForMember(gtr => gtr.Seances, opt => opt.MapFrom(t => t.Seances));





            // ***********  API => Domaine  **************

            CreateMap<ModuleResource, Module>()
                .ForMember(s => s.Id, opt => opt.Ignore());

            CreateMap<SaveSeanceResource, Seance>()
                .ForMember(s => s.Id, opt => opt.Ignore());

            CreateMap<SchoolInformationQueryResource, SchoolInformationQuery>();

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
