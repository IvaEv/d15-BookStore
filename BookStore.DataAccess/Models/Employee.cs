using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IkitMita.DataAccess;

namespace BookStore.DataAccess.Models
{
    public class GetEmployeeModel : FullNamedDomainObject
    {
        public DateTime Birthday { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime? FireDate { get; set; }

        public int BranchId { get; set; }

        public string BranchTitle { get; set; }
    }
}
