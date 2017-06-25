using System;

namespace EDeviceClaims.WebUi.Models
{
    public class NoteViewModel
    {
        public string Content { get; set; }
        public DateTime? WhenCreated { get; set; }
        public string CreatedBy { get; set; }
    }
}