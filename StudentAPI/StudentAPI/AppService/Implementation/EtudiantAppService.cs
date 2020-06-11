﻿using AutoMapper;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account.Manage;
using StudentAPI.AppService.Contracts;
using StudentAPI.Controllers.Resources.Etudiant;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace StudentAPI.AppService.Implementation
{
    public class EtudiantAppService : GenericAppService<Etudiant, GetEtudiantResource, SetEtudiantResource, RequestQuery>, IEtudiantAppService
    {
        private readonly IMapper _mapper;
        private readonly IEtudiantRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public EtudiantAppService(IMapper mapper, IEtudiantRepository repository, IUnitOfWork unitOfWork) : base(mapper, repository, unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task<GetEtudiantResource> GetByMatricule(string matricule)
        {
            throw new NotImplementedException();
        }
    }
}