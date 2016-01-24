using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Entities;
using DAL.Interface.Interfaces;
using ORM;

namespace DAL.Mapper
{
    public class RoleMapper : IMapper<Role, DalRoleEntity>
    {
        public Role ToEntity(DalRoleEntity item)
        {
            if (item == null)
                return null;
            Role roleEntity = new Role
            {
                Id = item.Id,
                Name = item.Name
            };
            return roleEntity;
        }

        public DalRoleEntity ToDal(Role entity)
        {
            if (entity == null)
                return null;
            return new DalRoleEntity { Id = entity.Id, Name = entity.Name };
        }

        public void CopyFields(DalRoleEntity item, Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
