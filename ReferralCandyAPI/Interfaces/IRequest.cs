using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ReferralCandyAPI.Interfaces
{
    public interface IRequest
    {
        string _endpoint { get; }
        string Endpoint { get; }
        SortedDictionary<string, string> Parameters { get; }

        FormUrlEncodedContent PostParameters();
        string GetRequest();
    }
}
