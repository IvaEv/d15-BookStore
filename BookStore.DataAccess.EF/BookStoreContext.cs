using System.Data.Entity;
using BookStore.DataAccess.EF.Models;

namespace BookStore.DataAccess.EF
{
    public class BookStoreDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAmount> BookAmounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedBook> OrderedBooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasRequired(u => u.Employee)
                .WithOptional(e => e.User);

            base.OnModelCreating(modelBuilder);
        }
    }
}
