using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    public class BllBlogEntity : IBllEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BllUserEntity User { get; set; }
    }
}
