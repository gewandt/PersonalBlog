using System;
using BlogEntity.Interfaces;

namespace BlogEntity.Entities
{
    public class RoleEntity : IEntity
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
