using ReferralCandyAPI.Classes;

namespace ReferralCandyAPI.Request
{
    public class GetRewardsRequest : BaseRequest
    {
        /// <summary>
        /// This method lets you query for rewards which match some criteria. Returns 200 rewards at a time
        /// </summary>
        /// <param name="email">When given, the result only contains rewards from the advocate with this email address</param>
        /// <param name="since_id">
        /// When given, the result starts from the next matching reward earned after the specified reward ID.
        /// Otherwise, the result starts with the first matching reward.
        /// </param>
        /// <param name="status">
        /// When specified, the result contains rewards with the matching status.
        /// Otherwise, the result contains rewards matching all statuses.
        /// Accepted values are pending_fulfillment, delivered
        /// </param>
        /// <param name="type">
        /// When specified, the result contains rewards with the matching type.
        /// Otherwise, the result contains rewards matching all types.
        /// Accepted values are cash, coupon, custom, none
        /// </param>
        public GetRewardsRequest(string email = "",
                                    int since_id = 0,
                                    Reward.Status status = Reward.Status.all,
                                    Reward.Type type = Reward.Type.all) : base("rewards")
        {
            if (since_id > 0)
                Parameters.Add("since_id", since_id.ToString());

            if (email.Length > 0)
                Parameters.Add("email", email);

            if (status != Reward.Status.all)
            {
                if (status == Reward.Status.not_applicable)
                    throw new System.Exception("Allowed values are only 'pending_fulfillment', 'delivered', and 'all'");

                Parameters.Add("status", status.ToString());
            }

            if (type != Reward.Type.all)
                Parameters.Add("type", type.ToString());
        }
    }
}
