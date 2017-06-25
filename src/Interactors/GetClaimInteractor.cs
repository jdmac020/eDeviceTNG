using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Entities;
using EDeviceClaims.Repositories;

namespace EDeviceClaims.Interactors
{
    public interface IGetClaimInteractor
    {
        ClaimEntity GetClaimById(Guid policyId);
    }

    public class GetClaimInteractor : IGetClaimInteractor
    {
        private IClaimRepository Repo
        {
            get { return _repo ?? (_repo = new ClaimRepository()); }
            set { _repo = value; }
        }

        private IClaimRepository _repo;

        public ClaimEntity GetClaimById(Guid policyId)
        {
            //Save a new claim using the claim repository
            
            return Repo.GetByPolicyId(policyId);
        }
    }
}
