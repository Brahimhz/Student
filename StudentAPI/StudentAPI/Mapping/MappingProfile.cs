using AutoMapper;
using StudentAPI.Controllers.Resources;
using StudentAPI.Controllers.Resources.Classe.Groupe;
using StudentAPI.Controllers.Resources.Classe.Section;
using StudentAPI.Controllers.Resources.Classe.SousGroupe;
using StudentAPI.Controllers.Resources.DocumentPartage;
using StudentAPI.Controllers.Resources.Etudiant;
using StudentAPI.Controllers.Resources.InfoSeance;
using StudentAPI.Controllers.Resources.MatiereRef;
using StudentAPI.Controllers.Resources.NiveauSpecialite;
using StudentAPI.Controllers.Resources.Parcour;
using StudentAPI.Controllers.Resources.Personne;
using StudentAPI.Controllers.Resources.Planning;
using StudentAPI.Controllers.Resources.Planning.Planning;
using StudentAPI.Controllers.Resources.Planning.PlanningGroupe;
using StudentAPI.Controllers.Resources.Planning.PlanningGroupe.NoNavigationProperty;
using StudentAPI.Controllers.Resources.Planning.PlanningSection;
using StudentAPI.Controllers.Resources.Planning.PlanningSection.NoNavigationProperty;
using StudentAPI.Controllers.Resources.Planning.PlanningSGroupe;
using StudentAPI.Controllers.Resources.Planning.PlanningSGroupe.NoNavigationProperty;
using StudentAPI.Controllers.Resources.Planning.PlanningSGroupe.UpDown;
using StudentAPI.Controllers.Resources.Query;
using StudentAPI.Controllers.Resources.Resultat;
using StudentAPI.Controllers.Resources.Resultat.General;
using StudentAPI.Controllers.Resources.Resultat.ResultatMatiere;
using StudentAPI.Controllers.Resources.Resultat.ResultatUnite;
using StudentAPI.Controllers.Resources.Salle;
using StudentAPI.Controllers.Resources.Section;
using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;

namespace StudentAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // *************   Domaine => API   ***************



            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>)).ReverseMap();



            //Etablissement

            CreateMap<Bloc, BlocResource>().ReverseMap();
            CreateMap<Salle, SalleResource>().ReverseMap();





            // ******Resultat*****
            CreateMap<Resultat, GetResultatResource>().ReverseMap();
            CreateMap<Resultat, SetResultatResource>().ReverseMap();

            CreateMap<ResultatUnite, GetResultatUniteResource>().ReverseMap();
            CreateMap<ResultatUnite, SetResultatUniteResource>().ReverseMap();

            CreateMap<ResultatMatiere, GetResultatMatiereResource>().ReverseMap();
            CreateMap<ResultatMatiere, SetResultatMatiereResource>().ReverseMap();




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

            CreateMap<PlanningGroupe, GetPlanningGroupeResourceDown>().ReverseMap();
            CreateMap<PlanningGroupe, GetPlanningGroupeResourceUp>().ReverseMap();
            CreateMap<PlanningGroupe, SetPlanningGroupeResource>().ReverseMap();

            CreateMap<PlanningSGroupe, GetPlanningSGroupeResourceUp>().ReverseMap();
            CreateMap<PlanningSGroupe, GetPlanningSGroupeResourceDown>().ReverseMap();
            CreateMap<PlanningSGroupe, SetPlanningSGroupeResource>().ReverseMap();

            CreateMap<PlanningSection, GetPlanningSectionResourceDown>().ReverseMap();
            CreateMap<PlanningSection, GetPlanningSectionResourceUp>().ReverseMap();
            CreateMap<PlanningSection, SetPlanningSectionResource>().ReverseMap();



            CreateMap<Seance, SeanceResource>().ReverseMap();


            CreateMap<InfoSeance, GetInfoSeanceResource>().ReverseMap();
            CreateMap<InfoSeance, SetInfoSeanceResource>().ReverseMap();






            //******Parcour*****
            CreateMap<Parcour, GetParcourResource>().ReverseMap();
            CreateMap<Parcour, SetParcourResource>();

            CreateMap<ParcourQuery, ParcourQueryResource>().ReverseMap();



            //******DocumentPartage*****
            CreateMap<DocumentPartage, GetDocumentPartageResource>().ReverseMap();
            CreateMap<DocumentPartage, SetDocumentPartageResource>().ReverseMap();

            CreateMap<DocumentPartageQuery, DocumentPartageQueryResource>().ReverseMap();

            CreateMap<DocumentFile, DocumentFileResource>().ReverseMap();


            //******Matiere*****
            CreateMap<MatiereRef, MatiereRefResourceNoNav>().ReverseMap();

            CreateMap<Matiere, MatiereResource>().ReverseMap();

            CreateMap<UnitePedagogique, UnitePedagogiqueResource>().ReverseMap();

            //******Specialité*****
            CreateMap<Specialite, SpecialiteResource>().ReverseMap();

            CreateMap<Filiere, FiliereResource>().ReverseMap();

            CreateMap<DomaineFormation, DomaineFormationResource>().ReverseMap();


            CreateMap<NiveauSpecialite, NiveauSpecialiteResource>().ReverseMap();

            CreateMap<NiveauSpecialiteQuery, NiveauSpecialiteQueryResource>().ReverseMap();



            //****Personne****
            CreateMap<Personne, GetPersonneResource>().ReverseMap();
            CreateMap<Personne, GetPersonneResourceNoNav>().ReverseMap();
            CreateMap<Personne, SetPersonneResource>().ReverseMap();

            CreateMap<Etudiant, SetEtudiantResource>().ReverseMap();
            CreateMap<Etudiant, GetEtudiantResource>().ReverseMap();


            CreateMap<Enseignant, EnseignantResource>().ReverseMap();





            // ***********  API => Domaine  **************


        }
    }
}
