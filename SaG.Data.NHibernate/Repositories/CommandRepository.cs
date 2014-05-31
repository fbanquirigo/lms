using System.Linq;
using SaG.Business.Models;
using SaG.Data.Repositories;

namespace SaG.Data.NHibernate.Repositories
{
    public class CommandRepository : BaseRepository<Cmd>, ICommandRepository 
    {
        public CommandRepository(IDataProvider dataProvider)
            : base(dataProvider)
        {
        }

        public Cmd GetByDescription(string description)
        {
            return Query.FirstOrDefault(x => x.Description == description);
        }

        public Cmd GetByCommandHex(string hex)
        {
            return Query.FirstOrDefault(x => x.CmdHex == hex);
        }

        public Cmd Get(int key)
        {
            return Query.SingleOrDefault(x => x.CmdId == key);
        }
    }
}
