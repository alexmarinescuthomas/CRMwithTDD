using System.Net;

namespace Customers.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public Address Address { get; set; }
        public string Comment { get; set; }
    }
}
