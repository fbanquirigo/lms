using System;
using SaG.Business.Models.Views;

namespace SaG.Services.Contracts.Verifiers
{
    public interface IOperationDateVerifier
    {
        bool Verify(string date, out DateTime? resultDate);

        bool Verify(AtmView atm, int cmdId, string employeeId, out DateTime operationDate, out int timeBlock);

        bool VerifyNow2A(AtmView atm, int cmdId, string employeeId, out DateTime operationDate, out int timeBlock);
    }
}