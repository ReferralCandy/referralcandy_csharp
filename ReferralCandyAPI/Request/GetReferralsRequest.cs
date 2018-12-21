using System;
using System.Diagnostics;

namespace ReferralCandyAPI.Request
{
    public class GetReferralsRequest : BaseRequest
    {
        /// <summary>
        /// This method lets you query for referred purchases made over some period of time
        /// </summary>
        /// <param name="period_from">UNIX timestamp of start of query period</param>
        /// <param name="pending_review_only">Whether to only return referred purchases that are pending the review period. Defaults to false</param>
        /// <param name="period_to">UNIX timestamp of end of query period. Defaults to most recent timestamp</param>
        /// <param name="customer_email">Return referred purchases made by advocate if set. Return all referred purchases if not set</param>
        public GetReferralsRequest(string period_from,
                                    bool pending_review_only,
                                    string period_to = "",
                                    string customer_email = "") : base ("referrals")
        {
            string period_from_unix = "";
            try
            {
                period_from_unix = ReferralCandy.ToUnixTimestamp(Convert.ToDateTime(period_from));
            }
            catch
            {
                Console.WriteLine("'period_from' could not be converted to a DateTime object");
                Debug.WriteLine("'period_from' could not be converted to a DateTime object");
            }

            if (period_to.Length > 0)
            {
                try
                {
                    string period_to_unix = ReferralCandy.ToUnixTimestamp(Convert.ToDateTime(period_to));
                    Parameters.Add("period_to", period_to_unix);
                } catch
                {
                    Console.WriteLine("'period_to' could not be converted to a DateTime object");
                    Debug.WriteLine("'period_to' could not be converted to a DateTime object");
                }
            }

            if (customer_email.Length > 0)
                Parameters.Add("customer_email", customer_email);

            Parameters.Add("period_from", period_from_unix);
            Parameters.Add("pending_review_only", pending_review_only.ToString().ToLower());
        }
    }
}
