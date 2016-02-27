using System;
using IkitMita.DataAccess;

namespace BookStore.Models
{
    public class Client : FullNamedDomainObject
    {
        public DateTime RegistrationDate { get; set; }
    }
}
