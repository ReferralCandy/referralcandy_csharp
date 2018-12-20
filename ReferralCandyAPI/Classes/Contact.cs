using System;
using System.Collections.Generic;

namespace ReferralCandyAPI.Classes
{
    public class Contact
    {
        public int id { get; private set; }
        public string first_name { get; private set; }
        public string last_name { get; private set; }
        public string email { get; private set; }
        public bool purchase_made { get; private set; }
        public List<Purchase> purchases { get; private set; }
        public bool unsubscribed { get; private set; }

        public Contact(int id,
                        string first_name,
                        string last_name,
                        string email,
                        bool purchase_made,
                        List<Purchase> purchases,
                        bool unsubscribed)
        {
            this.id             = id;
            this.first_name     = first_name;
            this.last_name      = last_name;
            this.email          = email;
            this.purchase_made  = purchase_made;
            this.purchases      = purchases;
            this.unsubscribed   = unsubscribed;
        }
    }
}
