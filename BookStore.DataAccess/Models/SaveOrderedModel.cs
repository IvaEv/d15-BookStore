using System;
using System.Collections.Generic;
using System.Linq;
using IkitMita;

namespace BookStore.DataAccess.Models
{
    public class SaveOrderedModel
    {
        public int EmployeeId { get; set; }
        public int BranchId { get; set; }
        public int ClientId { get; set; }

        public decimal TotalCost
        {
            get
            {
                if (OrderedBooks.IsNullOrEmpty())
                {
                    return 0;
                }

                var total = OrderedBooks.Sum(ob => ob.Amount*ob.Price);
                return total;
            }
        }

        public DateTime OrderDate { get; set; }
        public ICollection<SaveOrderedBookModel> OrderedBooks { get; set; }
    }
}
