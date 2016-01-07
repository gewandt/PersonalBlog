using System;
using BlogEntity.Interfaces;

namespace BlogEntity.Entities
{
    public class UserEntity : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int RoleId { get; set; }
    }
}
