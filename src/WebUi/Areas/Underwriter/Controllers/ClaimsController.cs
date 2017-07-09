using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EDeviceClaims.Core;
using EDeviceClaims.Domain.Services;
using EDeviceClaims.WebUi.Areas.Underwriter.Models;
using EDeviceClaims.WebUi.Controllers;

namespace EDeviceClaims.WebUi.Areas.Underwriter.Controllers
{
    public class ClaimsController : UnderwriterAppController
    {
        private IPolicyService _policyService = new PolicyService();
        private IClaimService _claimService = new ClaimService();

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
    }
}