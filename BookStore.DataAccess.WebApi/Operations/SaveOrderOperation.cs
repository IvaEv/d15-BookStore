using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using BookStore.DataAccess.Models;

namespace BookStore.DataAccess.WebApi.Operations
{
    [Export(typeof(ISaveOrderOperation))]
    class SaveOrderOperation : ISaveOrderOperation
    {
        public Task<bool> ExecuteAsync(SaveOrderModel model)
        {
            throw new NotImplementedException();
        }
    }
}
