using System;
using System.Threading.Tasks;
using System.Web.Http;
using BookStore.DataAccess.EF.Operations;
using BookStore.DataAccess.Models;

namespace BookStore.WebService.Controllers
{
    public class EmployeesController : ApiController
    {
        public async Task<GetEmployeeModel> GetAsync(int id)
        {
            var operation = new GetEmployeeOperation();
            var employeeModel = await operation.ExecuteAsync(id);
            return employeeModel;
        }
    }
}