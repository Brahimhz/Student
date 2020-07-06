using AutoMapper;
using StudentAPI.AppService.Contracts;
using StudentAPI.Controllers.Resources.Resultat;
using StudentAPI.Controllers.Resources.Resultat.ResultatMatiere;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.AppService.Implementation
{
    public class ResultatAppService : IResultatAppService
    {
        private readonly IMapper _mapper;
        private readonly IResultatRepository _repositoryResultat;
        private readonly IGenericRepository<ResultatUnite> _repositoryResultatUnite;
        private readonly IGenericRepository<ResultatMatiere> _repositoryResultatMatiere;
        private readonly IUnitOfWork _unitOfWork;

        public ResultatAppService(IMapper mapper, IResultatRepository repositoryResultat, IGenericRepository<ResultatUnite> repositoryResultatUnite, IGenericRepository<ResultatMatiere> repositoryResultatMatiere, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repositoryResultat = repositoryResultat;
            _repositoryResultatUnite = repositoryResultatUnite;
            _repositoryResultatMatiere = repositoryResultatMatiere;
            _unitOfWork = unitOfWork;
        }


        public async Task<GetResultatResource> Add(int idParcour)
        {
            var totalCreditG = 0.0;

            var resultatUnite = new ResultatUnite();
            var resultatMatiere = new ResultatMatiere();

            var resultat = new Resultat
            {

                ParcourId = idParcour,
                MoyenneFinal = 0,
                TotalCredit = 0,
                Total = 0,
                Acquit = false,
                LastUpdate = DateTime.Now
            };

            _repositoryResultat.Add(resultat);
            await _unitOfWork.CompleteAsync();

            var resultatModel = await _repositoryResultat.GetResultatModel(idParcour);


            foreach (KeyValuePair<int, List<Matiere>> item in resultatModel)
            {
                var totalCreditU = 0.0;

                resultatUnite = new ResultatUnite
                {

                    ResultatId = resultat.Id,
                    CreditUnite = 0,
                    MoyenneUnite = 0,
                    TotalUnite = 0,
                    UnitePedagogiqueId = item.Key,
                    Acquit = false

                };


                _repositoryResultatUnite.Add(resultatUnite);
                await _unitOfWork.CompleteAsync();


                foreach (Matiere matiere in item.Value)
                {
                    resultatMatiere = new ResultatMatiere
                    {
                        CreditMatiere = 0,
                        NoteControl = 0,
                        NoteExamen = 0,
                        MoyenneMatiere = 0,
                        Acquit = false,
                        ResultatUniteId = resultatUnite.Id,
                        MatiereId = matiere.Id
                    };

                    _repositoryResultatMatiere.Add(resultatMatiere);
                    await _unitOfWork.CompleteAsync();

                    resultatUnite.ResultatMatieres.Add(resultatMatiere);

                    totalCreditU += matiere.Coefficient;
                }

                resultatUnite.TotalCoff = totalCreditU;

                totalCreditG += totalCreditU;

                resultat.ResultatUnites.Add(resultatUnite);

            }


            resultat.TotalCoff = totalCreditG;
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<Resultat, GetResultatResource>(resultat);
        }

        public async Task<GetResultatResource> GetByIdFull(int id)
        {
            return _mapper.Map<Resultat, GetResultatResource>(await _repositoryResultat.GetByIdFull(id));
        }

        public async Task<GetResultatResource> Update(int idResultat, int idResultatUnite, int idResultatMatiere, SetResultatMatiereResource resultatMatiereResource)
        {
            var resultat = await _repositoryResultat.GetByIdFull(idResultat);

            if (resultat == null)
                return _mapper.Map<Resultat, GetResultatResource>(resultat);

            var resultatunite = resultat.ResultatUnites.SingleOrDefault(ru => ru.Id == idResultatUnite);
            var resultatMatiere = resultatunite.ResultatMatieres.SingleOrDefault(rm => rm.Id == idResultatMatiere);

            //ResultatMatiereUpdate
            resultatMatiereResource.MoyenneMatiere = ((resultatMatiereResource.NoteExamen * 2) + resultatMatiereResource.NoteControl) / 3;
            resultatMatiereResource.TotalMatiere = resultatMatiereResource.MoyenneMatiere * resultatMatiere.Matiere.Coefficient;

            if (resultatMatiereResource.MoyenneMatiere >= 10)
            {
                resultatMatiereResource.CreditMatiere = resultatMatiere.Matiere.Credit;
                resultatMatiereResource.Acquit = true;
            }

            _mapper.Map<SetResultatMatiereResource, ResultatMatiere>(resultatMatiereResource, resultatMatiere);


            //ResultatUniteUpdate
            resultatunite.TotalUnite += resultatMatiere.TotalMatiere;
            resultatunite.MoyenneUnite = resultatunite.TotalUnite / resultatunite.TotalCoff;
            resultatunite.CreditUnite += resultatMatiere.CreditMatiere;

            if (resultatunite.MoyenneUnite >= 10)
                resultatunite.Acquit = true;

            //ResultatGlobalUpdate
            resultat.Total += resultatunite.TotalUnite;
            resultat.MoyenneFinal = resultat.Total / resultat.TotalCoff;
            resultat.TotalCredit += resultatunite.CreditUnite;

            if (resultat.MoyenneFinal >= 10)
                resultat.Acquit = true;

            resultat.LastUpdate = DateTime.Now;

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<Resultat, GetResultatResource>(resultat);

        }
    }
}
