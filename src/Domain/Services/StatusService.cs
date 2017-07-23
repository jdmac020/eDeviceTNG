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
            var status = GetStatusInteractor.ExecuteForId(id);
            if(status == null) throw new ArgumentException("Status does not exist");

            return new StatusDomainModel(status);
        }

        public List<StatusDomainModel> GetAll()
        {
            var statusEntities = GetStatusInteractor.ExecuteForAll();

            return statusEntities
                .Select(status => new StatusDomainModel(status))
                .ToList();
        }
    }
}
