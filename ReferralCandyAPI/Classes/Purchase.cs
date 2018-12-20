using System;
namespace ReferralCandyAPI.Classes
{
    public class Purchase
    {
        public int purchased_at { get; private set; }
        public decimal amount { get; private set; }

        public Purchase(int purchased_at, decimal amount)
        {
            this.purchased_at   = purchased_at;
            this.amount         = amount;
        }
    }
}
