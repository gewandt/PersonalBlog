using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Entities;
using DAL.Interface.Interfaces;
using ORM;

namespace DAL.Mappers
{
    public class CommentMapper : IMapper<Comment, DalCommentEntity>
    {
        public Comment ToEntity(DalCommentEntity item)
        {
            if (item == null)
                return null;
            Comment comment = item.ToModel();
            return comment;
        }

        public DalCommentEntity ToDal(Comment item)
        {
            if (item == null)
                return null;
            return item.ToDal();
        }

        public IEnumerable<DalCommentEntity> ToDalCollection(IEnumerable<Comment> entity)
        {
            throw new NotImplementedException();
        }

        public void CopyFields(DalCommentEntity dalEntity, Comment entity)
        {
            if (dalEntity == null || entity == null)
                return;
            entity.Id = (dalEntity.Id == 0) ? entity.Id : dalEntity.Id;
            entity.ArticleId = (dalEntity.Id == 0) ? entity.ArticleId : dalEntity.Id;
            entity.Date = dalEntity.Date;
            entity.Text = dalEntity.Text ?? entity.Text;
        }
    }
}
