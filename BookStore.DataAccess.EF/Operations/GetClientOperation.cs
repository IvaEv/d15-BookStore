using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BookStore.DataAccess.EF.Models;
using BookStore.DataAccess.Models;
using IkitMita;

namespace BookStore.DataAccess.EF.Operations
{
    [Export(typeof(IGetClientOperation))]
    public class GetClientOperation: IGetClientOperation
    {
        public async Task<ICollection<GetClientModel>> ExecuteAsync(string clientLastName = null)
        {
            using (var db = new BookStoreDbContext())
            {
                IQueryable<Client> query = db.Clients;
                if (!clientLastName.IsNullOrWhiteSpace())
                {
                    query = query.Where(c => c.LastName.StartsWith(clientLastName));
                }

                var clients = await query.Select(c => new GetClientModel
                {
                    LastName = c.LastName,
                    Id = c.Id,
                    MiddleName = c.MiddleName,
                    FirstName = c.FirstName
                }).ToListAsync();

                return clients;
            }
        }
    }
}
