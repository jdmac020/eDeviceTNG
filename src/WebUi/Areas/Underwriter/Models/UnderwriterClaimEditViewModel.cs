using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EDeviceClaims.Core;
using EDeviceClaims.Domain.Models;
using EDeviceClaims.WebUi.Models;

namespace EDeviceClaims.WebUi.Areas.Underwriter.Models
{
    public class UnderwriterClaimEditViewModel
    {
        public ClaimStatusViewModel Status { get; set; }

        public Guid Id { get; set; }

        public List<NoteViewModel> Notes { get; set; }

        public List<ClaimStatusViewModel> Statuses { get; set; }
        public Guid NewStatusId { get; set; }
        public string LastModified { get; set; }

        public UnderwriterClaimEditViewModel(ClaimDomainModel claim)
        {
            Id = claim.Id;
            Status = new ClaimStatusViewModel(claim.Status);
            LastModified = claim.WhenLastModified.ToString();
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