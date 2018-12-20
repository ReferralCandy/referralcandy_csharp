using System.Net.Http;

namespace ReferralCandyAPI.Response
{
    public class SignupResponse : BaseResponse
    {
        public string referralcorner_url { get; private set; }
        public string referral_link { get; private set; }

        public SignupResponse(HttpResponseMessage response) : base(response)
        {
            if (status_code == 200)
            {
                referralcorner_url  = parsedResponse["referralcorner_url"].ToString();
                referral_link       = parsedResponse["referral_link"].ToString();
            }
        }
    }
}
