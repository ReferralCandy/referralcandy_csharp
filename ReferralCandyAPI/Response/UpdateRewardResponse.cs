
using System.Net.Http;
using ReferralCandyAPI.Classes;

namespace ReferralCandyAPI.Response
{
    public class UpdateRewardResponse : BaseResponse
    {
        public string messages { get; private set; }
        public Reward reward { get; private set; }

        public UpdateRewardResponse(HttpResponseMessage response) : base(response)
        {
            if (status_code == 200)
            {
                messages    = parsedResponse["messages"].ToString();
                reward      = parsedResponse["reward"].ToObject<Reward>();
            }
        }
    }
}
