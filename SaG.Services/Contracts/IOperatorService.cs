using SaG.Business.Models;

namespace SaG.Services.Contracts
{
    public interface IOperatorService
    {
        bool ValidOperatorLogin(string username, string password);

        Operator GetOperator(string username);
    }
}