using System.Collections.Generic;

namespace ReferralCandyAPI.Interfaces
{
    public interface IRequest
    {
        Dictionary<string, string> parameters { get; }
    }
}
