using IkitMita.DataAccess;

namespace BookStore.Models
{
    public class Branch : TitledDomainObject
    {
        public string Address { get; set; }
    }
}