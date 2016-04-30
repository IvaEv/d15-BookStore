using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using BookStore.DataAccess.Models;

namespace BookStore.DataAccess.WebApi.Operations
{
    [Export(typeof(ISearchBooksOperation))]
    class SearchBooksOperation : ISearchBooksOperation
    {
        public Task<ICollection<SearchBookModel>> ExecuteAsync(string searchString, int branchId)
        {
            throw new NotImplementedException();
        }
    }
}
