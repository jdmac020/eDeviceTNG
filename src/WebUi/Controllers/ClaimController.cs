using System;
using System.Web.Mvc;
using EDeviceClaims.Core;
using EDeviceClaims.Domain.Models;
using EDeviceClaims.Domain.Services;
using EDeviceClaims.WebUi.Models;

namespace EDeviceClaims.WebUi.Controllers
{
    [Authorize(Roles = AppRoles.PolicyHolder)]
    public class ClaimController : AppController
    {
        private IClaimService _claimService = new ClaimService();

        public ActionResult StartClaim(Guid id) //Its just "Start" in the video... //The job is working code, not copying the video--this is even more legible
        {
            var claimDomainModel = _claimService.StartClaim(id);
            var model = new ClaimViewModel(claimDomainModel);
            return View(model);
        }

        public ActionResult ViewClaim(Guid id)
        {
            try
            {
                ClaimDomainModel claimModel = _claimService.GetById(id);
                ClaimViewModel viewModel = new ClaimViewModel(claimModel);

                return View(viewModel);
            }
            catch (ArgumentException e)
            {
                return null;
            }
        }
    }
}