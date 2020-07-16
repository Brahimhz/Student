using AutoMapper;
using StudentAPI.AppService.Contracts;
using StudentAPI.Controllers.Resources.Classe.Groupe;
using StudentAPI.Controllers.Resources.Classe.Section;
using StudentAPI.Controllers.Resources.Classe.SousGroupe;
using StudentAPI.Controllers.Resources.Query;
using StudentAPI.Controllers.Resources.Section;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;
using System.Threading.Tasks;

namespace StudentAPI.AppService.Implementation
{
    public class ClasseAppService : IClasseAppService
    {
        private readonly IMapper _mapper;
        private readonly ISectionRepository _sectionrepository;
        private readonly IGenericRepository<Groupe> _groupeRepository;
        private readonly IGenericRepository<SousGroupe> _sGroupeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClasseAppService(IMapper mapper, ISectionRepository sectionrepository,
                                IGenericRepository<Groupe> groupeRepository,
                                IGenericRepository<SousGroupe> sGroupeRepository,
                                IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _sectionrepository = sectionrepository;
            _groupeRepository = groupeRepository;
            _sGroupeRepository = sGroupeRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<GetSectionResource> CreateSection(SetSectionResource sectionResource)
        {
            var resultGroupe = new Groupe();
            var resultSousGroupe = new SousGroupe();

            //CreateSection
            var resultSection = _mapper.Map<SetSectionResource, Section>(sectionResource);
            _sectionrepository.Add(resultSection);
            await _unitOfWork.CompleteAsync();

            //CreateSectionGroupe
            resultGroupe =
                    new Groupe
                    {
                        RefGroupe = "G1",
                        SectionId = resultSection.Id
                    };
            _groupeRepository.Add(resultGroupe);
            await _unitOfWork.CompleteAsync();

            //CreateGroupeSousGroupe
            resultSousGroupe =
                        new SousGroupe
                        {
                            RefSousGroupe = "SG1",
                            GroupeId = resultGroupe.Id
                        };
            _sGroupeRepository.Add(resultSousGroupe);
            await _unitOfWork.CompleteAsync();

            //JoinThem
            resultGroupe.SousGroupes.Add(resultSousGroupe);
            resultSection.Groupes.Add(resultGroupe);

            return _mapper.Map<Section, GetSectionResource>(resultSection);
        }

        public async Task<GetGroupeResource> CreateGroupe(SetGroupeResource groupeResource)
        {
            var resultSousGroupe = new SousGroupe();

            //CreateGroupe
            var resultGroupe = _mapper.Map<SetGroupeResource, Groupe>(groupeResource);
            _groupeRepository.Add(resultGroupe);
            await _unitOfWork.CompleteAsync();

            //CreateGroupeSousGroupe
            resultSousGroupe =
                        new SousGroupe
                        {
                            RefSousGroupe = "SG1",
                            GroupeId = resultGroupe.Id
                        };
            _sGroupeRepository.Add(resultSousGroupe);
            await _unitOfWork.CompleteAsync();

            //JoinThem
            resultGroupe.SousGroupes.Add(resultSousGroupe);

            return _mapper.Map<Groupe, GetGroupeResource>(resultGroupe);
        }

        public async Task<GetSousGroupeResource> CreateSousGroupe(SetSousGroupeResource sGroupeResource)
        {
            var resultSousGroupe = _mapper.Map<SetSousGroupeResource, SousGroupe>(sGroupeResource);

            _sGroupeRepository.Add(resultSousGroupe);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<SousGroupe, GetSousGroupeResource>(resultSousGroupe);
        }

        public async Task<int> DeleteGroupe(int id)
        {
            _groupeRepository.Remove(id);
            await _unitOfWork.CompleteAsync();
            return id;
        }

        public async Task<int> DeleteSection(int id)
        {
            _sectionrepository.Remove(id);
            await _unitOfWork.CompleteAsync();
            return id;
        }

        public async Task<int> DeleteSousGroupe(int id)
        {
            _sGroupeRepository.Remove(id);
            await _unitOfWork.CompleteAsync();
            return id;
        }

        public async Task<QueryResultResource<GetSectionResource>> GetAllSections(ClasseQueryResource filterResource)
        {
            var filter = _mapper.Map<ClasseQueryResource, ClasseQuery>(filterResource);

            var queryResult = await _sectionrepository.GetAll(filter);

            return _mapper.Map<QueryResult<Section>, QueryResultResource<GetSectionResource>>(queryResult);
        }



    }
}
