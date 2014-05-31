using System.Linq;
using SaG.Services.Contracts.Verifiers;

namespace SaG.Services.Verifiers
{
    public class TimeBlockVerifier : ITimeBlockVerifier
    {
        public bool Verify(int hour)
        {
            var validLimits = new[] { 4, 8, 12, 24 };
            return validLimits.Any(x => x == hour);
        }
    }
}
