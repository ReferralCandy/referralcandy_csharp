namespace ReferralCandyAPI.Request
{
    public class UpdateReferralRequest : BaseRequest
    {
        /// <summary>
        /// This method lets you update the purchase status of a referred customer
        /// </summary>
        /// <param name="customer_email">Email address of customer who made the referred purchase</param>
        /// <param name="notify">Whether to notify the referrer that their referral has been disregarded</param>
        /// <param name="returned">Whether customer has returned his/her purchase</param>
        public UpdateReferralRequest(string customer_email, bool notify, bool returned) : base("referral")
        {
            Parameters.Add("customer_email", customer_email);
            Parameters.Add("notify", notify.ToString().ToLower());
            Parameters.Add("returned", returned.ToString().ToLower());
        }
    }
}
