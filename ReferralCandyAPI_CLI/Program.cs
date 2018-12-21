using System;
using ReferralCandyAPI;
using ReferralCandyAPI.Classes;
using ReferralCandyAPI.Request;
using ReferralCandyAPI.Response;

namespace ReferralCandy_Console_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting ReferralCandy API Console Example");

            // Your credentials can be found at: https://my.referralcandy.com/settings
            ReferralCandy referralCandy = new ReferralCandy(apiAccessId: "YOUR_ACCOUNT_API_ACCESS_ID",
                                                            apiSecretKey: "YOUR_ACCOUNT_API_SECRET_KEY");

            // *-- Verify your credentials --*
            VerifyResponse verifyResponse = referralCandy.Verify(new VerifyRequest());
            Console.WriteLine(verifyResponse.message);

            // *-- If verified, test the methods --*
            if (verifyResponse.status_code == 200)
            {
                //SubmitPurchase();

                //GetReferrals();

                //UpdateReferral();

                //GetReferrer();

                //GetContacts();

                //Signup();

                //Invite();

                //UpdateUnsubscribed();

                //GetRewards();

                //UpdateReward();
            }

            void SubmitPurchase()
            {
                // *-- Submit a purchase --*
                PurchaseRequest purchaseRequest
                    = new PurchaseRequest(first_name: "John",
                                            last_name: "Smith",
                                            email: "john_smith@referralcandy.com",
                                            order_timestamp: int.Parse(ReferralCandy.CurrentTimestamp()),
                                            browser_ip: "127.0.0.1",
                                            user_agent: "Chrome",
                                            invoice_amount: "9.99",
                                            currency_code: "SGD");

                PurchaseResponse purchaseResponse = referralCandy.Purchase(purchaseRequest);
                Console.WriteLine(purchaseResponse.message);
                Console.WriteLine(purchaseResponse.referralcorner_url);
            }

            void GetReferrals()
            {
                // *-- Get all referrals by an advocate --*
                GetReferralsRequest referralsRequest
                    = new GetReferralsRequest(period_from: "Jan 1, 2018",
                                                customer_email: "john_smith@referralcandy.com",
                                                pending_review_only: false);

                GetReferralsResponse referralsResponse
                    = referralCandy.GetReferrals(referralsRequest);

                Console.WriteLine(referralsResponse.message);
                Console.WriteLine(referralsResponse.period_from);
                Console.WriteLine(referralsResponse.period_to);

                foreach (Referral referral in referralsResponse.referrals)
                {
                    Console.WriteLine(referral.referral_timestamp);
                    Console.WriteLine(referral.referral_email);
                    Console.WriteLine(referral.external_reference_id);
                }
            }

            void UpdateReferral()
            {
                // *-- Update a referral --*
                UpdateReferralRequest referralRequest
                    = new UpdateReferralRequest(customer_email: "john_smith@referralcandy.com",
                                                notify: false,
                                                returned: true);

                UpdateReferralResponse referralResponse = referralCandy.UpdateReferral(referralRequest);
                Console.WriteLine(referralResponse.message);
            }

            void GetReferrer()
            {
                // *-- Get referrer of a customer --*
                GetReferrerRequest getReferrerRequest
                    = new GetReferrerRequest(customer_email: "john_smith@referralcandy.com");

                GetReferrerResponse getReferrerResponse = referralCandy.GetReferrer(getReferrerRequest);
                Console.WriteLine(getReferrerResponse.message);
                Console.WriteLine(getReferrerResponse.referrer);
            }

            void GetContacts()
            {
                GetContactsRequest getContactsRequest = new GetContactsRequest(id: 1, limit: 5);

                GetContactsResponse getContactsResponse = referralCandy.GetContacts(getContactsRequest);
                Console.WriteLine(getContactsResponse.message);

                foreach (Contact contact in getContactsResponse.contacts)
                {
                    Console.WriteLine(String.Format("id: {0} | email: {1}", contact.id, contact.email));
                    foreach (Purchase purchase in contact.purchases)
                    {
                        Console.WriteLine(String.Format("--> purchase amount: {0} | timestamp: {1}",
                                                        purchase.amount,
                                                        purchase.purchased_at));
                    }
                }
            }

            void Signup()
            {
                SignupRequest signupRequest = new SignupRequest(first_name: "John",
                                                                last_name: "Smith",
                                                                email: "john_smith@referralcandy.com");

                SignupResponse signupResponse = referralCandy.Signup(signupRequest);
                Console.WriteLine(signupResponse.message);
                Console.WriteLine(signupResponse.referralcorner_url);
                Console.WriteLine(signupResponse.referral_link);
            }

            void Invite()
            {
                InviteRequest inviteRequest = new InviteRequest("john_smith@referralcandy.com");

                InviteResponse inviteResponse = referralCandy.Invite(inviteRequest);
                Console.WriteLine(inviteResponse.message);
            }

            void UpdateUnsubscribed()
            {
                UpdateUnsubscribedRequest updateUnsubscribedRequest
                    = new UpdateUnsubscribedRequest(email: "john_smith@referralcandy.com",
                                                    unsubscribed: false);

                UpdateUnsubscribedResponse updateUnsubscribedResponse
                    = referralCandy.UpdateUnsubscribed(updateUnsubscribedRequest);

                Console.WriteLine(updateUnsubscribedResponse.message);
                Console.WriteLine(updateUnsubscribedResponse.email);
                Console.WriteLine(updateUnsubscribedResponse.unsubscribed);
            }

            void GetRewards()
            {
                GetRewardsRequest getRewardsRequest = new GetRewardsRequest();

                GetRewardsResponse getRewardsResponse = referralCandy.GetRewards(getRewardsRequest);
                Console.WriteLine(getRewardsResponse.message);

                foreach(Reward reward in getRewardsResponse.rewards)
                {
                    Console.WriteLine(reward.advocate_email);
                    Console.WriteLine(reward.created_at);
                    Console.WriteLine(reward.description);
                    Console.WriteLine(reward.discount);
                    Console.WriteLine(reward.status);
                    Console.WriteLine(reward.type);
                }
            }

            void UpdateReward()
            {
                UpdateRewardRequest updateRewardRequest
                    = new UpdateRewardRequest(id: 0, status: Reward.Status.pending_fulfillment);

                UpdateRewardResponse updateRewardResponse
                    = referralCandy.UpdateReward(updateRewardRequest);

                Console.WriteLine(updateRewardResponse.message);
                Console.WriteLine(updateRewardResponse.messages);
                Console.WriteLine(updateRewardResponse.reward);
            }
        }
    }
}
