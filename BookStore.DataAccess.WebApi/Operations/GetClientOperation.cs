using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using BookStore.DataAccess.Models;

namespace BookStore.DataAccess.WebApi.Operations
{
    [Export(typeof(IGetClientOperation))]
    class GetClientOperation : IGetClientOperation
    {
        public Task<ICollection<GetClientModel>> ExecuteAsync(string clientLastName = null)
        {
            throw new NotImplementedException();
        }
    }
}
