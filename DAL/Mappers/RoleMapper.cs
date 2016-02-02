using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Entities;
using DAL.Interface.Interfaces;
using ORM;

namespace DAL.Mappers
{
    public class RoleMapper : IMapper<Role, DalRoleEntity>
    {
        public Role ToEntity(DalRoleEntity item)
        {
            if (item == null)
                return null;
            Role roleEntity = item.ToModel();
            return roleEntity;
        }

        public DalRoleEntity ToDal(Role entity)
        {
            if (entity == null)
                return null;
            return new DalRoleEntity { Id = entity.Id, Name = entity.Name };
        }

        public IEnumerable<DalRoleEntity> ToDalCollection(IEnumerable<Role> entity)
        {
            throw new NotImplementedException();
        }
    }
}
