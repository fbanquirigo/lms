using System.Linq;
using SaG.Business.Models;
using SaG.Data.Repositories;

namespace SaG.Data.NHibernate.Repositories
{
    public class TouchKeyRepository : BaseRepository<TouchKey>,
        ITouchKeyRepository
    {
        public TouchKeyRepository(IDataProvider dataProvider)
            : base(dataProvider)
        {   
        }

        public TouchKey Get(string touchKey, int accessorId)
        {
            return Query.SingleOrDefault(x => x.TouchKeyId == touchKey && x.Accessor.AccessorId == accessorId);
        }

        public TouchKey Get(string key)
        {
            return Query.SingleOrDefault(x => x.TouchKeyId == key);
        }

        public TouchKey Get(int accessorId)
        {
            return Query.FirstOrDefault(x => x.Accessor.AccessorId == accessorId);
        }
    }
}
