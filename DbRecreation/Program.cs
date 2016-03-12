using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.BusinessLogic;
using BookStore.DataAccess.EF;
using BookStore.DataAccess.EF.Migrations;
using BookStore.DataAccess.EF.Models;
using Newtonsoft.Json;

namespace DbRecreation
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookStoreDbContext, Configuration>());

            using (var db = new BookStoreDbContext())
            {
                CreateBranches(db);
                CreateEmployees(db);

                db.SaveChanges();
            }
        }

        static void CreateBranches(BookStoreDbContext db)
        {
            db.Branches.Add(new Branch { Title = "Книжный на Мира", Address = "Мира 10" });
            db.Branches.Add(new Branch { Title = "Книжный на правом", Address = "КрасРаб 105" });
            db.Branches.Add(new Branch { Title = "Книжный на Взлетке", Address = "Взлека Плаза, Весны 10" });
        }

        static void CreateEmployees(BookStoreDbContext db)
        {
            var employeesJson = File.ReadAllText("jsondata/Employees.json");
            var employees = JsonConvert.DeserializeObject<List<Employee>>(employeesJson);

            foreach (Employee employee in employees)
            {
                employee.User.Password = PasswordManager.CreateHash(employee.User.Password);
                employee.Branch = GetRandomItem(db.Branches.Local);
                db.Employees.Add(employee);
            }
        }

        private static readonly Random _rand = new Random();
        private static T GetRandomItem<T>(ICollection<T> collection)
        {
            var index = _rand.Next(0, collection.Count);
            var item = collection.ElementAt(index);
            return item;
        }
    }
}
