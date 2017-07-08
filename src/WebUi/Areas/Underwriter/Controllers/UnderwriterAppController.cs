using System.Web.Mvc;
using EDeviceClaims.Core;
using EDeviceClaims.WebUi.Controllers;

namespace EDeviceClaims.WebUi.Areas.Underwriter.Controllers
{
    [Authorize(Roles = AppRoles.Underwriter)]
    public class UnderwriterAppController : AppController
    {

    }
}