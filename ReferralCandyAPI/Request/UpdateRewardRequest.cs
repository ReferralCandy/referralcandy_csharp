using System.Collections.Generic;
using ReferralCandyAPI.Classes;
using ReferralCandyAPI.Interfaces;

namespace ReferralCandyAPI.Request
{
    public class UpdateRewardRequest : IRequest
    {
        public Dictionary<string, string> parameters { get; private set; }

        /// <summary>
        /// This method lets you update a custom reward
        /// </summary>
        /// <param name="id">The ID of the reward</param>
        /// <param name="status">The new status of the reward</param>
        public UpdateRewardRequest(int id, Reward.Status status)
        {
            SortedDictionary<string, string> raw_parameters = new SortedDictionary<string, string>
            {
                { "id", id.ToString() },
                { "status", status.ToString() },
                { "timestamp", ReferralCandy.CurrentTimestamp() },
                { "accessID", ReferralCandy.apiAccessId }
            };

            parameters = ReferralCandy.AppendSignature(raw_parameters);
        }
    }
}
