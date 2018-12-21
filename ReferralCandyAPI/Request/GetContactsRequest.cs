namespace ReferralCandyAPI.Request
{
    public class GetContactsRequest : BaseRequest
    {
        /// <summary>
        /// This method lets you query for contacts involved in your referral campaign
        /// </summary>
        /// <param name="id">Lowest id of contact returned by query. Defaults to 1</param>
        /// <param name="limit">Number of contacts to return. Defaults to 100. Capped at 100</param>
        public GetContactsRequest(int id = 1, int limit = 100) : base("contacts")
        {
            if (id < 0)
                id = 1;

            if (limit > 100)
                limit = 100;

            Parameters.Add("id", id.ToString());
            Parameters.Add("limit", limit.ToString());
        }
    }
}
