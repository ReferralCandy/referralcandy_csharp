using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using ReferralCandyAPI.Classes;

namespace ReferralCandyAPI.Response
{
    public class GetContactsResponse : BaseResponse
    {
        public int total_count { get; private set; }
        public List<Contact> contacts { get; private set; }

        public GetContactsResponse(HttpResponseMessage response) : base(response)
        {
            if (status_code == 200)
            {
                total_count = int.Parse(parsedResponse["total_count"].ToString());

                contacts = new List<Contact>();
                foreach(JToken contact in parsedResponse["contacts"])
                {
                    contacts.Add(contact.ToObject<Contact>());
                }
            }
        }
    }
}
