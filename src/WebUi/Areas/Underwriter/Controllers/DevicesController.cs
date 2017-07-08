using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EDeviceClaims.Core;
using EDeviceClaims.Domain.Services;
using EDeviceClaims.WebUi.Controllers;

namespace EDeviceClaims.WebUi.Areas.Underwriter.Controllers
{
    public class DevicesController : UnderwriterAppController
    {
        private IPolicyService _policyService = new PolicyService();

        // GET: Underwriter/Device
        public ActionResult Index()
        {
            return View("Index");
        }
    }

    [Authorize(Roles = AppRoles.Underwriter)]
    public class UnderwriterAppController : AppController
    {
        
    }
}