using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogEntity.Interfaces;

namespace BLL.Interface.Entities
{
    public class BllBlogEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BllUserEntity User { get; set; }
    }
}
