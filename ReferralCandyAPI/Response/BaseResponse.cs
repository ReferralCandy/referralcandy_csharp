using System;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace ReferralCandyAPI.Response
{
    public class BaseResponse
    {
        public int status_code { get; private set; }
        public string reason{ get; private set; }

        protected JObject parsedResponse { get; private set; }
        public string message { get; private set; }

        public BaseResponse(HttpResponseMessage response)
        {
            Init(response);
        }

        private void Init(HttpResponseMessage response)
        {
            status_code     = (int) response.StatusCode;
            reason          = response.ReasonPhrase;
            parsedResponse  = JObject.Parse(getResponseJson(response));
            message         = parsedResponse["message"].ToString();

            // Log requests for debbuging
            Console.WriteLine(String.Format("Request to: {0}", response.RequestMessage.RequestUri));
            Debug.WriteLine(String.Format("Request to: {0}", response.RequestMessage.RequestUri));

            try
            {
                Console.WriteLine("Parameters: {0}", response.RequestMessage.Content.ReadAsStringAsync().Result);
                Debug.WriteLine("Parameters: {0}", response.RequestMessage.Content.ReadAsStringAsync().Result);
            }
            catch
            {
                // Request must have been a GET request, parameters are in the request URL
            }
        }

        protected string getResponseJson(HttpResponseMessage response)
        {
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
