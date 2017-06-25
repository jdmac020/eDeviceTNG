using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EDeviceClaims.Domain.Models;
using EDeviceClaims.Interactors;

namespace EDeviceClaims.Domain.Services
{
  public interface IPolicyService
  {
    IEnumerable<PolicyDomainModel> GetByUserId(string userId);
  }

  public class PolicyService : IPolicyService
  {
    private IGetPolicyInteractor _getPolicyInteractor;

    private IGetPolicyInteractor GetPolicyInteractor
    {
      get { return _getPolicyInteractor ?? (_getPolicyInteractor = new GetPolicyInteractor()); }
      set { _getPolicyInteractor = value; }
    }

    public IEnumerable<PolicyDomainModel> GetByUserId(string userId)
    {
      var policyEntities = GetPolicyInteractor.GetByUserId(userId);

      return policyEntities.Select(policyEntity => new PolicyDomainModel(policyEntity)).ToList();
    }
  }
}
