using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using ReferralCandyAPI.Interfaces;

namespace ReferralCandyAPI.Request
{
    public class BaseRequest : IRequest
    {
        public string _endpoint { get; private set; }
        public string Endpoint { get { return String.Format("{0}/{1}.json", ReferralCandy.baseUrl, _endpoint); } }
        public SortedDictionary<string, string> Parameters { get; private set; }

        public BaseRequest(string endpoint)
        {
            _endpoint   = endpoint;
            Parameters  = new SortedDictionary<string, string>();
        }

        public FormUrlEncodedContent PostParameters()
        {
            return new FormUrlEncodedContent(ParametersWithSignature());
        }

        public string GetRequest()
        {
            List<string> getParametersList = new List<string>();
            foreach (KeyValuePair<string, string> parameter in ParametersWithSignature())
                getParametersList.Add(String.Format("{0}={1}", parameter.Key, parameter.Value));

            return String.Format("{0}?{1}", Endpoint, String.Join("&", getParametersList));
        }

        private string GenerateSingature(string preparedParameterString)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] hashData = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(preparedParameterString));

                string signature = "";
                for (int i = 0; i < hashData.Length; i++)
                    signature += hashData[i].ToString("x2");

                return signature;
            }
        }

        private Dictionary<string, string> ParametersWithSignature()
        {
            Parameters.Add("timestamp", ReferralCandy.CurrentTimestamp());
            Parameters.Add("accessID", ReferralCandy.apiAccessId);

            string preparedParameterString = ReferralCandy.apiSecretKey;
            foreach (var parameter in Parameters)
                preparedParameterString += String.Format("{0}={1}", parameter.Key, parameter.Value);

            Dictionary<string, string> preparedParameters = new Dictionary<string, string>(Parameters);
            preparedParameters.Add("signature", GenerateSingature(preparedParameterString));

            return preparedParameters;
        }
    }
}
