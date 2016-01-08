using System;
using BlogEntity.Interfaces;

namespace BLL.Interface.Entities
{
    public class BllUserEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public BllRoleEntity BllRole { get; set; }
    }
}
