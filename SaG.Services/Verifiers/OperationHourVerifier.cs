using System;
using SaG.Services.Contracts.Verifiers;
using SaG.Business.Models;

namespace SaG.Services.Verifiers
{
    public class OperationHourVerifier : IOperationHourVerifier
    {
        public bool Verify(int hour)
        {
            return !(hour < 0 || hour > 23);
        }

        public bool VerifySealOpHour(OperationCode operationCode, Seal seal)
        {
            int startHour = operationCode.StartDateTime.HasValue ? operationCode.StartDateTime.Value.Hour : 0;
            int endHour = operationCode.EndDateTime.HasValue ? operationCode.EndDateTime.Value.Hour : 0;

            if ((((DateTime)operationCode.EndDateTime).Day >= ((DateTime)operationCode.StartDateTime).Day)
                && ((seal.Hour >= startHour) && (seal.Hour <= endHour)))
                return true;
            if ((seal.Hour >= startHour) && (seal.Hour < 24))
                return true;
            return ((seal.Hour >= 0) && (seal.Hour <= endHour));
        }
    }
}
