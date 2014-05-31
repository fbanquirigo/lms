using SaG.Business.Models;

namespace SaG.Data.Repositories
{
    public interface ICommandRepository : IKeyedRepository<Cmd, int>
    {
        Cmd GetByDescription(string description);

        Cmd GetByCommandHex(string hex);
    }
}