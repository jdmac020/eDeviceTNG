using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EDeviceClaims.Core;
using EDeviceClaims.Domain.Models;
using EDeviceClaims.WebUi.Models;

namespace EDeviceClaims.WebUi.Areas.Underwriter.Models
{
    public class UnderwriterClaimViewModel
    {
        public ClaimStatusViewModel Status { get; set; }

        public string Start { get; set; }

        public string DeviceName { get; set; }
        public string PolicyHolderName { get; set; }

        public Guid PolicyId { get; set; }

        public Guid Id { get; set; }

        public List<NoteViewModel> Notes { get; set; }

        public List<ClaimStatusViewModel> Statuses { get; set; }
        public Guid NewStatus { get; set; }

        public UnderwriterClaimViewModel(ClaimDomainModel claim)
        {
            Id = claim.Id;
            PolicyId = claim.Policy.Id;
            DeviceName = claim.Policy.DeviceName;
            PolicyHolderName = $"{claim.CustomerFirstName} {claim.CustomerLastName}";
            Start = $"{claim.WhenStarted.ToShortDateString()} {claim.WhenStarted.ToShortTimeString()}";
            Status = new ClaimStatusViewModel(claim.Status);
            Notes = new List<NoteViewModel>();
            //InitializeNotes();
        }

        private void InitializeNotes(List<NoteViewModel> notes)
        {
            if (notes.Any())
            {
                Notes = notes;
            }

            Notes = new List<NoteViewModel>();
        }
        
    }
}