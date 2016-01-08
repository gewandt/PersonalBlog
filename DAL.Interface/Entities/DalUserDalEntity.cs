using System;
using BlogEntity.Interfaces;

namespace DAL.Interface.Entities
{
    public class DalUserDalEntity : IDalEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DalRoleDalEntity DalRoleDal { get; set; }
    }
}
