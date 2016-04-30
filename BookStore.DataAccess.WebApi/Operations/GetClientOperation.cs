using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Threading.Tasks;
using BookStore.DataAccess.Models;

namespace BookStore.DataAccess.WebApi.Operations
{
    [Export(typeof(IGetClientOperation))]
    class GetClientOperation : WebApiClient, IGetClientOperation
    {
        public async Task<ICollection<GetClientModel>> ExecuteAsync(string clientLastName = null)
        {
            try
            {
                return await GetAsync<List<GetClientModel>>($"clients?clientLastName={clientLastName}");
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc);
                return null;
            }
        }
    }
}
