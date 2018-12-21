namespace ReferralCandyAPI.Request
{
    public class GetReferrerRequest : BaseRequest
    {
        /// <summary>
        /// This method lets you query for the referrer of a particular customer
        /// </summary>
        /// <param name="customer_email">Customer email address</param>
        public GetReferrerRequest(string customer_email) : base("referrer")
        {
        }
    }
}
