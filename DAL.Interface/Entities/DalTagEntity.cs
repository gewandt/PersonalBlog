using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogEntity.Interfaces;

namespace DAL.Interface.Entities
{
    public class DalTagEntity : IDalEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DalArticleEntity Article { get; set; }
    }
}
