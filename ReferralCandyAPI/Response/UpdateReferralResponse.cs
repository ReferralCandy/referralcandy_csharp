using System;
using System.Net.Http;

namespace ReferralCandyAPI.Response
{
    public class UpdateReferralResponse : BaseResponse
    {
        public string customer_email { get; private set; }
        public bool returned{ get; private set; }

        public UpdateReferralResponse(HttpResponseMessage response) : base(response)
        {
            if (status_code == 200)
            {
                customer_email  = parsedResponse["customer_email"].ToString();
                returned        = Convert.ToBoolean(parsedResponse["returned"].ToString());
            }
        }
    }
}
