using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BookStore.DataAccess.EF.Models;
using BookStore.DataAccess.Models;

namespace BookStore.DataAccess.EF.Operations
{
    [Export(typeof(ISaveOrderOperation))]
    class SaveOrderOperation : ISaveOrderOperation
    {
        public async Task<bool> ExecuteAsync(SaveOrderModel model)
        {
            using (var db = new BookStoreDbContext())
            {
                var order = new Order
                {
                    ClientId = model.ClientId,
                    EmployeeId = model.EmployeeId,
                    OrdeDate = model.OrderDate,
                    TotalConst = model.TotalCost
                };
                db.Orders.Add(order);

                foreach (SaveOrderedBookModel bookModel in model.OrderedBooks)
                {
                    db.OrderedBooks.Add(new OrderedBook
                    {
                        Amount = bookModel.Amount,
                        BookId = bookModel.BookId,
                        Order = order,
                        Price = bookModel.Price
                    });
                }

                var bookIds = model.OrderedBooks.Select(ob => ob.BookId).ToArray();
                var bookAmounts = await db.BookAmounts
                    .Where(ba => ba.BranchId == model.BranchId)
                    .Where(ba => bookIds.Contains(ba.BookId))
                    .ToListAsync();

                foreach (BookAmount bookAmount in bookAmounts)
                {
                    var orderAmount = model.OrderedBooks
                        .First(ob => ob.BookId == bookAmount.BookId)
                        .Amount;
                    bookAmount.Amount -= orderAmount;
                }

                await db.SaveChangesAsync();
                return true;
            }
        }
    }
}
