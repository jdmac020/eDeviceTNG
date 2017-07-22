using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using EDeviceClaims.Domain.Models;
using EDeviceClaims.Entities;

namespace EDeviceClaims.WebUi.Models
{
    public class DeviceViewModel
    {
        public DeviceViewModel(PolicyWithClaimsDomainModel device)
        {
            PolicyId = device.Id;
            PolicyNumber = device.Number;
            SerialNumber = device.SerialNumber;
            Name = device.DeviceName;

            MostCurrentClaim = GetCurrentClaim(device);
        }

        public ClaimViewModel MostCurrentClaim { get; set; }
        
        public string Name { get; set; }

        public string SerialNumber { get; set; }

        public string PolicyNumber { get; set; }

        public Guid PolicyId { get; set; }

        public bool ShowViewClaimButton()
        {
            if (MostCurrentClaim == null)
            {
                return false;
            }

            return true;
        }

        private ClaimDomainModel CheckForCurrentClaim(PolicyWithClaimsDomainModel device)
        {
            var claimsList = device.Claims;

            if (claimsList.Any())
            {
                if (claimsList.First().Status.Name == "Open")
                {
                    return claimsList.First();
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        private ClaimViewModel GetCurrentClaim(PolicyWithClaimsDomainModel device)
        {
            var currentClaim = CheckForCurrentClaim(device);

            if (currentClaim != null)
            {
                return new ClaimViewModel(currentClaim);
            }
            else
            {
                return null;
            }
        }
    }
}