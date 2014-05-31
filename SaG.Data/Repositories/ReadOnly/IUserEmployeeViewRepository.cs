using SaG.Business.Models.Views;
using SaG.Business.Models;

namespace SaG.Data.Repositories.ReadOnly
{
    public interface IUserEmployeeViewRepository
    {
        UserEmployeeView GetEmployee(string employeeId);

        UserEmployeeView GetEmployeeByMiddleName(string middleName);

        User GetEmployee(string employeeId, bool makeDifferent);
    }
}