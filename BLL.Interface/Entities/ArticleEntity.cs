using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogEntity.Interfaces;

namespace BLL.Interface.Entities
{
    public class ArticleEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int TagId { get; set; }
        public int BlogId { get; set; }
    }
}
