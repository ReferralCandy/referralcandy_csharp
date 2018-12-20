using System.Collections.Generic;
using ReferralCandyAPI.Interfaces;

namespace ReferralCandyAPI.Request
{
    public class InviteRequest : IRequest
    {
        public Dictionary<string, string> parameters { get; private set; }

        /// <summary>
        /// This method lets you send out an in-app invite to a contact
        /// </summary>
        /// <param name="email">Contact's email address</param>
        public InviteRequest(string email)
        {
            SortedDictionary<string, string> raw_parameters = new SortedDictionary<string, string>
            {
                { "email", email },
                { "timestamp", ReferralCandy.CurrentTimestamp() },
                { "accessID", ReferralCandy.apiAccessId }
            };

            parameters = ReferralCandy.AppendSignature(raw_parameters);
        }
    }
}
