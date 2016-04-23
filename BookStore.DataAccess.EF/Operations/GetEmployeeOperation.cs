using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BookStore.DataAccess.Models;

namespace BookStore.DataAccess.EF.Operations
{
    [Export(typeof(IGetEmployeeOperation))]
    public class GetEmployeeOperation : IGetEmployeeOperation
    {
        public async Task<GetEmployeeModel> ExecuteAsync(int id)
        {
            using (var db = new BookStoreDbContext())
            {
                var employee = await db.Employees
                    .Select(e => new GetEmployeeModel
                    {
                        Id = e.Id,
                        Birthday = e.Birthday,
                        BranchId = e.BranchId,
                        BranchTitle = e.Branch.Title,
                        FireDate = e.FireDate,
                        FirstName = e.FirstName,
                        HireDate = e.HireDate,
                        LastName = e.LastName,
                        MiddleName = e.MiddleName
                    })
                    .FirstOrDefaultAsync(u => u.Id == id);

                return employee;
            }
        }
    }
}
