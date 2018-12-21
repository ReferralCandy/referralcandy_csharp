namespace ReferralCandyAPI.Request
{
    public class PurchaseRequest : BaseRequest
    {
        /// <summary>
        /// This method lets you register a new purchase at your store. A referral email will be sent to the customer.
        /// </summary>
        /// <param name="first_name">Customer's first name</param>
        /// <param name="email">Customer's email</param>
        /// <param name="order_timestamp">UNIX timestamp of order</param>
        /// <param name="browser_ip">IP address of customer when making the purchase</param>
        /// <param name="user_agent">User agent string of the customer's web browser</param>
        /// <param name="invoice_amount">Total invoice amount for this purchase</param>
        /// <param name="currency_code">ISO 4217 currency code used in order invoice (e.g. USD, GBP, INR)</param>
        public PurchaseRequest( string first_name,
                                string email,
                                int order_timestamp,
                                string browser_ip,
                                string user_agent,
                                string invoice_amount,
                                string currency_code) : base("purchase")
        {
            Parameters.Add("first_name", first_name);
            Parameters.Add("email", email);
            Parameters.Add("order_timestamp", order_timestamp.ToString());
            Parameters.Add("browser_ip", browser_ip);
            Parameters.Add("user_agent", user_agent);
            Parameters.Add("invoice_amount", invoice_amount);
            Parameters.Add("currency_code", currency_code);
            Parameters.Add("last_name", "");
            Parameters.Add("discount_code", "");
            Parameters.Add("accepts_marketing", "true");
            Parameters.Add("external_reference_id", "");
        }

        /// <summary>
        /// This method lets you register a new purchase at your store. A referral email will be sent to the customer.
        /// </summary>
        /// <param name="first_name">Customer's first name</param>
        /// <param name="email">Customer's email</param>
        /// <param name="order_timestamp">UNIX timestamp of order</param>
        /// <param name="browser_ip">IP address of customer when making the purchase</param>
        /// <param name="user_agent">User agent string of the customer's web browser</param>
        /// <param name="invoice_amount">Total invoice amount for this purchase</param>
        /// <param name="currency_code">ISO 4217 currency code used in order invoice (e.g. USD, GBP, INR)</param>
        /// <param name="last_name">Customer's last name</param>
        /// <param name="locale">
        /// Customer's preferred language. Defaults to campaign's default language if
        /// it is not set or not available to the campaign
        /// </param>
        /// <param name="discount_code">Discount code used in the order. Blank if no discount code was used</param>
        /// <param name="accepts_marketing">Whether the customer opted in to marketing. Defaults to true</param>
        /// <param name="external_reference_id">An ID that can be used to track this purchase externally</param>
        public PurchaseRequest(string first_name,
                                string email,
                                int order_timestamp,
                                string browser_ip,
                                string user_agent,
                                string invoice_amount,
                                string currency_code,
                                string last_name = "",
                                string locale = "en",
                                string discount_code = "",
                                bool accepts_marketing = true,
                                string external_reference_id = "") : base("purchase")
        {
            Parameters.Add("first_name", first_name);
            Parameters.Add("email", email);
            Parameters.Add("order_timestamp", order_timestamp.ToString());
            Parameters.Add("browser_ip", browser_ip);
            Parameters.Add("user_agent", user_agent);
            Parameters.Add("invoice_amount", invoice_amount);
            Parameters.Add("currency_code", currency_code);
            Parameters.Add("last_name", last_name);
            Parameters.Add("discount_code", discount_code);
            Parameters.Add("accepts_marketing", accepts_marketing.ToString().ToLower());
            Parameters.Add("external_reference_id", external_reference_id);
        }
    }
}
