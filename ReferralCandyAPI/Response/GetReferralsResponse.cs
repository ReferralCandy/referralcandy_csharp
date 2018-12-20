using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using ReferralCandyAPI.Classes;

namespace ReferralCandyAPI.Response
{
    public class GetReferralsResponse : BaseResponse
    {
        public List<Referral> referrals { get; private set; }
        public int period_from { get; private set; }
        public int period_to { get; private set; }

        public GetReferralsResponse(HttpResponseMessage response) : base(response)
        {
            if (status_code == 200)
            {
                period_from = int.Parse(parsedResponse["period_from"].ToString());
                period_to   = int.Parse(parsedResponse["period_to"].ToString());

                referrals = new List<Referral>();
                foreach (JToken referral in parsedResponse["referrals"])
                {
                    referrals.Add(referral.ToObject<Referral>());
                }
            }
        }
    }
}
