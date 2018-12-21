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
        public static readonly string baseUrl = "https://my.referralcandy.com/api/v1";
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

        private async Task<HttpResponseMessage> PostRequest(Interfaces.IRequest request)
        {
            return await httpClient.PostAsync(request.Endpoint, request.PostParameters());
        }

        private async Task<HttpResponseMessage> GetRequest(Interfaces.IRequest request)
        {
            return await httpClient.GetAsync(request.GetRequest());
        }

        /// <summary>
        /// This method lets you verify that authentication for your API calls is set up correctly.
        /// </summary>
        public VerifyResponse Verify(VerifyRequest verifyRequest)
        {
            return new VerifyResponse(PostRequest(verifyRequest).Result);
        }

        /// <summary>
        /// This method lets you register a new purchase at your store. A referral email will be sent to the customer.
        /// </summary>
        public PurchaseResponse Purchase(PurchaseRequest purchaseRequest)
        {
            return new PurchaseResponse(PostRequest(purchaseRequest).Result);
        }

        /// <summary>
        /// This method lets you query for referred purchases made over some period of time.
        /// </summary>
        public GetReferralsResponse GetReferrals(GetReferralsRequest getReferralsRequest)
        {
            return new GetReferralsResponse(PostRequest(getReferralsRequest).Result);
        }

        /// <summary>
        /// This method lets you update the purchase status of a referred customer.
        /// By default, an email is sent out to the customer who made the referral to inform him/her that he/she is not eligible for a recent referral reward.
        /// </summary>
        public UpdateReferralResponse UpdateReferral(UpdateReferralRequest updateReferralRequest)
        {
            return new UpdateReferralResponse(PostRequest(updateReferralRequest).Result);
        }

        /// <summary>
        /// This method lets you query for the referrer of a particular customer.
        /// </summary>
        public GetReferrerResponse GetReferrer(GetReferrerRequest referrerRequest)
        {
            return new GetReferrerResponse(PostRequest(referrerRequest).Result);
        }

        /// <summary>
        /// This method lets you query for contacts involved in your referral campaign.
        /// </summary>
        public GetContactsResponse GetContacts(GetContactsRequest getContactsRequest)
        {
            return new GetContactsResponse(PostRequest(getContactsRequest).Result);
        }

        /// <summary>
        /// This method lets you sign an advocate up for your referral program.
        /// If the advocate already exsits, you can use this method to retrieve the advocate's referral link and Portal Sharing Page address.
        /// </summary>
        public SignupResponse Signup(SignupRequest signupRequest)
        {
            return new SignupResponse(PostRequest(signupRequest).Result);
        }

        /// <summary>
        /// This method lets you send out an in-app invite to a contact.
        /// </summary>
        public InviteResponse Invite(InviteRequest inviteRequest)
        {
            return new InviteResponse(PostRequest(inviteRequest).Result);
        }

        /// <summary>
        /// This method lets you unsubscribe and resubscribe a contact in your referral program.
        /// </summary>
        public UpdateUnsubscribedResponse UpdateUnsubscribed(UpdateUnsubscribedRequest updateUnsubscribedRequest)
        {
            return new UpdateUnsubscribedResponse(PostRequest(updateUnsubscribedRequest).Result);
        }

        ///// <summary>
        ///// This method lets you query for rewards which match some criteria.
        ///// </summary>
        public GetRewardsResponse GetRewards(GetRewardsRequest getRewardsRequest)
        {
            return new GetRewardsResponse(GetRequest(getRewardsRequest).Result);
        }

        /// <summary>
        /// This method lets you update a custom reward.
        /// </summary>
        public UpdateRewardResponse UpdateReward(UpdateRewardRequest updateRewardRequest)
        {
            return new UpdateRewardResponse(PostRequest(updateRewardRequest).Result);
        }
    }
}
