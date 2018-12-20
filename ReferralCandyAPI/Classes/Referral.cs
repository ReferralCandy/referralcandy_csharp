namespace ReferralCandyAPI.Classes
{
    public class Referral
    {
        public string referral_email { get; private set; }
        public int referral_timestamp { get; private set; }
        public string referring_email { get; private set; }
        public bool review_period_over { get; private set; }
        public string external_reference_id { get; private set; }

        public Referral(string referral_email,
                        int referral_timestamp,
                        string referring_email,
                        bool review_period_over,
                        string external_reference_id)
        {
            this.referral_email         = referral_email;
            this.referral_timestamp     = referral_timestamp;
            this.referring_email        = referring_email;
            this.review_period_over     = review_period_over;
            this.external_reference_id  = external_reference_id;
        }
    }
}
