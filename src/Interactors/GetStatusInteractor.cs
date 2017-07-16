using System;
using System.Collections.Generic;
using EDeviceClaims.Entities;
using EDeviceClaims.Repositories;

namespace EDeviceClaims.Interactors
{
    public interface IGetStatusInteractor
    {
        StatusEntity ExecuteForId(Guid id);
        IList<StatusEntity> ExecuteForAll();
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

        public StatusEntity ExecuteForId(Guid id)
        {
            return Repo.GetById(id);
        }

        public IList<StatusEntity> ExecuteForAll()
        {
            return Repo.GetAll();
        }
    }
}