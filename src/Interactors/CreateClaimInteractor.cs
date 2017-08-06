 using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using  EDeviceClaims.Entities;
using EDeviceClaims.Repositories;

namespace EDeviceClaims.Interactors
{
    public interface ICreateClaimInteractor
    {
        ClaimEntity Execute(Guid id);
    }

    public class CreateClaimInteractor : ICreateClaimInteractor
    {
        private IClaimRepository _claimRepo;
        private IClaimRepository ClaimRepo {
            get { return _claimRepo ?? (_claimRepo = new ClaimRepository()); }
            set { _claimRepo = value; }
        }

        private IStatusRepository _statusRepo;

        private IStatusRepository StatusRepo
        {
            get { return _statusRepo ?? (_statusRepo = new StatusRepository()); }
            set { _statusRepo = value; }
        }

        public CreateClaimInteractor() { }

        public CreateClaimInteractor(IClaimRepository claimRepo, IStatusRepository statusRepo)
        {
            _claimRepo = claimRepo;
            _statusRepo = statusRepo;
        }

        
        public ClaimEntity Execute(Guid id)
        {
            var initialStatus = StatusRepo.GetByName("New");
            var newClaim = new ClaimEntity() {Id = Guid.NewGuid(), PolicyId = id, StatusId = initialStatus.Id};
            newClaim = ClaimRepo.Create(newClaim);

            return newClaim;
        }
    }
}
