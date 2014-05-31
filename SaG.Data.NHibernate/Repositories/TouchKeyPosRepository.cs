using System.Linq;
using SaG.Business.Models;
using SaG.Data.Repositories;

namespace SaG.Data.NHibernate.Repositories
{
    public class TouchKeyPosRepository : BaseRepository<TouchKeyPos>, ITouchKeyPosRepository
    {
        public TouchKeyPosRepository(IDataProvider dataProvider)
            : base(dataProvider)
        {   
        }

        public TouchKeyPos Get(string touchKey, int command, int dispEntity)
        {
            return Query.FirstOrDefault(x => x.TouchKeyId == touchKey
                                             && x.Dispatcher.DispEntity == dispEntity && 
                                             (x.CmdId0.CmdId == command || x.CmdId1.CmdId == command
                                                || x.CmdId2.CmdId == command || x.CmdId3.CmdId == command));
        }
    }
}
