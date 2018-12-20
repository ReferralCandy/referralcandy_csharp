using System.Net.Http;

namespace ReferralCandyAPI.Response
{
    public class PurchaseResponse : BaseResponse
    {
        public string referralcorner_url { get; private set; }

        public PurchaseResponse(HttpResponseMessage response) : base(response)
        {
            if (status_code == 200)
            {
                referralcorner_url = parsedResponse["referralcorner_url"].ToString();
            }
        }
    }
}
