using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.DataAccess.EF.Operations
{
    [Export(typeof(IGetEmployeeOperation))]
    class GetEmployeeOperation : IGetEmployeeOperation
    {
        public async Task<Employee> ExecuteAsync(int id)
        {
            using (var db = new BookStoreDbContext())
            {
                var employee = await db.Employees
                    .Include(u => u.Branch)
                    .FirstOrDefaultAsync(u => u.Id == id);

                return employee;
            }
        }
    }
}
