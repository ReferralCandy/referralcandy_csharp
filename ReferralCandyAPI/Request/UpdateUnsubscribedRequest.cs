using System.Collections.Generic;
using ReferralCandyAPI.Interfaces;

namespace ReferralCandyAPI.Request
{
    public class UpdateUnsubscribedRequest : IRequest
    {
        public Dictionary<string, string> parameters { get; private set; }

        /// <summary>
        /// This method lets you unsubscribe and resubscribe a contact in your referral program
        /// </summary>
        /// <param name="email">Contact's email address</param>
        /// <param name="unsubscribed">Whether to unsubscribe or resubscribe contact</param>
        public UpdateUnsubscribedRequest(string email, bool unsubscribed)
        {
            SortedDictionary<string, string> raw_parameters = new SortedDictionary<string, string>
            {
                { "email", email },
                { "unsubscribed", unsubscribed.ToString().ToLower() },
                { "timestamp", ReferralCandy.CurrentTimestamp() },
                { "accessID", ReferralCandy.apiAccessId }
            };

            parameters = ReferralCandy.AppendSignature(raw_parameters);
        }
    }
}
