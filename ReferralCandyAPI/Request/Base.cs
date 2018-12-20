using System;
using System.Collections.Generic;

namespace ReferralCandyAPI.Request
{
    public class Base
    {
        public SortedDictionary<string, string> paramaters { get; private set; } 

        public Base()
        {
        }
    }
}
