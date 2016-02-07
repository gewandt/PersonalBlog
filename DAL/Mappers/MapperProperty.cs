using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Entities;
using ORM;

namespace DAL.Mappers
{
    public static class MapperProperty
    {
        #region DAL to Model

        public static User ToModel(this DalUserEntity item)
        {
            if (item == null)
                return null;

            User userEntity = new User
            {
                Id = item.Id,
                Name = item.Name,
                Password = item.Password,
                RoleId = item.DalRole.Id
            };
            return userEntity;
        }

        public static Role ToModel(this DalRoleEntity item)
        {
            if (item == null)
                return null;
            Role roleEntity = new Role
            {
                Id = item.Id,
                Name = item.Name
            };
            return roleEntity;
        }

        public static Blog ToModel(this DalBlogEntity item)
        {
            if (item == null)
                return null;

            Blog blogEntity = new Blog
            {
                Id = item.Id,
                Name = item.Name,
                UserId = item.User.Id
            };
            return blogEntity;
        }

        public static Article ToModel(this DalArticleEntity item)
        {
            if (item == null)
                return null;

            Article articleEntity = new Article
            {
                //Id = item.Id,
                Name = item.Name,
                BlogId = item.Blog.Id,
                Text = item.Text,
                Date = item.Date
            };
            return articleEntity;
        }

        #endregion

        #region Model to DAL

        public static DalUserEntity ToDal(this User item)
        {
            if (item == null)
                return null;

            DalUserEntity userDalEntity = new DalUserEntity
            {
                Id = item.Id,
                Name = item.Name,
                Password = item.Password,
                DalRole = item.Role.ToDal()
            };
            return userDalEntity;
        }

        public static DalRoleEntity ToDal(this Role item)
        {
            if (item == null)
                return null;

            DalRoleEntity roleDalEntity = new DalRoleEntity
            {
                Id = item.Id,
                Name = item.Name
            };
            return roleDalEntity;
        }

        public static DalBlogEntity ToDal(this Blog item)
        {
            if (item == null)
                return null;

            DalBlogEntity blogDalEntity = new DalBlogEntity
            {
                Id = item.Id,
                Name = item.Name,
                User = item.User.ToDal()
            };
            return blogDalEntity;
        }

        public static DalArticleEntity ToDal(this Article item)
        {
            if (item == null)
                return null;

            DalArticleEntity articleDalEntity = new DalArticleEntity
            {
                Id = item.Id,
                Name = item.Name,
                Blog = item.Blog.ToDal(),
                Date = item.Date,
                Text = item.Text
            };
            return articleDalEntity;
        }

        #endregion
    }
}
