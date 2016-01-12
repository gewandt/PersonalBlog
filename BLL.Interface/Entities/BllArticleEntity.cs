using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    public class BllArticleEntity : IBllEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public BllTagEntity Tag { get; set; }
        public BllBlogEntity Blog { get; set; }
        public DateTime Date { get; set; }
    }
}
