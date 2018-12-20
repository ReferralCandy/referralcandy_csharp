using System;
using System.Net.Http;

namespace ReferralCandyAPI.Response
{
    public class UpdateUnsubscribedResponse : BaseResponse
    {
        public string email { get; private set; }
        public bool unsubscribed { get; private set; }

        public UpdateUnsubscribedResponse(HttpResponseMessage response) : base(response)
        {
            if (status_code == 200)
            {
                email           = parsedResponse["email"].ToString();
                unsubscribed    = Convert.ToBoolean(parsedResponse["unsubscribed"].ToString());
            }
        }
    }
}
