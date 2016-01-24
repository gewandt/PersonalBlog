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
        static void Main(string[] args)
        {
            //DbContext _db = new BlogDBEntities();
            IKernel kernel = new StandardKernel();
            ResolverSettings.Configure(kernel);
            //UnitOfWork uow = new UnitOfWork(_db, kernel);

            //IUserService us = new UserService(uow);
            IRoleService rs =  kernel.Get<IRoleService>();
            rs.Create("user3");
            var role = rs.GetById(1);
            Console.WriteLine(role.Name);
            //rs.Dispose();
            //_db.SaveChanges();
            //us.Create("testuser", "1234");

            //Console.WriteLine("{0} {1} {2} {3}", test.Id, test.Name, test.BllRole.Id, test.Password);
            //_db.SaveChanges();

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
