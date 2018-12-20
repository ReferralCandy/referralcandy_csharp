using System.Net.Http;

namespace ReferralCandyAPI.Response
{
    public class GetReferrerResponse : BaseResponse
    {
        public string referrer { get; private set; }

        public GetReferrerResponse(HttpResponseMessage response) : base(response)
        {
            if (status_code == 200)
            {
                referrer = parsedResponse["referrer"].ToString();
            }
        }
    }
}
