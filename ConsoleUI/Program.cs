using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using BLL.Services;
using DAL.Concrete;
using DAL.Interface.Entities;
using DAL.Interface.Interfaces;
using DAL.Interface.Repository;
using DAL.Repository;
using DependencyResolver.Settings;
using Ninject;
using ORM;

namespace ConsoleUI
{
    class Program
    {
        public static IKernel kernel = new StandardKernel();
        static void Main(string[] args)
        {
            kernel.Configure();

            var rs = kernel.Get<IRoleService>();
            rs.Create("user4");
            var role = rs.GetById(1);
            Console.WriteLine(role.Name);
            using (BlogDBEntities db = new BlogDBEntities())
            {
                var roles = db.Roles;
                foreach (var c in roles)
                {
                    Console.WriteLine(c.Name);
                }
                //db.Roles.Add(new Role {Name = "user"});
                //db.SaveChanges();
            }
        }
    }
}
