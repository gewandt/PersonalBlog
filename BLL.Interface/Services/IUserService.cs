using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IUserService
    {
        bool CreateUser(UserEntity user);
        bool DeleteUser(int userId);
        bool EditUser(UserEntity user);
        UserEntity GetUser(int userId);
        IEnumerable<UserEntity> GetUsers();
    }
}
