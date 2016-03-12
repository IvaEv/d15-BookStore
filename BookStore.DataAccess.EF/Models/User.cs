using IkitMita.DataAccess;

namespace BookStore.DataAccess.EF.Models
{
    public class User : DomainObject
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        public Employee Employee { get; set; }
    }
}
