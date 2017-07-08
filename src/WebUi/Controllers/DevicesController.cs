using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EDeviceClaims.Core;
using EDeviceClaims.Domain.Services;
using EDeviceClaims.WebUi.Models;

namespace EDeviceClaims.WebUi.Controllers
{
  [Authorize(Roles = AppRoles.PolicyHolder)]
  public class DevicesController : AppController
  {
    private IPolicyService _policyService = new PolicyService();

    public ActionResult Index()
    {
      var domainModel = _policyService.GetByUserId(CurrentUserId);
      var model = new DeviceListViewModel(domainModel);

      return View(model);
    }

      public ActionResult Details(Guid policyId)
      {
            var policyModel = _policyService.GetById(policyId);
            var viewModel = new DeviceViewModel(policyModel);

            return View(viewModel);
        }


  }
}