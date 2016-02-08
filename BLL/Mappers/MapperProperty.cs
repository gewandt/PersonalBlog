using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.Entities;
using DAL.Interface.Interfaces;

namespace BLL.Mappers
{
    public static class MapperProperty
    {
        #region BLL to DAL

        //public static IDalEntity ToDal(this IBllEntity itemEntity)
        //{
        //    return null;
        //}

        public static DalUserEntity ToDal(this BllUserEntity itemUserEntity)
        {
            if (itemUserEntity == null)
                return null;

            DalUserEntity dalUserEntity = new DalUserEntity
            {
                Id = itemUserEntity.Id,
                Name = itemUserEntity.Name,
                Password = itemUserEntity.Password,
                DalRole = itemUserEntity.BllRole.ToDal()
            };
            return dalUserEntity;
        }
        public static DalRoleEntity ToDal(this BllRoleEntity itemRoleEntity)
        {
            if (itemRoleEntity == null)
                return null;

            return new DalRoleEntity
            {
                Id = itemRoleEntity.Id,
                Name = itemRoleEntity.Name
            };
        }

        public static DalBlogEntity ToDal(this BllBlogEntity itemBlogEntity)
        {
            if (itemBlogEntity == null)
                return null;

            return new DalBlogEntity
            {
                Id = itemBlogEntity.Id,
                Name = itemBlogEntity.Name,
                User = itemBlogEntity.User.ToDal()
            };
        }

        public static DalArticleEntity ToDal(this BllArticleEntity itemArticleEntity)
        {
            if (itemArticleEntity == null)
                return null;

            return new DalArticleEntity
            {
                Id = itemArticleEntity.Id,
                Name = itemArticleEntity.Name,
                Blog = itemArticleEntity.Blog.ToDal(),
                Date = itemArticleEntity.Date,
                Text = itemArticleEntity.Text
            };
        }

        public static DalTagEntity ToDal(this BllTagEntity itemTagEntity)
        {
            if (itemTagEntity == null)
                return null;

            return new DalTagEntity
            {
                Id = itemTagEntity.Id,
                Name = itemTagEntity.Name,
                Article = itemTagEntity.Article.ToDal()
            };
        }

        public static DalCommentEntity ToDal(this BllCommentEntity itemCommentEntity)
        {
            if (itemCommentEntity == null)
                return null;

            return new DalCommentEntity
            {
                Id = itemCommentEntity.Id,
                Text = itemCommentEntity.Text,
                Article = itemCommentEntity.Article.ToDal(),
                Date = itemCommentEntity.Date,
                User = itemCommentEntity.User.ToDal()
            };
        }

        #endregion

        #region DAL to BAL

        public static BllRoleEntity ToBal(this DalRoleEntity role)
        {
            if (role == null)
                return null;

            return new BllRoleEntity
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        public static BllUserEntity ToBal(this DalUserEntity user)
        {
            if (user == null)
                return null;

            return new BllUserEntity
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                BllRole = user.DalRole.ToBal(),
            };
        }

        public static BllBlogEntity ToBal(this DalBlogEntity itemBlogEntity)
        {
            if (itemBlogEntity == null)
                return null;

            return new BllBlogEntity
            {
                Id = itemBlogEntity.Id,
                Name = itemBlogEntity.Name,
                User = itemBlogEntity.User.ToBal()
            };
        }

        public static BllArticleEntity ToBal(this DalArticleEntity itemArticleEntity)
        {
            if (itemArticleEntity == null)
                return null;

            return new BllArticleEntity
            {
                Id = itemArticleEntity.Id,
                Blog = itemArticleEntity.Blog.ToBal(),
                Date = itemArticleEntity.Date,
                Name = itemArticleEntity.Name,
                Text = itemArticleEntity.Text
            };
        }

        public static BllTagEntity ToBal(this DalTagEntity itemTagEntity)
        {
            if (itemTagEntity == null)
                return null;

            return new BllTagEntity
            {
                Id = itemTagEntity.Id,
                Name = itemTagEntity.Name,
                Article = itemTagEntity.Article.ToBal()
            };
        }

        public static BllCommentEntity ToBal(this DalCommentEntity itemCommentEntity)
        {
            if (itemCommentEntity == null)
                return null;

            return new BllCommentEntity
            {
                Id = itemCommentEntity.Id,
                Text = itemCommentEntity.Text,
                Article = itemCommentEntity.Article.ToBal(),
                Date = itemCommentEntity.Date,
                User = itemCommentEntity.User.ToBal()
            };
        }

        #endregion
    }
}
