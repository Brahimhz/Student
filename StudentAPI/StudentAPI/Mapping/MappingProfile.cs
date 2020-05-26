using AutoMapper;
using StudentAPI.Controllers.Resources.Etudiant;
using StudentAPI.Controllers.Resources.Query;
using StudentAPI.Core.Models;

namespace StudentAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // *************   Domaine => API   ***************

            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));

            CreateMap<Etudiant, SetEtudiantResource>();

            CreateMap<Etudiant, GetEtudiantResource>();

            // ***********  API => Domaine  **************

            CreateMap<SetEtudiantResource, Etudiant>()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ForMember(e => e.DocumentPartages, opt => opt.Ignore())
                .ForMember(e => e.Parcours, opt => opt.Ignore())
                .ForMember(e => e.RelationCommunications1, opt => opt.Ignore())
                .ForMember(e => e.RelationCommunications2, opt => opt.Ignore());
        }
    }
}
