using System.Net.Http;

namespace ReferralCandyAPI.Response
{
    public class VerifyResponse : BaseResponse
    {
        public VerifyResponse(HttpResponseMessage response) : base(response)
        {

        }
    }
}
