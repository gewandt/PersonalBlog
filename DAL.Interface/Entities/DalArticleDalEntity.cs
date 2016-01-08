using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogEntity.Interfaces;

namespace DAL.Interface.Entities
{
    public class DalArticleDalEntity : IDalEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DalTagDalEntity TagDal { get; set; }
        public DalBlogDalEntity BlogDal { get; set; }
        public DateTime Date { get; set; }
    }
}
