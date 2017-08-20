using System;
using System.Collections.Generic;
using EDeviceClaims.Entities;
using EDeviceClaims.Repositories;

namespace EDeviceClaims.Interactors
{
    public interface IGetStatusInteractor
    {
        StatusEntity GetById(Guid id);
        IList<StatusEntity> GetAll();
        StatusEntity GetByName(string name);
    }

    public class GetStatusInteractor : IGetStatusInteractor
    {
        private IStatusRepository _repo;
        private IStatusRepository Repo
        {
            get { return _repo ?? (_repo = new StatusRepository()); }
            set { _repo = value; }
        }
        
        public GetStatusInteractor() { }

        public GetStatusInteractor(IStatusRepository statusRepo)
        {
            _repo = statusRepo;
        }

        public StatusEntity GetById(Guid id)
        {
            return Repo.GetById(id);
        }

        public IList<StatusEntity> GetAll()
        {
            return Repo.GetAll();
        }

        public StatusEntity GetByName(string name)
        {
            return Repo.GetByName(name);
        }
    }
}