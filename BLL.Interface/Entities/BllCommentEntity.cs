using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogEntity.Interfaces;

namespace BLL.Interface.Entities
{
    public class BllCommentEntity : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public BllArticleEntity Article { get; set; }
        public BllUserEntity User { get; set; }
        public DateTime Date { get; set; }
    }
}
