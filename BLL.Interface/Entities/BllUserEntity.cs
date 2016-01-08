using System;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    public class BllUserEntity : IBllEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public BllRoleEntity BllRole { get; set; }
    }
}
