using System;
using System.Globalization;
using SaG.Business.Models;
using SaG.Data;
using SaG.Data.Repositories;
using SaG.Services.Contracts;

namespace SaG.Services
{
    public class OperationCodeRecorder : IOperationCodeRecorder
    {
        private readonly IRouteDescRepository routeDescRepository;
        private readonly IOperationCodeRepository operationCodeRepository;
        private readonly IRepository<Accessor> accessorRepository;
        private readonly ITouchKeyRepository touchKeyRepository;
        private readonly IAtmRepository atmRepository;
        private readonly IRepository<Cmd> commandRepository;
        private readonly ISystemContext systemContext;

        public OperationCodeRecorder(IRouteDescRepository routeDescRepository,
            IOperationCodeRepository operationCodeRepository, 
            IRepository<Accessor> accessorRepository,
            ITouchKeyRepository touchKeyRepository,
            IAtmRepository atmRepository,
            IRepository<Cmd> commandRepository,
            ISystemContext systemContext)
        {
            this.routeDescRepository = routeDescRepository;
            this.operationCodeRepository = operationCodeRepository;
            this.accessorRepository = accessorRepository;
            this.touchKeyRepository = touchKeyRepository;
            this.atmRepository = atmRepository;
            this.commandRepository = commandRepository;
            this.systemContext = systemContext;
        }

        public bool RecordOperationCode(Atm atm, Cmd command, TouchKey touchKey, DateTime startDate, 
            int timeBlock, Accessor recipient, Accessor creator, int code)
        {
            RouteDesc routeDesc = this.routeDescRepository.GetByRouteId("(unassigned)");
            var operationCode = new OperationCode
            {
                Code = code,
                Atm = atm,
                Cmd = command,
                OpCodeCreator = creator,
                OpCodeRecipient = recipient,
                UserType = "U",
                DateAssigned = DateTime.UtcNow,
                TouchKey = touchKey,
                RouteDesc = routeDesc,
                LinkDispId = recipient.AccessorId.ToString(CultureInfo.InvariantCulture),
                UserEmployeeId = recipient.EmployeeId,
                StartDateTime = startDate,
                EndDateTime = startDate.AddHours(timeBlock),
                LocationId = this.systemContext.LocationId
            };
            this.operationCodeRepository.Save(operationCode);
            return operationCode.OpCodeEntity > 0;
        }

        public bool RecordOperationCode(int atmEntity, int commandId, string touchKeyId, DateTime startDate,
            int timeBlock, int recipientId, int operatorId, int code)
        {
            Atm atm = this.atmRepository.GetById(atmEntity);
            Accessor recipient = this.accessorRepository.GetById(recipientId);
            Accessor creator = this.accessorRepository.GetById(operatorId);
            TouchKey touchKey = this.touchKeyRepository.Get(touchKeyId);
            Cmd command = this.commandRepository.GetById(commandId);
            return RecordOperationCode(atm, command, touchKey, startDate, timeBlock, recipient, creator, code);
        }
    }
}
