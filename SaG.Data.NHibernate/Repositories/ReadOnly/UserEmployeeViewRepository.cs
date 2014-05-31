using System.Linq;
using NHibernate.Linq;
using SaG.Business.Models;
using SaG.Business.Models.Views;
using SaG.Data.Repositories.ReadOnly;

namespace SaG.Data.NHibernate.Repositories.ReadOnly
{
    public class UserEmployeeViewRepository : BaseRepository<UserEmployeeView>, IUserEmployeeViewRepository
    {
        public UserEmployeeViewRepository(IDataProvider dataProvider)
            : base(dataProvider)
        {  
        }

        public UserEmployeeView GetEmployee(string employeeId)
        {
            return UserEmployeeView.FirstOrDefault(x => x.EmployeeId == employeeId);
        }

        public UserEmployeeView GetEmployeeByMiddleName(string middleName)
        {
            return UserEmployeeView.FirstOrDefault(x => x.MiddleName == middleName);
        }

        public User GetEmployee(string employeeId, bool makeDifferent = true)
        {
            UserEmployeeView userEmployee = UserEmployeeView.FirstOrDefault(x => x.EmployeeId == employeeId);
            return Session.Query<User>().FirstOrDefault(x=> x.AccessorId == userEmployee.AccessorId);
        }

        private IQueryable<UserEmployeeView> UserEmployeeView
        {
            get
            {
                return from accessor in Session.Query<Accessor>()
                    join user in Session.Query<User>() on accessor.AccessorId equals user.AccessorId
                    select new UserEmployeeView
                           {
                                AccessorId = accessor.AccessorId,
                                EmployeeId = accessor.EmployeeId,
                                UserType = user.UserType,
                                Level = user.Level.Name,
                                Pin = user.Pin,
                                MiddleName = accessor.MiddleName
                           };
            }
        }
    }
}
