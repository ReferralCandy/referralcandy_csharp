namespace ReferralCandyAPI.Request
{
    public class UpdateUnsubscribedRequest : BaseRequest
    {
        /// <summary>
        /// This method lets you unsubscribe and resubscribe a contact in your referral program
        /// </summary>
        /// <param name="email">Contact's email address</param>
        /// <param name="unsubscribed">Whether to unsubscribe or resubscribe contact</param>
        public UpdateUnsubscribedRequest(string email, bool unsubscribed) : base("unsubscribed")
        {
            Parameters.Add("email", email);
            Parameters.Add("unsubscribed", unsubscribed.ToString().ToLower());
        }
    }
}
