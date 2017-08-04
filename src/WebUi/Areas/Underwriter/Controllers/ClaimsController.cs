using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EDeviceClaims.Core;
using EDeviceClaims.Domain.Services;
using EDeviceClaims.WebUi.Areas.Underwriter.Models;
using EDeviceClaims.WebUi.Controllers;
using EDeviceClaims.WebUi.Models;

namespace EDeviceClaims.WebUi.Areas.Underwriter.Controllers
{
    public class ClaimsController : UnderwriterAppController
    {
        private IPolicyService _policyService = new PolicyService();
        private IClaimService _claimService = new ClaimService();
        private IStatusService _statusService = new StatusService();

        // GET: Underwriter/Device
        public ActionResult Index()
        {
            var claims = _claimService.GetAllOpen();

            var model = new ClaimsListViewModel(claims);

            return View("Index", model);
        }

        public ActionResult Details(Guid claimId)
        {
            var claimModel = _claimService.GetById(claimId);
            var viewModel = new UnderwriterClaimViewModel(claimModel);

            return View(viewModel);
        }

        public ActionResult Edit(Guid claimId)
        {
            var claimModel = _claimService.GetById(claimId);
            var viewModel = new UnderwriterClaimViewModel(claimModel) {Statuses = GetStatusDropDownList()};


            return View(viewModel);
        }

        public ActionResult Update(UnderwriterClaimViewModel model)
        {


            return View("Index");
        }

        private List<ClaimStatusViewModel> GetStatusDropDownList()
        {
            var domainModels = _statusService.GetAll();
            var viewModels = new List<ClaimStatusViewModel>();

            foreach (var domainModel in domainModels)
            {
                viewModels.Add(new ClaimStatusViewModel(domainModel));
            }

            return viewModels;
        }
    }
}