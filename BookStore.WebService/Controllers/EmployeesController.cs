using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Web.Http;
using BookStore.DataAccess;
using BookStore.DataAccess.Models;

namespace BookStore.WebService.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EmployeesController : ApiController
    {
        [Import]
        private IGetEmployeeOperation GetEmployeeOperation { get; set; }

        public async Task<GetEmployeeModel> GetAsync(int id)
        {
            var employeeModel = await GetEmployeeOperation.ExecuteAsync(id);
            return employeeModel;
        }
    }
}