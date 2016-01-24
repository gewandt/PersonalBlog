using System;
using DAL.Interface.Interfaces;

namespace DAL.Interface.Entities
{
    public class DalBlogEntity : IDalEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DalUserEntity User { get; set; }
    }
}
