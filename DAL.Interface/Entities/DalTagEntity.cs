using System;
using DAL.Interface.Interfaces;

namespace DAL.Interface.Entities
{
    public class DalTagEntity : IDalEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DalArticleEntity Article { get; set; }
    }
}
