using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IRoleService : IDisposable
    {
        void Create(string name);
        bool ResetToDefault(int id);
        BllRoleEntity GetById(int id);
        BllRoleEntity GetByName(string name);
    }
}
