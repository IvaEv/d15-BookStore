using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.DataAccess.EF.Operations
{
    [Export(typeof(IGetUserOperation))]
    public class GetUserOperation : IGetUserOperation
    {
        public async Task<User> ExecuteAsync(string login, string password)
        {
            using (var db = new BookStoreDbContext())
            {
                User user = await db.Users
                    .Where(u => u.Login == login)
                    .Where(u => u.Password == password)
                    .FirstOrDefaultAsync();

                return user;
            }
        }
    }
}
