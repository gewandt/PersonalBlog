using System;
using DAL.Interface.Interfaces;

namespace DAL.Interface.Entities
{
    public class DalArticleEntity : IDalEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DalBlogEntity Blog { get; set; }
        public DateTime Date { get; set; }
    }
}
