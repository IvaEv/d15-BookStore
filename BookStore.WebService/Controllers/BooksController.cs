using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Web.Http;
using BookStore.DataAccess;
using BookStore.DataAccess.Models;

namespace BookStore.WebService.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BooksController : ApiController
    {
        [Import]
        private ISearchBooksOperation SearchBooksOperation { get; set; }

        public async Task<ICollection<SearchBookModel>> GetBooks(string searchString, int branchId)
        {
            return await SearchBooksOperation.ExecuteAsync(searchString, branchId);
        } 
    }
}