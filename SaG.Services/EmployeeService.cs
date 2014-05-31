using SaG.Business.Models.Views;
using SaG.Data;
using SaG.Data.Repositories;
using SaG.Data.Repositories.ReadOnly;
using SaG.Business.Models;
using SaG.Services.Contracts;

namespace SaG.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<User> userRepository;
        private readonly IUserEmployeeViewRepository userEmployeeViewRepository;

        public EmployeeService(IUserEmployeeViewRepository userEmployeeViewRepository,
                               IRepository<User> userRepository)
        {
            this.userEmployeeViewRepository = userEmployeeViewRepository;
            this.userRepository = userRepository;
        }

        public bool VerifyUser(string userId, out UserEmployeeView user)
        {
            user = this.userEmployeeViewRepository.GetEmployee(userId);
            return user != null;
        }

        public bool VerifyUserByMiddleName(string middleName, out UserEmployeeView user)
        {
            user = this.userEmployeeViewRepository.GetEmployeeByMiddleName(middleName);
            return user != null;
        }

        public bool VerifyUser(string userId, out User user)
        {
            user = this.userEmployeeViewRepository.GetEmployee(userId, true);
            return user != null;
        }

        public bool VerifyUser(int userId, out User user)
        {
            user = this.userRepository.GetById(userId);
            return user != null;
        }
    }
}
