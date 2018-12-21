using ReferralCandyAPI.Classes;

namespace ReferralCandyAPI.Request
{
    public class UpdateRewardRequest : BaseRequest
    {
       /// <summary>
        /// This method lets you update a custom reward
        /// </summary>
        /// <param name="id">The ID of the reward</param>
        /// <param name="status">The new status of the reward</param>
        public UpdateRewardRequest(int id, Reward.Status status) : base("rewards")
        {
            Parameters.Add("id", id.ToString());
            Parameters.Add("status", status.ToString());
        }
    }
}
