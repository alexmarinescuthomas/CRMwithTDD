using Customers.API.Models;

namespace Customers.UnitTests.Fixtures
{
    public static class UsersFixture 
    {
        // Get some test users
        public static List<User> GetTestUsers() =>
            new()
            {
                new User
                {
                    Name = "Test User 1",
                    EMail = "testuser1@gmail.com",
                    Address = new Address
                    {
                        Street = "500 Yonge St.",
                        City = "Toronto",
                        Country = "Canada",
                        ZIP = "123ABC"
                    },
                    Comment = "new customer 1"
                },
                new User
                {
                    Name = "Test User 2",
                    EMail = "testuser2@gmail.com",
                    Address = new Address
                    {
                        Street = "55 Yonge St.",
                        City = "Montreal",
                        Country = "Canada",
                        ZIP = "ZXC789"
                    },
                    Comment = "new customer 2"
                },
                new User
                {
                    Name = "Test User 3",
                    EMail = "testuser3@gmail.com",
                    Address = new Address
                    {
                        Street = "100 Main St.",
                        City = "Vancouver",
                        Country = "Canada",
                        ZIP = "JKL456"
                    },
                    Comment = "new customer 3"
                },
                new User
                {
                    Name = "Test User 4",
                    EMail = "testuser4@gmail.com",
                    Address = new Address
                    {
                        Street = "350 1st St.",
                        City = "New York",
                        Country = "USA",
                        ZIP = "89348"
                    },
                    Comment = "new customer 4"
                },
                new User
                {
                    Name = "Test User 5",
                    EMail = "testuser5@gmail.com",
                    Address = new Address
                    {
                        Street = "854 13th St.",
                        City = "New York",
                        Country = "USA",
                        ZIP = "894845"
                    },
                    Comment = "new customer 5"
                }
            };
    }
}
