using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IUserService
    {
        void Create(string name, string password, BllRoleEntity role);
        bool Update(BllUserEntity item);
        void Delete(int id);
        IEnumerable<BllUserEntity> GetAll();
        string GetRole(string login);
        bool Contains(string login, string password);
        BllUserEntity Contains(string login);
    }
}
