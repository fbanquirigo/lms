using SaG.Business.Models.Views;

using SaG.Business.Models;

namespace SaG.Services.Contracts
{
    public interface IEmployeeService
    {
        bool VerifyUser(string userId, out UserEmployeeView user);

        bool VerifyUserByMiddleName(string middleName, out UserEmployeeView user);

        bool VerifyUser(string userId, out User user);

        bool VerifyUser(int userId, out User user);
    }
}