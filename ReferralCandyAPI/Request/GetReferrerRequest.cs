using System.Collections.Generic;
using ReferralCandyAPI.Interfaces;

namespace ReferralCandyAPI.Request
{
    public class GetReferrerRequest : IRequest
    {
        public Dictionary<string, string> parameters { get; private set; }

        /// <summary>
        /// This method lets you query for the referrer of a particular customer
        /// </summary>
        /// <param name="customer_email">Customer email address</param>
        public GetReferrerRequest(string customer_email)
        {
            SortedDictionary<string, string> raw_parameters = new SortedDictionary<string, string>
            {
                { "customer_email", customer_email },
                { "timestamp", ReferralCandy.CurrentTimestamp() },
                { "accessID", ReferralCandy.apiAccessId }
            };

            parameters = ReferralCandy.AppendSignature(raw_parameters);
        }
    }
}
