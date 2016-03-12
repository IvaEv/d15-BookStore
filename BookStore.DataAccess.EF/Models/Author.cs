using System;
using IkitMita.DataAccess;

namespace BookStore.DataAccess.EF.Models
{
    public class Author : FullNamedDomainObject
    {
        public DateTime? Birthday { get; set; }
    }
}
