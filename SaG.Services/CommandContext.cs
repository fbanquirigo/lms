using SaG.Business.Models;
using SaG.Data.Repositories;

namespace SaG.Services
{
    public class CommandContext : ICommandContext
    {
        private readonly ICommandRepository commandRepository;
        private int? openLockCommandId;
        
        public CommandContext(ICommandRepository commandRepository)
        {
            this.commandRepository = commandRepository;
        }

        public int OPEN_LOCK
        {
            get
            {
                if (openLockCommandId == null)
                {
                    Cmd cmd = this.commandRepository.GetByCommandHex("800000");
                    this.openLockCommandId = cmd.CmdId;
                }
                return this.openLockCommandId.Value;
            }
        }
    }
}
