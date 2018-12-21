namespace ReferralCandyAPI.Request
{
    public class InviteRequest : BaseRequest
    {
        /// <summary>
        /// This method lets you send out an in-app invite to a contact
        /// </summary>
        /// <param name="email">Contact's email address</param>
        public InviteRequest(string email) : base("invite")
        {
            Parameters.Add("email", email);
        }
    }
}
