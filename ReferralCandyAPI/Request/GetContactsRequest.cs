using System.Collections.Generic;
using ReferralCandyAPI.Interfaces;

namespace ReferralCandyAPI.Request
{
    public class GetContactsRequest : IRequest
    {
        public Dictionary<string, string> parameters { get; private set; }

        /// <summary>
        /// This method lets you query for contacts involved in your referral campaign
        /// </summary>
        /// <param name="id">Lowest id of contact returned by query. Defaults to 1</param>
        /// <param name="limit">Number of contacts to return. Defaults to 100. Capped at 100</param>
        public GetContactsRequest(int id = 1, int limit = 100)
        {
            if (limit > 100)
            {
                limit = 100;
            }

            SortedDictionary<string, string> raw_parameters = new SortedDictionary<string, string>
            {
                { "id", id.ToString() },
                { "limit", limit.ToString() },
                { "timestamp", ReferralCandy.CurrentTimestamp() },
                { "accessID", ReferralCandy.apiAccessId }
            };

            parameters = ReferralCandy.AppendSignature(raw_parameters);
        }
    }
}
