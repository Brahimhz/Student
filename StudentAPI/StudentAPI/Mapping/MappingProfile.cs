using AutoMapper;
using StudentAPI.Controllers.Resources;
using StudentAPI.Controllers.Resources.DocumentPartage;
using StudentAPI.Controllers.Resources.Etudiant;
using StudentAPI.Controllers.Resources.MatiereRef;
using StudentAPI.Controllers.Resources.NiveauSpecialite;
using StudentAPI.Controllers.Resources.Personne;
using StudentAPI.Controllers.Resources.Query;
using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;
using System.Linq;

namespace StudentAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // *************   Domaine => API   ***************

            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>)).ReverseMap();

            CreateMap<DocumentPartage, GetDocumentPartageResource>();
            CreateMap<DocumentPartage, SetDocumentPartageResource>();

            CreateMap<DocumentPartageQuery, DocumentPartageQueryResource>().ReverseMap();

            CreateMap<DocumentFile, DocumentFileResource>().ReverseMap();


            CreateMap<MatiereRef, MatiereRefResourceNoNav>().ReverseMap();

            CreateMap<Specialite, SpecialiteResource>().ReverseMap();

            CreateMap<Filiere, FiliereResource>().ReverseMap();

            CreateMap<DomaineFormation, DomaineFormationResource>().ReverseMap();


            CreateMap<NiveauSpecialite, NiveauSpecialiteResource>().ReverseMap();



            CreateMap<Personne, GetPersonneResource>().ReverseMap();
            CreateMap<Personne, GetPersonneResourceNoNav>().ReverseMap();

            CreateMap<Personne, SetPersonneResource>()
                .ForMember(spr => spr.DocumentPartages, opt => opt.MapFrom(p => p.DocumentPartages.Select(dp => dp.Id)));

            CreateMap<Etudiant, SetEtudiantResource>();
            CreateMap<Etudiant, GetEtudiantResource>();





            // ***********  API => Domaine  **************

            CreateMap<SetEtudiantResource, Etudiant>()
                .ForMember(e => e.Parcours, opt => opt.Ignore());

            CreateMap<GetEtudiantResource, SetEtudiantResource>();

            CreateMap<SetPersonneResource, Personne>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.RelationCommunications1, opt => opt.Ignore())
                .ForMember(p => p.RelationCommunications2, opt => opt.Ignore())
                .ForMember(e => e.DocumentPartages, opt => opt.Ignore());


            CreateMap<SetDocumentPartageResource, DocumentPartage>()
                .ForMember(dp => dp.Id, opt => opt.Ignore());


        }
    }
}
