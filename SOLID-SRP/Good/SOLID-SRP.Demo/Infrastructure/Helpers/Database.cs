using System;
using System.Collections.Generic;
using SOLID_SRP.Demo.Enumerations;
using SOLID_SRP.Demo.Infrastructure.Models;

namespace SOLID_SRP.Demo.Infrastructure.Helpers
{
    public class Database
    {
        public static List<Order> GenerateOrders()
        {
            var customer = GenerateUsers();
            return new List<Order>
            {
                new Order {Id = 100, Status = Status.Draft, CreatedAt = new DateTime(2019, 01,07), Number = "NUM-002", Customer = customer[0]},
                new Order {Id = 101, Status = Status.Draft, CreatedAt = new DateTime(2019, 01,07), Number = "NUM-011", Customer = customer[1]},
                new Order {Id = 102, Status = Status.Draft, CreatedAt = new DateTime(2019, 01,07), Number = "NUM-202", Customer = customer[2]},
                new Order {Id = 103, Status = Status.Draft, CreatedAt = new DateTime(2019, 01,07), Number = "NUM-402", Customer = customer[3]},
                new Order {Id = 104, Status = Status.Draft, CreatedAt = new DateTime(2019, 01,07), Number = "NUM-252", Customer = customer[0]},
                new Order {Id = 105, Status = Status.Draft, CreatedAt = new DateTime(2019, 01,07), Number = "NUM-082", Customer = customer[1]},
                new Order {Id = 106, Status = Status.Draft, CreatedAt = new DateTime(2019, 01,07), Number = "NUM-682", Customer = customer[2]}
            };
        }

        public static List<User> GenerateUsers()
        {
            return new List<User>
            {
                new User {Id = 1002, UserName = "User1", Email = "email@ymail.ru", IsAdmin = false},
                new User {Id = 1003, UserName = "User2", Email = "email@ymail.ru", IsAdmin = false},
                new User {Id = 1004, UserName = "User3", Email = "email@ymail.ru", IsAdmin = false},
                new User {Id = 1005, UserName = "User4", Email = "email@ymail.ru", IsAdmin = false},
                new User {Id = 1000, UserName = "Administrator1", Email = "email@ymail.ru", IsAdmin = true},
                new User {Id = 1001, UserName = "Administrator2", Email = "email@ymail.ru", IsAdmin = true}
            };
        }
    }
}
