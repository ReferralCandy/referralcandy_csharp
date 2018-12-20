using System;
namespace ReferralCandyAPI.Classes
{
    public class Reward
    {
        public enum Status
        {
            pending_fulfillment,
            delivered,
            not_applicable,
            all
        }

        public enum Type
        {
            cash,
            coupon,
            custom,
            none,
            all
        };

        public string advocate_email { get; private set; }
        public string advocate_name { get; private set; }
        public int created_at { get; private set; }
        public string description { get; private set; }
        public string discount { get; private set; }
        public Status status { get; private set; }
        public Type type { get; private set; }

        public Reward(string advocate_email,
                        string advocate_name,
                        int created_at,
                        string description,
                        string discount,
                        string status,
                        string type)
        {
            this.advocate_email = advocate_email;
            this.advocate_name  = advocate_name;
            this.created_at     = created_at;
            this.description    = description;
            this.discount       = discount;
            this.status         = (Status)Enum.Parse(typeof(Status), status);
            this.type           = (Type)Enum.Parse(typeof(Type), type);
        }
    }
}
