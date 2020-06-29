using AutoMapper;
using StudentAPI.Controllers.Resources;
using StudentAPI.Controllers.Resources.Classe.Groupe;
using StudentAPI.Controllers.Resources.Classe.Section;
using StudentAPI.Controllers.Resources.Classe.SousGroupe;
using StudentAPI.Controllers.Resources.DocumentPartage;
using StudentAPI.Controllers.Resources.Etudiant;
using StudentAPI.Controllers.Resources.MatiereRef;
using StudentAPI.Controllers.Resources.NiveauSpecialite;
using StudentAPI.Controllers.Resources.Parcour;
using StudentAPI.Controllers.Resources.Personne;
using StudentAPI.Controllers.Resources.Planning.Planning;
using StudentAPI.Controllers.Resources.Planning.PlanningGroupe;
using StudentAPI.Controllers.Resources.Planning.PlanningGroupe.NoNavigationProperty;
using StudentAPI.Controllers.Resources.Planning.PlanningSection;
using StudentAPI.Controllers.Resources.Planning.PlanningSGroupe;
using StudentAPI.Controllers.Resources.Planning.PlanningSGroupe.NoNavigationProperty;
using StudentAPI.Controllers.Resources.Query;
using StudentAPI.Controllers.Resources.Section;
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



            // ******Classe*****
            CreateMap<Groupe, GetGroupeResourceNoNav>().ReverseMap();
            CreateMap<Groupe, GetGroupeResource>().ReverseMap();
            CreateMap<Groupe, SetGroupeResource>().ReverseMap();

            CreateMap<Section, GetSectionResourceNoNav>().ReverseMap();
            CreateMap<Section, GetSectionResource>().ReverseMap();
            CreateMap<Section, SetSectionResource>().ReverseMap();
            CreateMap<ClasseQuery, ClasseQueryResource>().ReverseMap();



            CreateMap<SousGroupe, GetSousGroupeResourceNoNav>().ReverseMap();
            CreateMap<SousGroupe, GetSousGroupeResource>().ReverseMap();
            CreateMap<SousGroupe, SetSousGroupeResource>().ReverseMap();


            //****** Planning *****
            CreateMap<Planning, GetPlanningResource>().ReverseMap();
            CreateMap<Planning, SetPlanningResource>().ReverseMap();

            CreateMap<PlanningGroupe, GetPlanningGroupeResource>().ReverseMap();
            CreateMap<PlanningGroupe, GetPlanningGroupeResourceNoNavG>().ReverseMap();
            CreateMap<PlanningGroupe, GetPlanningGroupeResourceNoNavP>().ReverseMap();
            CreateMap<PlanningGroupe, SetPlanningGroupeResource>().ReverseMap();

            CreateMap<PlanningSGroupe, GetPlanningSGroupeResource>().ReverseMap();
            CreateMap<PlanningSGroupe, GetPlanningSGroupeResourceNoNavG>().ReverseMap();
            CreateMap<PlanningSGroupe, GetPlanningSGroupeResourceNoNavP>().ReverseMap();
            CreateMap<PlanningSGroupe, SetPlanningSGroupeResource>().ReverseMap();

            CreateMap<PlanningSection, GetPlanningSectionResource>().ReverseMap();
            CreateMap<PlanningSection, GetPlanningSectionResourceNoNavS>().ReverseMap();
            CreateMap<PlanningSection, GetPlanningSectionResourceNoNavP>().ReverseMap();
            CreateMap<PlanningSection, SetPlanningSectionResource>().ReverseMap();


            //******Parcour*****
            CreateMap<Parcour, GetParcourResource>().ReverseMap();
            CreateMap<Parcour, SetParcourResource>();

            CreateMap<ParcourQuery, ParcourQueryResource>().ReverseMap();



            //******DocumentPartage*****
            CreateMap<DocumentPartage, GetDocumentPartageResource>();
            CreateMap<DocumentPartage, SetDocumentPartageResource>();

            CreateMap<DocumentPartageQuery, DocumentPartageQueryResource>().ReverseMap();

            CreateMap<DocumentFile, DocumentFileResource>().ReverseMap();


            //******Specialité*****
            CreateMap<MatiereRef, MatiereRefResourceNoNav>().ReverseMap();

            CreateMap<Specialite, SpecialiteResource>().ReverseMap();

            CreateMap<Filiere, FiliereResource>().ReverseMap();

            CreateMap<DomaineFormation, DomaineFormationResource>().ReverseMap();


            CreateMap<NiveauSpecialite, NiveauSpecialiteResource>().ReverseMap();

            CreateMap<NiveauSpecialiteQuery, NiveauSpecialiteQueryResource>().ReverseMap();



            //****Personne****
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

            CreateMap<SetParcourResource, Parcour>()
                .ForMember(p => p.Id, opt => opt.Ignore());



        }
    }
}
