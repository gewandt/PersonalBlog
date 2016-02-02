using System;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace WebUI.Infrastructure.Provider
{
    public class BlogRoleProvider : RoleProvider
    {
        public IRoleService RoleService
        {
            get
            {
                return System.Web.Mvc.DependencyResolver.Current.GetService<IRoleService>();
            }
            set { }
        }
        public IUserService UserService
        {
            get
            {
                return System.Web.Mvc.DependencyResolver.Current.GetService<IUserService>();
            }
            set { }
        }

        public override void CreateRole(string roleName)
        {
            if (roleName != null)
                RoleService.Create(roleName);
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            //return RoleService.Remove(roleName);
            return false;
        }

        public override string[] GetRolesForUser(string username)
        {
            return new string[] { UserService.GetRole(username) };
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            BllUserEntity user = UserService.Contains(username);
            if (user != null && user.BllRole.Name == roleName)
                return true;
            return false;
        }

        public override string[] GetAllRoles()
        {
            //return RoleService.GetAll().Select(x => x.Name).ToArray();
            return null;
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
    }
}