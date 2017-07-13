using System;
using System.Collections.Generic;
using System.Linq;

namespace EDeviceClaims.Core
{
    public class ClaimStatus
    {
        
        public string Text { get; set; }
        public int Value { get; set; }

        public List<ClaimStatus> GetList()
        {
            var items = new List<ClaimStatus>();
            foreach (int value in Enum.GetValues(typeof(Status)))
            {
                items.Add(new ClaimStatus
                {
                    Text = Enum.GetName(typeof(Status), value),
                    Value = value
                });
            }
            return items;
        }
    }
}
