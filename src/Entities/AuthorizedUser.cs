using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using EDeviceClaims.Core;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EDeviceClaims.Entities
{
  public class AuthorizedUser : IdentityUser, IEntity<string>
  {
    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AuthorizedUser> manager)
    {
      // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
      var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
      // Add custom user claims here
      return userIdentity;
    }

    public virtual ICollection<Policy> UserPolicies { get; set; }
  }
}