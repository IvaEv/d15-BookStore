using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.DataAccess
{
    public interface IGetUserOperation
    {
        Task<User> ExecuteAsync(string login, string password);
    }
}
