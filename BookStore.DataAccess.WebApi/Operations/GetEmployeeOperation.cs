using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Threading.Tasks;
using BookStore.DataAccess.Models;

namespace BookStore.DataAccess.WebApi.Operations
{
    [Export(typeof(IGetEmployeeOperation))]
    class GetEmployeeOperation : WebApiClient, IGetEmployeeOperation
    {
        public async Task<GetEmployeeModel> ExecuteAsync(int id)
        {
            try
            {
                return await GetAsync<GetEmployeeModel>($"employees/{id}");
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc);
                return null;
            }
        }
    }
}
