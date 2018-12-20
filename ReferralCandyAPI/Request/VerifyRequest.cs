using System.Collections.Generic;
using ReferralCandyAPI.Interfaces;

namespace ReferralCandyAPI.Request
{
    public class VerifyRequest : IRequest
    {
        public Dictionary<string, string> parameters { get; private set; }

        public VerifyRequest()
        {
            SortedDictionary<string, string> raw_parameters = new SortedDictionary<string, string> {
                { "timestamp", ReferralCandy.CurrentTimestamp() },
                { "accessID", ReferralCandy.apiAccessId }
            };

            parameters = ReferralCandy.AppendSignature(raw_parameters);
        }
    }
}
