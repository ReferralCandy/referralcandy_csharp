using System.Net.Http;

namespace ReferralCandyAPI.Response
{
    public class InviteResponse : BaseResponse
    {
        public InviteResponse(HttpResponseMessage response) : base(response)
        {
        }
    }
}
