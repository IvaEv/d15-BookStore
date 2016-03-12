using System;
using IkitMita.DataAccess;

namespace BookStore.DataAccess.EF.Models
{
    public class Employee : FullNamedDomainObject
    {
        public DateTime Birthday { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime? FireDate { get; set; }

        public int BranchId { get; set; }

        public Branch Branch { get; set; }

        public User User { get; set; }
    }
}
