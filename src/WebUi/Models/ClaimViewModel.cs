using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EDeviceClaims.Core;
using EDeviceClaims.Domain.Models;
using EDeviceClaims.Domain.Services;

namespace EDeviceClaims.WebUi.Models
{
    public class ClaimViewModel
    {
        public Guid Id { get; set; }
        public string PolicyNumber { get; set; }
        public string DeviceName { get; set; }
        public string SerialNumber { get; set; }
        public string Opened { get; set; }
        public ClaimStatus Status { get; set; }
        public List<NoteViewModel> Notes { get; set; } = new List<NoteViewModel>();
        
        public ClaimViewModel(ClaimDomainModel domainModel)
        {
            Id = domainModel.Id;
            Opened = $"{domainModel.WhenStarted.ToShortDateString()}";
            Status = domainModel.Status;

            SetPolicyProperties(domainModel.Policy);
        }

        

        private void SetPolicyProperties(PolicyDomainModel policy)
        {
            if (policy == null) return;

            PolicyNumber = policy.Number;
            DeviceName = policy.DeviceName;
            SerialNumber = policy.SerialNumber;

        }
    }
}
