using AutoMapper;
using StudentAPI.AppService.Contracts;
using StudentAPI.Controllers.Resources.Planning.Planning;
using StudentAPI.Controllers.Resources.Planning.PlanningSection;
using StudentAPI.Controllers.Resources.Planning.PlanningSGroupe.UpDown;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using System;
using System.Threading.Tasks;

namespace StudentAPI.AppService.Implementation
{
    public class PlanningAppService : IPlanningAppService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPlanningRepository _planningRepository;
        private readonly IGenericRepository<PlanningSection> _sectionRepository;
        private readonly IGenericRepository<PlanningGroupe> _groupeRepository;
        private readonly IGenericRepository<PlanningSGroupe> _sGroupeRepository;

        public PlanningAppService(IMapper mapper,
                                  IUnitOfWork unitOfWork,
                                  IPlanningRepository planningRepository,
                                  IGenericRepository<PlanningSection> sectionRepository,
                                  IGenericRepository<PlanningGroupe> groupeRepository,
                                  IGenericRepository<PlanningSGroupe> SGroupeRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _planningRepository = planningRepository;
            _sectionRepository = sectionRepository;
            _groupeRepository = groupeRepository;
            _sGroupeRepository = SGroupeRepository;
        }


        public async Task<GetPlanningSectionResourceDown> CreatePlannings(SetPlanningSectionResource planningSectionResource)
        {
            var planningGroupe = new PlanningGroupe();
            var planningSGroupe = new PlanningSGroupe();
            var sections = await _planningRepository.GetFullBySectionId(planningSectionResource.SectionId);

            planningSectionResource.LastUpdate = DateTime.Now;
            var planingSection = _mapper.Map<SetPlanningSectionResource, PlanningSection>(planningSectionResource);
            _sectionRepository.Add(planingSection);
            await _unitOfWork.CompleteAsync();

            //Create Planning to each Groupe
            foreach (var groupeItem in sections.Groupes)
            {
                planningGroupe = new PlanningGroupe
                {
                    GroupeId = groupeItem.Id,
                    PlanningSectionId = planingSection.Id,
                    LastUpdate = DateTime.Now
                };
                _groupeRepository.Add(planningGroupe);
                await _unitOfWork.CompleteAsync();

                //Create Planning to each Sous-Groupe
                foreach (var sGroupItem in groupeItem.SousGroupes)
                {
                    planningSGroupe = new PlanningSGroupe
                    {
                        PlanningGroupeId = planningGroupe.Id,
                        SousGroupeId = sGroupItem.Id,
                        LastUpdate = DateTime.Now
                    };
                    _sGroupeRepository.Add(planningSGroupe);
                    await _unitOfWork.CompleteAsync();
                }
            }

            return _mapper.Map<PlanningSection, GetPlanningSectionResourceDown>(planingSection);
        }

        public async Task<GetPlanningSGroupeResourceUp> GetFullPlanning(int id)
        {
            return _mapper.Map<PlanningSGroupe, GetPlanningSGroupeResourceUp>(await _planningRepository.GetFullPlanningById(id));
        }

        public async Task<GetPlanningResource> GetPlanning(int id)
        {
            return _mapper.Map<Planning, GetPlanningResource>(await _planningRepository.GetPlanningById(id));
        }

        public async Task UpdatePlanning(int id)
        {
            var planning = await _planningRepository.GetPlanningById(id);

            planning.LastUpdate = DateTime.Now;
        }

    }
}
