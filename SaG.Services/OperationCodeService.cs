using System;
using System.Globalization;
using SaG.Business;
using SaG.Business.Models;
using SaG.Business.Models.Views;
using SaG.Data.Repositories;
using SaG.Services.Contracts;
using SaG.Services.Contracts.Verifiers;
using SaG.Services.Exceptions;

namespace SaG.Services
{
    public class OperationCodeService : IOperationCodeService
    {
        private readonly IAtmService atmService;
        private readonly IEmployeeService employeeService;
        private readonly ITouchKeyService touchKeyService;
        private readonly ICommandContext commandContext;
        private readonly ILockCryptoService lockCryptoService;
        private readonly IOperationCodeRepository operationCodeRepository;
        private readonly ISystemContext systemContext;
        private readonly IClientContext clientContext;
        private readonly IOperationCodeRecorder operationCodeRecorder;
        private readonly IOperationDateVerifier operationDateVerifier;
        private readonly IOperationHourVerifier operationHourVerifier;
        private readonly IUserLevelVerifier userLevelVerifier;
        private readonly ITimeBlockVerifier timeBlockVerifier;
        private readonly ILockStatusVerifier lockStatusVerifier;
        private readonly IAuditTrailService auditTrail;

        public OperationCodeService(IAtmService atmService,
            IEmployeeService employeeService,
            ITouchKeyService touchKeyService,
            ICommandContext commandContext,
            ILockCryptoService lockCryptoService,
            IOperationCodeRepository operationCodeRepository,
            ISystemContext systemContext,
            IClientContext clientContext,
            IOperationCodeRecorder operationCodeRecorder,
            IOperationDateVerifier operationDateVerifier,
            IOperationHourVerifier operationHourVerifier,
            IUserLevelVerifier userLevelVerifier,
            ITimeBlockVerifier timeBlockVerifier,
            ILockStatusVerifier lockStatusVerifier,
            IAuditTrailService auditTrail)
        {
            this.atmService = atmService;
            this.employeeService = employeeService;
            this.touchKeyService = touchKeyService;
            this.commandContext = commandContext;
            this.lockCryptoService = lockCryptoService;
            this.operationCodeRepository = operationCodeRepository;
            this.systemContext = systemContext;
            this.clientContext = clientContext;
            this.operationCodeRecorder = operationCodeRecorder;
            this.operationDateVerifier = operationDateVerifier;
            this.operationHourVerifier = operationHourVerifier;
            this.userLevelVerifier = userLevelVerifier;
            this.timeBlockVerifier = timeBlockVerifier;
            this.lockStatusVerifier = lockStatusVerifier;
            this.auditTrail = auditTrail;
        }

        #region A Series
        public int GenerateOpenLockACode(string atmId, string userId, string touchkeyId,
            string date, int hour, int timeBlock, int lockStatus)
        {
            AtmView atm;
            if (!this.atmService.VerifyAtm(atmId, out atm))
                throw new MethodArgumentException("ATM ID");

            UserEmployeeView user;
            if (!this.employeeService.VerifyUser(userId, out user))
                throw new MethodArgumentException("User ID");

            TouchKey key;
            if (!this.touchKeyService.VerifyTouchKey(touchkeyId, user.AccessorId, out key))
                throw new MethodArgumentException("TouchKey ID");

            if (!this.userLevelVerifier.Verify(key.TypeKey, user.UserType, key.Status))
                throw new UserLevelException(userId);

            TouchKeyPos keyPos;
            if (!this.touchKeyService.VerifyTouchKeyPos(touchkeyId, this.commandContext.OPEN_LOCK, atm.DispEntity, out keyPos))
                throw new InvalidTouchKeyPositionException(touchkeyId);

            int tkPositionNo = keyPos.Position(this.commandContext.OPEN_LOCK);
            if(tkPositionNo < 0)
                throw new InvalidTouchKeyPositionException(touchkeyId);

            DateTime? operDate;
            if (string.IsNullOrEmpty(date) || !this.operationDateVerifier.Verify(date, out operDate))
                throw new InvalidOperationDateException(date);

            if(!operDate.HasValue)
                throw new InvalidOperationDateRangeException(default(DateTime), atm.AtmId);

            if (!atm.AtmDateRange.InRange(operDate.Value))
                throw new InvalidOperationDateRangeException(operDate.Value, atm.AtmId);

            
            if (!this.operationHourVerifier.Verify(hour))
                throw new InvalidOperationHourException(hour);

            if (!this.timeBlockVerifier.Verify(timeBlock))
                throw new InvalidOperationHourLimitException(timeBlock);

            if (!this.lockStatusVerifier.Verify(lockStatus, this.commandContext.OPEN_LOCK))
                throw new InvalidLockStatException(lockStatus);

            operDate = operDate.Value.AddHours(hour);
            int opCode = GenerateOpCode(this.commandContext.OPEN_LOCK,
                atm.KeyDispatcher0, atm.KeyDispatcher1, atm.DaylightSavingsObserved, operDate.Value, timeBlock, key.TouchKeyId, tkPositionNo, user.Pin, lockStatus);

            if (this.operationCodeRepository.OpCodeExists(opCode))
                throw new DuplicateOperationCodeException();

            RecordOperationCode(atm, this.commandContext.OPEN_LOCK, key, user, operDate.Value, timeBlock, opCode);
            this.auditTrail.Audit(AuditType.Generate, "Operation Code", "OpCode", opCode.ToString(CultureInfo.InvariantCulture));
            return opCode;
        }

        public int GenerateOpenLockNoTouchKeyA(string atmId, string userId, string date, int hour, int timeBlock)
        {
            AtmView atm;
            if (!this.atmService.VerifyAtm(atmId, out atm))
                throw new MethodArgumentException("ATM ID");

            UserEmployeeView user;
            if (!this.employeeService.VerifyUser(userId, out user))
                throw new MethodArgumentException("User ID");

            TouchKey key;
            if (!this.touchKeyService.VerifyTouchKey(user.AccessorId, out key))
                throw new MethodArgumentException("TouchKey ID");

            if (!this.userLevelVerifier.Verify(key.TypeKey, user.UserType, key.Status))
                throw new UserLevelException(userId);

            TouchKeyPos keyPos;
            if (!this.touchKeyService.VerifyTouchKeyPos(key.TouchKeyId, this.commandContext.OPEN_LOCK, atm.DispEntity, out keyPos))
                throw new InvalidTouchKeyPositionException(key.TouchKeyId);

            int tkPositionNo = keyPos.Position(this.commandContext.OPEN_LOCK);
            if (tkPositionNo < 0)
                throw new InvalidTouchKeyPositionException(key.TouchKeyId);

            DateTime? operDate;
            if (string.IsNullOrEmpty(date) || !this.operationDateVerifier.Verify(date, out operDate))
                throw new InvalidOperationDateException(date);

            if (!operDate.HasValue)
                throw new InvalidOperationDateRangeException(default(DateTime), atm.AtmId);

            if (!atm.AtmDateRange.InRange(operDate.Value))
                throw new InvalidOperationDateRangeException(operDate.Value, atm.AtmId);

            if (!this.operationHourVerifier.Verify(hour))
                throw new InvalidOperationHourException(hour);

            if (!this.timeBlockVerifier.Verify(timeBlock))
                throw new InvalidOperationHourLimitException(timeBlock);   

            operDate = operDate.Value.AddHours(hour);
            int opCode = GenerateOpCode(this.commandContext.OPEN_LOCK,
                atm.KeyDispatcher0, atm.KeyDispatcher1, atm.DaylightSavingsObserved, operDate.Value, timeBlock, key.TouchKeyId, tkPositionNo, user.Pin, 0);

            if (this.operationCodeRepository.OpCodeExists(opCode))
                throw new DuplicateOperationCodeException();

            RecordOperationCode(atm, this.commandContext.OPEN_LOCK, key, user, operDate.Value, timeBlock, opCode);
            this.auditTrail.Audit(AuditType.Generate, "Operation Code", "OpCode", opCode.ToString(CultureInfo.InvariantCulture));
            return opCode;
        }

        public int GenerateOpenLockNow1A(string atmId, string userId)
        {
            AtmView atm;
            if (!this.atmService.VerifyAtm(atmId, out atm))
                throw new MethodArgumentException("ATM ID");

            UserEmployeeView user;
            if (!this.employeeService.VerifyUser(userId, out user))
                throw new MethodArgumentException("User ID");

            TouchKey key;
            if (!this.touchKeyService.VerifyTouchKey(user.AccessorId, out key))
                throw new MethodArgumentException("TouchKey ID");

            if (!this.userLevelVerifier.Verify(key.TypeKey, user.UserType, key.Status))
                throw new UserLevelException(userId);

            TouchKeyPos keyPos;
            if (!this.touchKeyService.VerifyTouchKeyPos(key.TouchKeyId, this.commandContext.OPEN_LOCK, atm.DispEntity, out keyPos))
                throw new InvalidTouchKeyPositionException(key.TouchKeyId);

            int tkPositionNo = keyPos.Position(this.commandContext.OPEN_LOCK);
            if (tkPositionNo < 0)
                throw new InvalidTouchKeyPositionException(key.TouchKeyId);

            DateTime operDate;
            int timeBlock;
            if (!this.operationDateVerifier.Verify(atm, this.commandContext.OPEN_LOCK, user.EmployeeId, out operDate, out timeBlock))
                throw new InvalidOperationDateException("Now");


            int opCode = GenerateOpCode(this.commandContext.OPEN_LOCK,
                atm.KeyDispatcher0, atm.KeyDispatcher1, atm.DaylightSavingsObserved, operDate, timeBlock, key.TouchKeyId, tkPositionNo, user.Pin, 0);

            if (this.operationCodeRepository.OpCodeExists(opCode))
                throw new DuplicateOperationCodeException();

            RecordOperationCode(atm, this.commandContext.OPEN_LOCK, key, user, operDate, timeBlock, opCode);
            this.auditTrail.Audit(AuditType.Generate, "Operation Code", "OpCode", opCode.ToString(CultureInfo.InvariantCulture));
            return opCode;
        }

        public int GenerateOpenLockNow2A(string atmId, string userId)
        {
            AtmView atm;
            if (!this.atmService.VerifyAtm(atmId, out atm))
                throw new MethodArgumentException("ATM ID");

            UserEmployeeView user;
            if (!this.employeeService.VerifyUser(userId, out user))
                throw new MethodArgumentException("User ID");

            TouchKey key;
            if (!this.touchKeyService.VerifyTouchKey(user.AccessorId, out key))
                throw new MethodArgumentException("TouchKey ID");

            if (!this.userLevelVerifier.Verify(key.TypeKey, user.UserType, key.Status))
                throw new UserLevelException(userId);

            TouchKeyPos keyPos;
            if (!this.touchKeyService.VerifyTouchKeyPos(key.TouchKeyId, this.commandContext.OPEN_LOCK, atm.DispEntity, out keyPos))
                throw new InvalidTouchKeyPositionException(key.TouchKeyId);

            int tkPositionNo = keyPos.Position(this.commandContext.OPEN_LOCK);
            if (tkPositionNo < 0)
                throw new InvalidTouchKeyPositionException(key.TouchKeyId);

            DateTime operDate;
            int timeBlock;
            if (!this.operationDateVerifier.VerifyNow2A(atm, this.commandContext.OPEN_LOCK, user.EmployeeId, out operDate, out timeBlock))
                throw new InvalidOperationDateException("Now");

            int opCode = GenerateOpCode(this.commandContext.OPEN_LOCK,
                atm.KeyDispatcher0, atm.KeyDispatcher1, atm.DaylightSavingsObserved, operDate, timeBlock, key.TouchKeyId, tkPositionNo, user.Pin, 0);

            if (this.operationCodeRepository.OpCodeExists(opCode))
                throw new DuplicateOperationCodeException();

            RecordOperationCode(atm, this.commandContext.OPEN_LOCK, key, user, operDate, timeBlock, opCode);
            this.auditTrail.Audit(AuditType.Generate, "Operation Code", "OpCode", opCode.ToString(CultureInfo.InvariantCulture));
            return opCode;
        }
        #endregion A Series

        #region B Series
        public int GenerateOpenLockBCode(string lockId, string userId, string touchkeyId, string date, int hour, int timeBlock, int lockStatus)
        {
            AtmView atm;
            if (!this.atmService.VerifyAtmLock(lockId, out atm))
                throw new MethodArgumentException("Lock ID");

            UserEmployeeView user;
            if (!this.employeeService.VerifyUser(userId, out user))
                throw new MethodArgumentException("User ID");

            TouchKey key;
            if (!this.touchKeyService.VerifyTouchKey(touchkeyId, user.AccessorId, out key))
                throw new MethodArgumentException("TouchKey ID");

            if (!this.userLevelVerifier.Verify(key.TypeKey, user.UserType, key.Status))
                throw new UserLevelException(userId);

            TouchKeyPos keyPos;
            if (!this.touchKeyService.VerifyTouchKeyPos(touchkeyId, this.commandContext.OPEN_LOCK, atm.DispEntity, out keyPos))
                throw new InvalidTouchKeyPositionException(touchkeyId);

            int tkPositionNo = keyPos.Position(this.commandContext.OPEN_LOCK);
            if (tkPositionNo < 0)
                throw new InvalidTouchKeyPositionException(touchkeyId);

            DateTime? operDate;
            if (string.IsNullOrEmpty(date) || !this.operationDateVerifier.Verify(date, out operDate))
                throw new InvalidOperationDateException(date);

            if (!operDate.HasValue)
                throw new InvalidOperationDateRangeException(default(DateTime), atm.AtmId);

            if (!atm.AtmDateRange.InRange(operDate.Value))
                throw new InvalidOperationDateRangeException(operDate.Value, atm.AtmId);


            if (!this.operationHourVerifier.Verify(hour))
                throw new InvalidOperationHourException(hour);

            if (!this.timeBlockVerifier.Verify(timeBlock))
                throw new InvalidOperationHourLimitException(timeBlock);

            if (!this.lockStatusVerifier.Verify(lockStatus, this.commandContext.OPEN_LOCK))
                throw new InvalidLockStatException(lockStatus);

            operDate = operDate.Value.AddHours(hour);
            int opCode = GenerateOpCode(this.commandContext.OPEN_LOCK,
                atm.KeyDispatcher0, atm.KeyDispatcher1, atm.DaylightSavingsObserved, operDate.Value, timeBlock, key.TouchKeyId, tkPositionNo, user.Pin, lockStatus);

            if (this.operationCodeRepository.OpCodeExists(opCode))
                throw new DuplicateOperationCodeException();

            RecordOperationCode(atm, this.commandContext.OPEN_LOCK, key, user, operDate.Value, timeBlock, opCode);
            this.auditTrail.Audit(AuditType.Generate, "Operation Code", "OpCode", opCode.ToString(CultureInfo.InvariantCulture));
            return opCode;
        }

        public int GenerateOpenLockNow1B(string lockId, string userId)
        {
            AtmView atm;
            if (!this.atmService.VerifyAtmLock(lockId, out atm))
                throw new MethodArgumentException("Lock ID");

            UserEmployeeView user;
            if (!this.employeeService.VerifyUser(userId, out user))
                throw new MethodArgumentException("User ID");

            TouchKey key;
            if (!this.touchKeyService.VerifyTouchKey(user.AccessorId, out key))
                throw new MethodArgumentException("TouchKey ID");

            if (!this.userLevelVerifier.Verify(key.TypeKey, user.UserType, key.Status))
                throw new UserLevelException(userId);

            TouchKeyPos keyPos;
            if (!this.touchKeyService.VerifyTouchKeyPos(key.TouchKeyId, this.commandContext.OPEN_LOCK, atm.DispEntity, out keyPos))
                throw new InvalidTouchKeyPositionException(key.TouchKeyId);

            int tkPositionNo = keyPos.Position(this.commandContext.OPEN_LOCK);
            if (tkPositionNo < 0)
                throw new InvalidTouchKeyPositionException(key.TouchKeyId);

            DateTime operDate;
            int timeBlock;
            if (!this.operationDateVerifier.Verify(atm, this.commandContext.OPEN_LOCK, user.EmployeeId, out operDate, out timeBlock))
                throw new InvalidOperationDateException("Now");


            int opCode = GenerateOpCode(this.commandContext.OPEN_LOCK,
                atm.KeyDispatcher0, atm.KeyDispatcher1, atm.DaylightSavingsObserved, operDate, timeBlock, key.TouchKeyId, tkPositionNo, user.Pin, 0);

            if (this.operationCodeRepository.OpCodeExists(opCode))
                throw new DuplicateOperationCodeException();

            RecordOperationCode(atm, this.commandContext.OPEN_LOCK, key, user, operDate, timeBlock, opCode);
            this.auditTrail.Audit(AuditType.Generate, "Operation Code", "OpCode", opCode.ToString(CultureInfo.InvariantCulture));
            return opCode;
        }
        #endregion B Series  

        #region C Series
        public int GenerateOpenLockCCode(string atmId, string middleName, string touchkeyId, string date, int hour, int timeBlock, int lockStatus)
        {
            AtmView atm;
            if (!this.atmService.VerifyAtm(atmId, out atm))
                throw new MethodArgumentException("ATM ID");

            UserEmployeeView user;
            if (!this.employeeService.VerifyUser(middleName, out user))
                throw new MethodArgumentException("Middle Name");

            TouchKey key;
            if (!this.touchKeyService.VerifyTouchKey(touchkeyId, user.AccessorId, out key))
                throw new MethodArgumentException("TouchKey ID");

            if (!this.userLevelVerifier.Verify(key.TypeKey, user.UserType, key.Status))
                throw new UserLevelException(middleName);

            TouchKeyPos keyPos;
            if (!this.touchKeyService.VerifyTouchKeyPos(touchkeyId, this.commandContext.OPEN_LOCK, atm.DispEntity, out keyPos))
                throw new InvalidTouchKeyPositionException(touchkeyId);

            int tkPositionNo = keyPos.Position(this.commandContext.OPEN_LOCK);
            if (tkPositionNo < 0)
                throw new InvalidTouchKeyPositionException(touchkeyId);

            DateTime? operDate;
            if (string.IsNullOrEmpty(date) || !this.operationDateVerifier.Verify(date, out operDate))
                throw new InvalidOperationDateException(date);

            if (!operDate.HasValue)
                throw new InvalidOperationDateRangeException(default(DateTime), atm.AtmId);

            if (!atm.AtmDateRange.InRange(operDate.Value))
                throw new InvalidOperationDateRangeException(operDate.Value, atm.AtmId);


            if (!this.operationHourVerifier.Verify(hour))
                throw new InvalidOperationHourException(hour);

            if (!this.timeBlockVerifier.Verify(timeBlock))
                throw new InvalidOperationHourLimitException(timeBlock);

            if (!this.lockStatusVerifier.Verify(lockStatus, this.commandContext.OPEN_LOCK))
                throw new InvalidLockStatException(lockStatus);

            operDate = operDate.Value.AddHours(hour);
            int opCode = GenerateOpCode(this.commandContext.OPEN_LOCK,
                atm.KeyDispatcher0, atm.KeyDispatcher1, atm.DaylightSavingsObserved, operDate.Value, timeBlock, key.TouchKeyId, tkPositionNo, user.Pin, lockStatus);

            if (this.operationCodeRepository.OpCodeExists(opCode))
                throw new DuplicateOperationCodeException();

            RecordOperationCode(atm, this.commandContext.OPEN_LOCK, key, user, operDate.Value, timeBlock, opCode);
            this.auditTrail.Audit(AuditType.Generate, "Operation Code", "OpCode", opCode.ToString(CultureInfo.InvariantCulture));
            return opCode;
        }
        #endregion C Series  

        #region Misc
        private int GenerateOpCode(
            int commandId, string keyDispatcher0, string keyDispatcher1,
            bool dstObserved, DateTime operDate,
            int timeBlock, string touchKey, int touchKeyPos,
            string userPin, int lockStat)
        {
            string dkeyDispatcher0 = this.lockCryptoService.DecryptDBValue(keyDispatcher0, CryptoType.KeyDispatcher0);
            string dKeyDispatcher1 = this.lockCryptoService.DecryptDBValue(keyDispatcher1, CryptoType.KeyDispatcher1);

            string dUserPin = this.lockCryptoService.DecryptDBValue(userPin, CryptoType.PIN);

            if (dstObserved && timeBlock != 24)
            {
                if (this.systemContext.SystemTimeZone.IsDaylightSavingTime(operDate))
                {
                    operDate = this.systemContext.SouthernHemisphere
                        ? operDate.AddHours(1)
                        : operDate.AddHours(-1);
                }
            }

            // setup parameters
            string sHourLimit = timeBlock.ToString(CultureInfo.InvariantCulture);
            string sLockStat = String.Format("0{0}", lockStat.ToString(CultureInfo.InvariantCulture));
            const string sParm = "00000000000000000000000000000000";

            string opCode = this.lockCryptoService.GenerateOpCode(
                commandId, operDate.ToString("d"), operDate.Hour.ToString(CultureInfo.InvariantCulture), sHourLimit, sLockStat, dUserPin,
                touchKey, touchKeyPos, sParm, dkeyDispatcher0, dKeyDispatcher1);

            opCode = opCode.Trim();
            return int.Parse(opCode);
        }

        private void RecordOperationCode(AtmView atmView, int commandId, TouchKey touchKey, UserEmployeeView user,
            DateTime startDate, int timeBlock, int code)
        {
            this.operationCodeRecorder.RecordOperationCode(atmView.AtmEntity, commandId, touchKey.TouchKeyId,
                startDate, timeBlock, user.AccessorId, this.clientContext.Operator.Id, code);
        }
        #endregion Misc
    }
}
