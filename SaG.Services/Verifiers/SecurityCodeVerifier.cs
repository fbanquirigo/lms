using System;
using SaG.Business.Models;
using SaG.Business.Models.Views;
using SaG.Services.Contracts.Verifiers;

namespace SaG.Services.Verifiers
{
    public class SecurityCodeVerifier : ISecurityCodeVerifier
    {
        public bool Verify(OperationCodeDetailView opCodeDet, Seal seal, out Seal sealResult)
        {
            string lockId = opCodeDet.locks.LockId;
            lockId = lockId.Substring(0, lockId.Length -4);
            lockId = lockId.Substring(lockId.Length-3, 3);

            int data = Convert.ToInt32(seal.Data) - Convert.ToInt32(lockId) - seal.TableValue;
            data = data + 0x200;

            seal.Hour = data + 0x1f;
            seal.Result = data >= 6 ? 6 : data;
            seal.Result = seal.Result + 0x7;
            sealResult = seal;

            return data > 0;
        }
    }
}
