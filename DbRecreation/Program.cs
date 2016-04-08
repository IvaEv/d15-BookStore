using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using BookStore.BusinessLogic;
using BookStore.DataAccess.EF;
using BookStore.DataAccess.EF.Models;
using Newtonsoft.Json;
using Configuration = BookStore.DataAccess.EF.Migrations.Configuration;

namespace DbRecreation
{
    class Program
    {
        static void Main(string[] args)
        {
            var contextName = typeof(BookStoreDbContext).Name;

            if (Database.Exists(contextName))
            {
                var connectionString = ConfigurationManager.ConnectionStrings[contextName].ConnectionString;
                using (var connection = new SqlConnection(connectionString))
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = $"ALTER DATABASE [{connection.Database}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                    command.ExecuteNonQuery();
                }

                Database.Delete(contextName);
            }
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookStoreDbContext, Configuration>());

            using (var db = new BookStoreDbContext())
            {
                CreateBranches(db);
                CreateEmployees(db);
                CreateItems<Client>(db, "JsonData/Сlients.json");

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

        private static List<T> CreateItems<T>(BookStoreDbContext db, string filePath) where T : class
        {
            var jsonData = File.ReadAllText(filePath);
            var items = JsonConvert.DeserializeObject<List<T>>(jsonData);
            db.Set<T>().AddRange(items);
            return items;
        }
    }
}
