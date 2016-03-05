using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.DataAccess
{
    public interface IGetEmployeeOperation
    {
        Task<Employee> ExecuteAsync(int id);
    }
}
