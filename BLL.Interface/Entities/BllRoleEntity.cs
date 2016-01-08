using System;
using BlogEntity.Interfaces;

namespace BLL.Interface.Entities
{
    public class BllRoleEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
