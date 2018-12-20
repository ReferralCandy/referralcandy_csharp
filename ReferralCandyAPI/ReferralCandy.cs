using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ReferralCandyAPI.Request;
using ReferralCandyAPI.Response;

namespace ReferralCandyAPI
{
    public class ReferralCandy
    {
        public static string apiAccessId { get; private set; }
        public static string apiSecretKey { get; private set; }
        private string baseUrl = "https://my.referralcandy.com/api/v1";
        private static readonly HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Initializes a new instance of the ReferralCandy API client
        /// </summary>
        /// <param name="apiAccessId">API access ID of your ReferralCandy account</param>
        /// <param name="apiSecretKey">API secret key of your ReferralCandy account</param>
        public ReferralCandy(string apiAccessId, string apiSecretKey)
        {
            ReferralCandy.apiAccessId   = apiAccessId;
            ReferralCandy.apiSecretKey  = apiSecretKey;
        }

        public static string CurrentTimestamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
        }

        public static string ToUnixTimestamp(DateTime date)
        {
            return Convert.ToInt32(date.Subtract(new DateTime(1970, 1, 1)).TotalSeconds).ToString();
        }

        private string ApiEndpoint(string apiMethod)
        {
            return String.Format("{0}/{1}.json", baseUrl, apiMethod);
        }

        public static Dictionary<string, string> AppendSignature(SortedDictionary<string, string> parameters)
        {
            string preparedParameterString = apiSecretKey;
            foreach (var parameter in parameters)
            {
                preparedParameterString += String.Format("{0}={1}", parameter.Key, parameter.Value);
            }

            string signature = "";
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] hashData = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(preparedParameterString));

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashData.Length; i++)
                {
                    sb.Append(hashData[i].ToString("x2"));
                }

                signature = sb.ToString();
            }

            Dictionary<string, string> preparedParameters = new Dictionary<string, string>(parameters);
            preparedParameters.Add("signature", signature);

            return preparedParameters;
        }

        private FormUrlEncodedContent UrlEncode(Dictionary<string, string> preparedParameters)
        {
            return new FormUrlEncodedContent(preparedParameters);
        }

        private async Task<HttpResponseMessage> PostRequest(string endpoint, Interfaces.IRequest request)
        {
            return await httpClient.PostAsync(endpoint, UrlEncode(request.parameters));
        }

        private async Task<HttpResponseMessage> GetRequest(string endpoint, Interfaces.IRequest request)
        {
            List<string> parameters = new List<string>();
            foreach (KeyValuePair<string, string> parameter in request.parameters)
            {
                parameters.Add(String.Format("{0}={1}", parameter.Key, parameter.Value));
            }

            return await httpClient.GetAsync(String.Format("{0}?{1}", endpoint, String.Join("&", parameters)));
        }

        /// <summary>
        /// This method lets you verify that authentication for your API calls is set up correctly.
        /// </summary>
        public VerifyResponse Verify(VerifyRequest verifyRequest)
        {
            return new VerifyResponse(PostRequest(ApiEndpoint("verify"), verifyRequest).Result);
        }

        /// <summary>
        /// This method lets you register a new purchase at your store. A referral email will be sent to the customer.
        /// </summary>
        public PurchaseResponse Purchase(PurchaseRequest purchaseRequest)
        {
            return new PurchaseResponse(PostRequest(ApiEndpoint("purchase"), purchaseRequest).Result);
        }

        /// <summary>
        /// This method lets you query for referred purchases made over some period of time.
        /// </summary>
        public GetReferralsResponse GetReferrals(GetReferralsRequest getReferralsRequest)
        {
            return new GetReferralsResponse(PostRequest(ApiEndpoint("referrals"), getReferralsRequest).Result);
        }

        /// <summary>
        /// This method lets you update the purchase status of a referred customer.
        /// By default, an email is sent out to the customer who made the referral to inform him/her that he/she is not eligible for a recent referral reward.
        /// </summary>
        public UpdateReferralResponse UpdateReferral(UpdateReferralRequest updateReferralRequest)
        {
            return new UpdateReferralResponse(PostRequest(ApiEndpoint("referral"), updateReferralRequest).Result);
        }

        /// <summary>
        /// This method lets you query for the referrer of a particular customer.
        /// </summary>
        public GetReferrerResponse GetReferrer(GetReferrerRequest referrerRequest)
        {
            return new GetReferrerResponse(PostRequest(ApiEndpoint("referrer"), referrerRequest).Result);
        }

        /// <summary>
        /// This method lets you query for contacts involved in your referral campaign.
        /// </summary>
        public GetContactsResponse GetContacts(GetContactsRequest getContactsRequest)
        {
            return new GetContactsResponse(PostRequest(ApiEndpoint("contacts"), getContactsRequest).Result);
        }

        /// <summary>
        /// This method lets you sign an advocate up for your referral program.
        /// If the advocate already exsits, you can use this method to retrieve the advocate's referral link and Portal Sharing Page address.
        /// </summary>
        public SignupResponse Signup(SignupRequest signupRequest)
        {
            return new SignupResponse(PostRequest(ApiEndpoint("signup"), signupRequest).Result);
        }

        /// <summary>
        /// This method lets you send out an in-app invite to a contact.
        /// </summary>
        public InviteResponse Invite(InviteRequest inviteRequest)
        {
            return new InviteResponse(PostRequest(ApiEndpoint("invite"), inviteRequest).Result);
        }

        /// <summary>
        /// This method lets you unsubscribe and resubscribe a contact in your referral program.
        /// </summary>
        public UpdateUnsubscribedResponse UpdateUnsubscribed(UpdateUnsubscribedRequest updateUnsubscribedRequest)
        {
            return new UpdateUnsubscribedResponse(PostRequest(ApiEndpoint("unsubscribed"), updateUnsubscribedRequest).Result);
        }

        /// <summary>
        /// This method lets you query for rewards which match some criteria.
        /// </summary>
        public GetRewardsResponse GetRewards(GetRewardsRequest getRewardsRequest)
        {
            return new GetRewardsResponse(GetRequest(ApiEndpoint("rewards"), getRewardsRequest).Result);
        }

        /// <summary>
        /// This method lets you update a custom reward.
        /// </summary>
        public UpdateRewardResponse UpdateReward(UpdateRewardRequest updateRewardRequest)
        {
            return new UpdateRewardResponse(PostRequest(ApiEndpoint("rewards"), updateRewardRequest).Result);
        }
    }
}
