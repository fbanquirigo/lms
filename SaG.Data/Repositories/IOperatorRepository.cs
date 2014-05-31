using SaG.Business.Models;

namespace SaG.Data.Repositories
{
    public interface IOperatorRepository : IRepository<Operator>
    {
        Operator GetOperator(string loginName);
    }
}