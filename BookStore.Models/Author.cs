using System;
using IkitMita.DataAccess;

namespace BookStore.Models
{
    public class Author : FullNamedDomainObject
    {
        public DateTime? Birthday { get; set; }
    }
}
