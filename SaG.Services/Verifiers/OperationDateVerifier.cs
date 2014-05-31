using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SaG.Business.Models;
using SaG.Business.Models.Views;
using SaG.Data.Repositories;
using SaG.Services.Contracts.Verifiers;

namespace SaG.Services.Verifiers
{
    public class OperationDateVerifier : IOperationDateVerifier
    {
        private readonly IOperationCodeRepository operationCodeRepository;
        private readonly IOpCodeAuditRepository opCodeAuditRepository;

        public OperationDateVerifier(IOperationCodeRepository operationCodeRepository, IOpCodeAuditRepository opCodeAuditRepository)
        {
            this.operationCodeRepository = operationCodeRepository;
            this.opCodeAuditRepository = opCodeAuditRepository;
        }

        public bool Verify(string date, out DateTime? resultDate)
        {
            DateTime temp;
            if (DateTime.TryParseExact(date,
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out temp))
            {
                resultDate = temp;
                return true;
            }

            if (DateTime.TryParseExact(date,
                "dd-MM-yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out temp))
            {
                resultDate = temp;
                return true;
            }

            if (DateTime.TryParseExact(date,
                "ddMMyyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out temp))
            {
                resultDate = temp;
                return true;
            }

            resultDate = null;
            return false;
        }

        public bool Verify(AtmView atm, int cmdId, string employeeId, out DateTime operationDate, out int timeBlock)
        {
            var fromDate = DateTime.Now.Date.AddDays(-1);
            IEnumerable<OperationCode> opCodes = this.operationCodeRepository.GetOperationCodes(atm.AtmEntity, cmdId,
                employeeId, fromDate);

            IEnumerable<OpCodeAudit> audits = this.opCodeAuditRepository.GetOpCodeAudits(atm.AtmEntity, "Access Lock",
                employeeId, fromDate);

            var nowString = DateTime.Now.ToString("yyyy/MM/dd HH:00");
            DateTime now;
            DateTime.TryParseExact(nowString, "yyyy/MM/dd HH:00", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out now);

            timeBlock = 0;
            for (var i = 0; i <= 2; i++)
            {
                var hourLimit = 4;
                if (DateOk(opCodes, audits, now, hourLimit))
                {
                    timeBlock = hourLimit;
                    operationDate = now;
                    return true;
                }

                hourLimit = 8;
                if (DateOk(opCodes, audits, now, hourLimit))
                {
                    timeBlock = hourLimit;
                    operationDate = now;
                    return true;
                }

                hourLimit = 12;
                if (DateOk(opCodes, audits, now, hourLimit))
                {
                    timeBlock = hourLimit;
                    operationDate = now;
                    return true;
                }
                now = now.AddHours(-1);
            }

            if (timeBlock == 0)
            {
                operationDate = default(DateTime);
                return false;
            }

            operationDate = now;
            return atm.AtmDateRange.InRange(now);
        }

        public bool VerifyNow2A(AtmView atm, int cmdId, string employeeId, out DateTime operationDate, out int timeBlock)
        {
            var fromDate = DateTime.Now.Date.AddDays(-1);
            IEnumerable<OperationCode> opCodes = this.operationCodeRepository.GetOperationCodes(atm.AtmEntity, cmdId,
                employeeId, fromDate);

            IEnumerable<OpCodeAudit> audits = this.opCodeAuditRepository.GetOpCodeAudits(atm.AtmEntity, "Access Lock",
                employeeId, fromDate);

            var nowString = DateTime.Now.ToString("yyyy/MM/dd HH:00");
            DateTime now;
            DateTime.TryParseExact(nowString, "yyyy/MM/dd HH:00", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out now);

            timeBlock = 0;
            for (var i = 0; i <= 10; i++)
            {
                var hourLimit = 12;
                if (DateOk(opCodes, audits, now, hourLimit))
                {
                    timeBlock = hourLimit;
                    operationDate = now;
                    return true;
                }

                now = now.AddHours(-1);
            }

            nowString = DateTime.Now.ToString("yyyy/MM/dd HH:00");
            DateTime.TryParseExact(nowString, "yyyy/MM/dd HH:00", CultureInfo.InvariantCulture,
               DateTimeStyles.None, out now);
            for (var i = 0; i <= 2; i++)
            {
                var hourLimit = 8;
                if (DateOk(opCodes, audits, now, hourLimit))
                {
                    timeBlock = hourLimit;
                    operationDate = now;
                    return true;
                }

                now = now.AddHours(-1);
            }

            if (timeBlock == 0)
            {
                operationDate = default(DateTime);
                return false;
            }

            operationDate = now;
            return atm.AtmDateRange.InRange(now);
        }

        private bool DateOk(IEnumerable<OperationCode> opCodes, IEnumerable<OpCodeAudit> audits, DateTime date, int duration)
        {
            DateTime startDate = date;
            DateTime endDate = date.AddHours(duration);

            if(opCodes.Any(x => x.StartDateTime == startDate && x.EndDateTime == endDate))
                return false;

            if (audits.Any(x => x.StartDtTime == startDate && x.EndDtTime == endDate))
                return false;

            return true;
        }

        private bool VerifyAtmDateRange(IEnumerable<OperationCode> opCodes, IEnumerable<OpCodeAudit> audits, DateTime date, int duration)
        {
            DateTime startDate = date;
            DateTime endDate = date.AddHours(duration);

            if (opCodes.Any(x => x.StartDateTime == startDate && x.EndDateTime == endDate))
                return false;

            if (audits.Any(x => x.StartDtTime == startDate && x.EndDtTime == endDate))
                return false;

            return true;
        }
    }
}
