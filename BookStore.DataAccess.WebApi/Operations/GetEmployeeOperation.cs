using System;
using System.ComponentModel.Composition;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BookStore.DataAccess.Models;

namespace BookStore.DataAccess.WebApi.Operations
{
    [Export(typeof(IGetEmployeeOperation))]
    class GetEmployeeOperation : IGetEmployeeOperation
    {
        public async Task<GetEmployeeModel> ExecuteAsync(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49500/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var responseMessage = await client.GetAsync($"employees/{id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var employeeModel = await responseMessage.Content
                        .ReadAsAsync<GetEmployeeModel>();

                    return employeeModel;
                }

                return null;
            }
        }
    }
}
