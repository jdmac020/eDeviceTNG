using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Domain.Models;
using EDeviceClaims.Entities;
using EDeviceClaims.Interactors;

namespace EDeviceClaims.Domain.Services
{

    public interface IStatusService
    {
        StatusDomainModel GetById(Guid id);
        StatusDomainModel GetByName(string name);
        List<StatusDomainModel> GetAll();
    }

    public class StatusService : IStatusService
    {
        private IGetStatusInteractor _getStatusInteractor;

        private IGetStatusInteractor GetStatusInteractor
        {
            get { return _getStatusInteractor ?? (_getStatusInteractor = new GetStatusInteractor()); }
            set { _getStatusInteractor = value; }
        }
        
        public StatusDomainModel GetById(Guid id)
        {
            var status = GetStatusInteractor.GetById(id);
            if(status == null) throw new ArgumentException("Status does not exist");

            return new StatusDomainModel(status);
        }

        public StatusDomainModel GetByName(string name)
        {
            var status = GetStatusInteractor.GetByName(name);
            if (status == null) throw new ArgumentException("Status does not exist");

            return new StatusDomainModel(status);
        }

        public List<StatusDomainModel> GetAll()
        {
            var statusEntities = GetStatusInteractor.GetAll();

            return statusEntities
                .Select(status => new StatusDomainModel(status))
                .ToList();
        }
    }
}
