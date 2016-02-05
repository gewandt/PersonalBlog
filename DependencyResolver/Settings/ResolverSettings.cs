using System;
using System.Data.Entity;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using BLL.Services;
using DAL.Concrete;
using DAL.Interface.Entities;
using DAL.Interface.Interfaces;
using DAL.Interface.Repository;
using DAL.Mappers;
using DAL.Repository;
using Ninject;
using Ninject.Web.Common;
using ORM;

namespace DependencyResolver.Settings
{
    public static class ResolverSettings
    {
        public static void Configure(this IKernel kernel)
        {
            kernel.Bind<DbContext>().To<BlogDBEntities>().InRequestScope();

            kernel.Bind<IRepository<DalUserEntity>>().To<Repository<User, DalUserEntity>>().InRequestScope();
            kernel.Bind<IRepository<DalBlogEntity>>().To<Repository<Blog, DalBlogEntity>>().InRequestScope();
            kernel.Bind<IRepository<DalArticleEntity>>().To<Repository<Article, DalArticleEntity>>().InRequestScope();
            kernel.Bind<IRepository<DalCommentEntity>>().To<Repository<Comment, DalCommentEntity>>().InRequestScope();
            kernel.Bind<IRepository<DalTagEntity>>().To<Repository<Tag, DalTagEntity>>().InRequestScope();
            kernel.Bind<IRepository<DalRoleEntity>>().To<Repository<Role, DalRoleEntity>>().InRequestScope();

            kernel.Bind<IMapper<Role, DalRoleEntity>>().To<RoleMapper>().InSingletonScope();
            kernel.Bind<IMapper<User, DalUserEntity>>().To<UserMapper>().InSingletonScope();
            kernel.Bind<IMapper<Blog, DalBlogEntity>>().To<BlogMapper>().InSingletonScope();
            kernel.Bind<IMapper<Article, DalArticleEntity>>().To<ArticleMapper>().InSingletonScope();
            //kernel.Bind<IMapper<UserSkill, DalUserSkill>>().To<UserSkillMapper>().InSingletonScope();

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            //kernel.Bind<IRepository<DalRoleEntity>>().To<Repository<Role, DalRoleEntity>>();

            //kernel.Bind<IService<BllUser>>().To<UserService>().InRequestScope();
            //kernel.Bind<IService<BllRoleEntity>>().To<RoleService>().InRequestScope();
            kernel.Bind<IArticleService>().To<ArticleService>().InRequestScope();
            kernel.Bind<IBlogService>().To<BlogService>().InRequestScope();
            kernel.Bind<IRoleService>().To<RoleService>().InRequestScope();
            kernel.Bind<IUserService>().To<UserService>().InRequestScope();
        }
    }
}
