using System;
using BlogEntity.Interfaces;

namespace DAL.Interface.Entities
{
    public class DalRoleDalEntity : IDalEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
