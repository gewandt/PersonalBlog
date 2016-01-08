using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogEntity.Interfaces;

namespace DAL.Interface.Entities
{
    public class DalCommentDalEntity : IDalEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DalArticleDalEntity ArticleDal { get; set; }
        public DalUserDalEntity UserDal { get; set; }
        public DateTime Date { get; set; }
    }
}
