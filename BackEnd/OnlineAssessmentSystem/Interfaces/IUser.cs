using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUser
    {
        List<User> GetAllUsers();
        User GetUserDetails(int id, string email);
        int CreateUser(User user);
        int UpdateUser(User user);
        int DeleteUser(int id);

    }
}
