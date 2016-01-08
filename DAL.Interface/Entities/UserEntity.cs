using System;
using BlogEntity.Interfaces;

namespace DAL.Interface.Entities
{
    public class UserEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
