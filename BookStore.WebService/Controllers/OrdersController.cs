using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Web.Http;
using BookStore.DataAccess;
using BookStore.DataAccess.Models;

namespace BookStore.WebService.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class OrdersController : ApiController
    {
        [Import]
        private ISaveOrderOperation SaveOrderOperation { get; set; }

        public async Task<bool> PostOrderAsync(SaveOrderModel model)
        {
            return await SaveOrderOperation.ExecuteAsync(model);
        }

    }
}