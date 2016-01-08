using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogEntity.Interfaces;

namespace DAL.Interface.Entities
{
    public class DalCommentEntity : IDalEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DalArticleEntity Article { get; set; }
        public DalUserEntity User { get; set; }
        public DateTime Date { get; set; }
    }
}
