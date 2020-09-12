using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUserTest
    {
        List<UserTest> GetAllUserTests();
        UserTest GetUserTestDetails(int id);
        int CreateUserTest(UserTest usertest);
        int UpdateUserTest(UserTest usertest);
        int DeleteUserTest(int id);

        List<UserTestLog> GetUserTestLog(int id, string email);


    }
}
