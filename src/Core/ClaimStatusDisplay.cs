using System;
using System.Collections.Generic;
using System.Linq;

namespace EDeviceClaims.Core
{
    public class ClaimStatusDisplay
    {
        public enum Status
        {
            Open,
            Denied,
            Approved
        }
        public string Text { get; set; }
        public int Value { get; set; }

        public List<ClaimStatusDisplay> GetList()
        {
            var items = new List<ClaimStatusDisplay>();
            foreach (int value in Enum.GetValues(typeof(Status)))
            {
                items.Add(new ClaimStatusDisplay
                {
                    Text = Enum.GetName(typeof(Status), value),
                    Value = value
                });
            }
            return items;
        }
    }
}
