using SaG.Business.Models;
using SaG.Data.Repositories;

namespace SaG.Data.NHibernate.Repositories
{
    public class AtmRepository : Repository<Atm>, IAtmRepository
    {
        public AtmRepository(IDataProvider dataProvider)
            : base(dataProvider)
        {
        }
    }
}
