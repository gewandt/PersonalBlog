using System;
using BlogEntity.Interfaces;

namespace DAL.Interface.Entities
{
    public class DalRoleEntity : IDalEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
