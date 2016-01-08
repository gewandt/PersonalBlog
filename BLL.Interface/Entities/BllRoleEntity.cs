using System;
using BlogEntity.Interfaces;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    public class BllRoleEntity : IBllEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
