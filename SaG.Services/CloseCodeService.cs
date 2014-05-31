using System;
using System.Data.SqlTypes;
using System.Globalization;
using SaG.Business;
using SaG.Business.Models;
using SaG.Data;
using SaG.Data.Repositories;
using SaG.Services.Contracts;
using SaG.Services.Contracts.Verifiers;
using SaG.Business.Models.Views;
using SaG.Services.Exceptions;

namespace SaG.Services
{
    public class CloseCodeService : ICloseCodeService
    {
        private readonly IAtmService atmService;
        private readonly IEmployeeService employeeService;
        private readonly IOperationCodeVerifier operationCodeVerifier;
        private readonly IOperationResultVerifier operationResultVerifier;
        private readonly IOperationHourVerifier operationHourVerifier;
        private readonly ISealVerifier sealVerifier;
        private readonly ISecurityCodeVerifier securityCodeVerifier;
        private readonly IOperationCodeRepository operationCodeRepository;
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Lock> lockRepository;
        private readonly IRepository<Atm> atmRepository;
        private readonly IRepository<TouchKey> touchKeyRepository;
        private readonly IClosedCodeArchiveService closedCodeArchiveService;
        private readonly IAuditTrailService auditTrail;

        public CloseCodeService(IAtmService atmService,
            IEmployeeService employeeService,
            IOperationCodeVerifier operationCodeVerifier,
            IOperationResultVerifier operationResultVerifier,
            IOperationHourVerifier operationHourVerifier,
            ISealVerifier sealVerifier,
            ISecurityCodeVerifier securityCodeVerifier,
            IOperationCodeRepository operationCodeRepository,
            IRepository<User> userRepository,
            IRepository<Lock> lockRepository,
            IRepository<Atm> atmRepository,
            IRepository<TouchKey> touchKeyRepository,
            IClosedCodeArchiveService closedCodeArchiveService,
            IAuditTrailService auditTrail)
        {
            this.atmService = atmService;
            this.employeeService = employeeService;
            this.operationCodeVerifier = operationCodeVerifier;
            this.operationResultVerifier = operationResultVerifier;
            this.operationCodeRepository = operationCodeRepository;
            this.userRepository = userRepository;
            this.lockRepository = lockRepository;
            this.atmRepository = atmRepository;
            this.touchKeyRepository = touchKeyRepository;
            this.sealVerifier = sealVerifier;
            this.securityCodeVerifier = securityCodeVerifier;
            this.operationHourVerifier = operationHourVerifier;
            this.closedCodeArchiveService = closedCodeArchiveService;
            this.auditTrail = auditTrail;
        }

        public bool CloseCodeA(int opCode, string atmId, string operationResult)
        {
            AtmView atm;
            if (!this.atmService.VerifyAtm(atmId, out atm))
                throw new MethodArgumentException("ATM ID");

            OperationCode operationCode;
            if (!this.operationCodeVerifier.Verify(opCode, atm.AtmEntity, out operationCode))
                throw new CodeAlreadyClosedException(opCode);

            if(!this.operationCodeVerifier.VerifyClose(operationCode, UserType.User))
                throw new MethodArgumentException("Operation Code");

            if(!this.operationResultVerifier.Verify(operationResult))
                throw new MethodArgumentException("Operation Result");

            operationCode.DateClosed = DateTime.Now;
            operationCode.LockResult = operationResult;   
            User user = this.userRepository.GetById(operationCode.OpCodeRecipient.AccessorId);
            if (user != null)
            {   
                user.Status = false; 
                this.userRepository.Save(user);
            }
            operationCode.Atm.Status = false;  
            operationCode.TouchKey.Status = false;

            if (operationCode.Atm.Lock != null)
            {
                if (operationCode.Atm.Lock.LockId != "(unassigned)")
                    operationCode.Atm.Lock.ChangeStatus = false;

                if (operationResult == "0" || operationResult == "S")
                {
                    switch (operationCode.Cmd.CmdId)
                    {
                        case 1:
                            operationCode.Atm.Lock.LockInitialize = true;
                            operationCode.Atm.Lock.PendLockInitialize = false;
                            operationCode.Atm.Lock.UpdateDate = DateTime.Now;
                            break;
                        case 2:
                            operationCode.Atm.Lock.BankModeStatus = operationCode.Atm.Lock.PendBankModeStatus;
                            operationCode.Atm.Lock.BankModeStart = operationCode.Atm.Lock.PendBankModeStart;
                            operationCode.Atm.Lock.BankModeEnd = operationCode.Atm.Lock.PendBankModeEnd;
                            operationCode.Atm.Lock.TampResetStatus = operationCode.Atm.Lock.PendTampResetStatus;
                            operationCode.Atm.Lock.AuditStatus = operationCode.Atm.Lock.PendAuditStatus;
                            operationCode.Atm.Lock.PCcode = operationCode.Atm.Lock.PendPCcode;
                            operationCode.Atm.Lock.OCcode = operationCode.Atm.Lock.PendOCcode;
                            operationCode.Atm.Lock.ErasePcoc = operationCode.Atm.Lock.PendErasePcoc;
                            break;
                        case 256:
                            // TODO
                            operationCode.Atm.Lock.LockInitialize = false;
                            operationCode.Atm.Lock.PendBankModeStatus = "0";
                            operationCode.Atm.Lock.PendBankModeStart = SqlDateTime.MinValue.Value;
                            operationCode.Atm.Lock.PendBankModeEnd = SqlDateTime.MinValue.Value;
                            operationCode.Atm.Lock.PendTampResetStatus = "0";
                            operationCode.Atm.Lock.PendAuditStatus = "0";
                            operationCode.Atm.Lock.PendLockInitialize = false;
                            operationCode.Atm.Lock.PendLockUnInstall = false;
                            operationCode.Atm.Lock.PendPCcode = 0;
                            operationCode.Atm.Lock.PendOCcode = 0;
                            operationCode.Atm.Lock.PendErasePcoc = false;
                            operationCode.Atm.Lock.UpdateDate = DateTime.Now;
                            this.lockRepository.Save(operationCode.Atm.Lock);
                            Lock unAssignedLock = this.lockRepository.GetById(1);
                            operationCode.Atm.Lock = unAssignedLock;
                            break;
                    }
                }

                if (operationCode.Cmd.CmdId != 256 && operationCode.Atm.Lock.LockId != "(unassigned)")
                {
                    operationCode.Atm.Lock.PendBankModeStatus = "0";
                    operationCode.Atm.Lock.PendBankModeStart = SqlDateTime.MinValue.Value;
                    operationCode.Atm.Lock.PendBankModeEnd = SqlDateTime.MinValue.Value;
                    operationCode.Atm.Lock.PendTampResetStatus = "0";
                    operationCode.Atm.Lock.PendAuditStatus = "0";
                    operationCode.Atm.Lock.PendLockInitialize = false;
                    operationCode.Atm.Lock.PendLockUnInstall = false;
                    operationCode.Atm.Lock.PendPCcode = 0;
                    operationCode.Atm.Lock.PendOCcode = 0;
                    operationCode.Atm.Lock.PendErasePcoc = false;
                    operationCode.Atm.Lock.UpdateDate = DateTime.Now;
                }
            }
            this.atmRepository.Save(operationCode.Atm);
            this.touchKeyRepository.Save(operationCode.TouchKey);
            this.operationCodeRepository.Save(operationCode);
            this.auditTrail.Audit(AuditType.Close, "Lock Init", "Lock ID", opCode.ToString(CultureInfo.InvariantCulture));
            this.closedCodeArchiveService.Archive(opCode);
            return true;
        }

        public bool CloseCodeViaSealA(string userId, string operationResult)
        {
            const string locationId = "0";

            User user;
            if (!this.employeeService.VerifyUser(userId, out user))
                throw new MethodArgumentException("User ID");

            Seal seal;
            if (!this.sealVerifier.Verify(operationResult, out seal))
                throw new MethodArgumentException("Seal");

            OperationCodeDetailView operationCodeDetail;
            if (!this.operationCodeVerifier.VerifySealA(user.AccessorId, locationId, out operationCodeDetail))
                throw new CodeAlreadyClosedException(operationCodeDetail.operationCode.Code ?? 0);
            
            Atm atm = operationCodeDetail.atm;
            OperationCode operationCode = operationCodeDetail.operationCode;

            if (!this.operationCodeVerifier.Verify(operationCode.Code??0, atm.AtmEntity, out operationCode))
                throw new CodeAlreadyClosedException(operationCode.Code ?? 0);

            if (!this.securityCodeVerifier.Verify(operationCodeDetail, seal, out seal))
                throw new MethodArgumentException("Secure Code");

            if (this.operationHourVerifier.VerifySealOpHour(operationCode, seal))
                throw new InvalidOperationHourException(seal.Hour);
            
            operationResult = seal.Result == 0 ? "0" : "F";    
            operationCode.DateClosed = DateTime.Now;
            operationCode.LockResult = operationResult;  
           
            user.Status = false;
            this.userRepository.Save(user);
           
            operationCode.Atm.Status = false;
            operationCode.TouchKey.Status = false;

            if (operationCode.Atm.Lock != null)
            {
                if (operationCode.Atm.Lock.LockId != "(unassigned)")
                    operationCode.Atm.Lock.ChangeStatus = false;

                if (operationResult == "0" || operationResult == "S")
                {
                    switch (operationCode.Cmd.CmdId)
                    {
                        case 1:
                            operationCode.Atm.Lock.LockInitialize = true;
                            operationCode.Atm.Lock.PendLockInitialize = false;
                            operationCode.Atm.Lock.UpdateDate = DateTime.Now;
                            break;
                        case 2:
                            operationCode.Atm.Lock.BankModeStatus = operationCode.Atm.Lock.PendBankModeStatus;
                            operationCode.Atm.Lock.BankModeStart = operationCode.Atm.Lock.PendBankModeStart;
                            operationCode.Atm.Lock.BankModeEnd = operationCode.Atm.Lock.PendBankModeEnd;
                            operationCode.Atm.Lock.TampResetStatus = operationCode.Atm.Lock.PendTampResetStatus;
                            operationCode.Atm.Lock.AuditStatus = operationCode.Atm.Lock.PendAuditStatus;
                            operationCode.Atm.Lock.PCcode = operationCode.Atm.Lock.PendPCcode;
                            operationCode.Atm.Lock.OCcode = operationCode.Atm.Lock.PendOCcode;
                            operationCode.Atm.Lock.ErasePcoc = operationCode.Atm.Lock.PendErasePcoc;
                            break;
                        case 256:
                            // TODO
                            operationCode.Atm.Lock.LockInitialize = false;
                            operationCode.Atm.Lock.PendBankModeStatus = "0";
                            operationCode.Atm.Lock.PendBankModeStart = SqlDateTime.MinValue.Value;
                            operationCode.Atm.Lock.PendBankModeEnd = SqlDateTime.MinValue.Value;
                            operationCode.Atm.Lock.PendTampResetStatus = "0";
                            operationCode.Atm.Lock.PendAuditStatus = "0";
                            operationCode.Atm.Lock.PendLockInitialize = false;
                            operationCode.Atm.Lock.PendLockUnInstall = false;
                            operationCode.Atm.Lock.PendPCcode = 0;
                            operationCode.Atm.Lock.PendOCcode = 0;
                            operationCode.Atm.Lock.PendErasePcoc = false;
                            operationCode.Atm.Lock.UpdateDate = DateTime.Now;
                            this.lockRepository.Save(operationCode.Atm.Lock);
                            Lock unAssignedLock = this.lockRepository.GetById(1);
                            operationCode.Atm.Lock = unAssignedLock;
                            break;
                    }
                }

                if (operationCode.Cmd.CmdId != 256 && operationCode.Atm.Lock.LockId != "(unassigned)")
                {
                    operationCode.Atm.Lock.PendBankModeStatus = "0";
                    operationCode.Atm.Lock.PendBankModeStart = SqlDateTime.MinValue.Value;
                    operationCode.Atm.Lock.PendBankModeEnd = SqlDateTime.MinValue.Value;
                    operationCode.Atm.Lock.PendTampResetStatus = "0";
                    operationCode.Atm.Lock.PendAuditStatus = "0";
                    operationCode.Atm.Lock.PendLockInitialize = false;
                    operationCode.Atm.Lock.PendLockUnInstall = false;
                    operationCode.Atm.Lock.PendPCcode = 0;
                    operationCode.Atm.Lock.PendOCcode = 0;
                    operationCode.Atm.Lock.PendErasePcoc = false;
                    operationCode.Atm.Lock.UpdateDate = DateTime.Now;
                }
            }
            this.atmRepository.Save(operationCode.Atm);
            this.touchKeyRepository.Save(operationCode.TouchKey);
            this.operationCodeRepository.Save(operationCode);

            // audit trail
            this.auditTrail.Audit(AuditType.Close, "Lock Init", "Lock ID", operationCode.Code.ToString());

            // Archive close code operation
            this.closedCodeArchiveService.Archive(operationCode.Code??0);
            return true;
        }
    }
}
