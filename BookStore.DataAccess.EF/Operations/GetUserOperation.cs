using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BookStore.DataAccess.EF.Models;
using BookStore.DataAccess.Models;

namespace BookStore.DataAccess.EF.Operations
{
    [Export(typeof(IGetUserOperation))]
    public class GetUserOperation : IGetUserOperation
    {
        public async Task<GetUserModel> ExecuteAsync(string login)
        {
            using (var db = new BookStoreDbContext())
            {
                User user = await db.Users
                    .Where(u => u.Login == login)
                    .FirstOrDefaultAsync();

                return Convert(user);
            }
        }

        private GetUserModel Convert(User user)
        {
            return user == null
                ? null 
                : new GetUserModel
                    {
                        Id = user.Id,
                        Login = user.Login,
                        Password = user.Password
                    };
        }
    }
}
