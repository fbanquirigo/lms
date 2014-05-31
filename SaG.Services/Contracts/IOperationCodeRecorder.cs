using System;
using SaG.Business.Models;

namespace SaG.Services.Contracts
{
    public interface IOperationCodeRecorder
    {
        bool RecordOperationCode(Atm atm, Cmd command, TouchKey touchKey, DateTime startDate, int timeBlock,
            Accessor recipient, Accessor creator, int code);

        bool RecordOperationCode(int atmEntity, int commandId, string touchKeyId, DateTime startDate,
            int timeBlock, int recipientId, int operatorId, int code);
    }
}