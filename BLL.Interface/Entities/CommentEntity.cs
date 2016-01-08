using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogEntity.Interfaces;

namespace BLL.Interface.Entities
{
    public class CommentEntity : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int ArticleId { get; set; }
        public int UserId { get; set; }
    }
}
