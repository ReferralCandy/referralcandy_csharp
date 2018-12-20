using System.Collections.Generic;
using ReferralCandyAPI.Interfaces;

namespace ReferralCandyAPI.Request
{
    public class UpdateReferralRequest : IRequest
    {
        public Dictionary<string, string> parameters { get; private set; }

        /// <summary>
        /// This method lets you update the purchase status of a referred customer
        /// </summary>
        /// <param name="customer_email">Email address of customer who made the referred purchase</param>
        /// <param name="notify">Whether to notify the referrer that their referral has been disregarded</param>
        /// <param name="returned">Whether customer has returned his/her purchase</param>
        public UpdateReferralRequest(string customer_email, bool notify, bool returned)
        {
            SortedDictionary<string, string> raw_parameters = new SortedDictionary<string, string>
            {
                { "customer_email", customer_email },
                { "notify", notify.ToString().ToLower() },
                { "returned", returned.ToString() },
                { "timestamp", ReferralCandy.CurrentTimestamp() },
                { "accessID", ReferralCandy.apiAccessId },
            };

            parameters = ReferralCandy.AppendSignature(raw_parameters);
        }
    }
}
