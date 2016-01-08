using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogEntity.Interfaces;

namespace DAL.Interface.Entities
{
    public class DalArticleEntity : IDalEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DalTagEntity Tag { get; set; }
        public DalBlogEntity Blog { get; set; }
        public DateTime Date { get; set; }
    }
}
