using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using ReferralCandyAPI.Classes;

namespace ReferralCandyAPI.Response
{
    public class GetRewardsResponse : BaseResponse
    {
        public List<Reward> rewards { get; private set; }
        public int since_id { get; private set; }
        public Reward.Status status { get; private set; }
        public Reward.Type type{ get; private set; }

        public GetRewardsResponse(HttpResponseMessage response) : base(response)
        {
            if (status_code == 200)
            {
                rewards = new List<Reward>();
                foreach(JToken reward in parsedResponse["rewards"])
                {
                    rewards.Add(reward.ToObject<Reward>());
                }

                if (parsedResponse.ContainsKey("since_id"))
                {
                    since_id = int.Parse(parsedResponse["since_id"].ToString());
                }
            }
        }
    }
}
