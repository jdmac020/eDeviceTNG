using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Domain.Models;
using EDeviceClaims.Interactors;

namespace EDeviceClaims.Domain.Services
{

    public interface IClaimService
    {
        ClaimDomainModel StartClaim(Guid policyId);
        ClaimDomainModel ViewClaim(Guid policyId);
        ClaimDomainModel GetById(Guid id);

        List<ClaimDomainModel> GetAllOpen();
    }

    public class ClaimService : IClaimService
    {
        private IGetPolicyInteractor _getPolicyInteractor;

        private IGetPolicyInteractor GetPolicyInteractor
        {
            get { return _getPolicyInteractor ?? (_getPolicyInteractor = new GetPolicyInteractor()); }
            set { _getPolicyInteractor = value; }
        }

        private IGetClaimInteractor _getClaimInteractor;

        private IGetClaimInteractor GetClaimInteractor
        {
            get { return _getClaimInteractor ?? (_getClaimInteractor = new GetClaimInteractor()); } 
            set { _getClaimInteractor = value; }
        }
        
        private ICreateClaimInteractor _createClaimInteractor;

        private ICreateClaimInteractor CreateClaimInteractor
        {
            get { return _createClaimInteractor ?? (_createClaimInteractor = new CreateClaimInteractor()); } 
            set { _createClaimInteractor = value; }
        }

        
        public ClaimDomainModel StartClaim(Guid policyId)
        {
            var policy = GetPolicyInteractor.GetById(policyId);

            if (policy == null) throw new ArgumentException("There is no policy for that ID.");
            
            var existingClaimEntity = GetClaimInteractor.Execute(policyId);
            
            if (existingClaimEntity != null)
            {
                return new ClaimDomainModel(existingClaimEntity);
            }
            else
            {
                var newClaimEntity = CreateClaimInteractor.Excute(policyId);
                return new ClaimDomainModel(newClaimEntity);
            }
            
        }

        public ClaimDomainModel ViewClaim(Guid policyId)
        {
            var policy = GetPolicyInteractor.GetById(policyId);

            if (policy == null) throw new ArgumentException("There is no policy for that ID.");

            var existingClaim = GetClaimInteractor.Execute(policyId);
            
            return new ClaimDomainModel(existingClaim);
        }

        public ClaimDomainModel GetById(Guid id)
        {
            var claim = GetClaimInteractor.Execute(id);
            if(claim == null) throw new ArgumentException("Claim does not exist");

            return new ClaimDomainModel(claim);
        }

        public List<ClaimDomainModel> GetAllOpen()
        {
            var openClaims = GetClaimInteractor.GetAllOpen();
            
            // LINQ statement that combines a "results = new List<>" and "foreach openClaim" into one...
            return openClaims
                .Select(claim => new ClaimDomainModel(claim))
                .OrderBy(c => c.WhenStarted)
                .ToList();
        }
    }
}
