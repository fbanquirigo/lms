using System.Linq;
using SaG.Business.Models;
using SaG.Data.Repositories;

namespace SaG.Data.NHibernate.Repositories
{
    public class OperatorRepository : Repository<Operator>, IOperatorRepository
    {
        public OperatorRepository(IDataProvider dataProvider)
            : base(dataProvider)
        {   
        }

        public Operator GetOperator(string loginName)
        {
            return Query.FirstOrDefault(x => x.Login == loginName);
        }
    }
}