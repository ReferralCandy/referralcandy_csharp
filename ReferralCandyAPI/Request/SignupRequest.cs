namespace ReferralCandyAPI.Request
{
    public class SignupRequest : BaseRequest
    {
        /// <summary>
        /// This method lets you sign an advocate up for your referral program.
        /// If the advocate already exsits, you can use this method to retrieve the advocate's referral link and Portal Sharing Page address
        /// </summary>
        /// <param name="first_name">Advocate's first name</param>
        /// <param name="last_name">Advoate's last name</param>
        /// <param name="email">Advocate's email</param>
        public SignupRequest(string first_name, string last_name, string email) : base("signup")
        {
            Parameters.Add("first_name", first_name);
            Parameters.Add("last_name", last_name);
            Parameters.Add("email", email);
        }
    }
}
