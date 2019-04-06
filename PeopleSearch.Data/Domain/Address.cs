using Microsoft.EntityFrameworkCore;

namespace PeopleSearch.Data.Domain
{
    [Owned]
    public sealed class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}