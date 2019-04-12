using FluentAssertions;
using Popravi.DataAccess;
using Popravi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Popravi.Tests.Integration.Database.Entities
{
    public class UserTests : IDisposable
    {
        private PopraviDbContext _context = new PopraviDbContext();

        [Fact]
        public void AddUserToDatabase()
        {
            var user = new User
            {
                FirstName = "Pera",
                LastName = "Peric",
                Username = "pera",
                Password = "sifra",
                Email = "pera.peric@gmail.com",
                RoleId = 4
            };
            _context.Users.Add(user);
            _context.SaveChanges();

            var promenljiva = _context.Users.Where(u => u.Username == "pera").FirstOrDefault();
            promenljiva.Should().NotBeNull();
        }

        public void Dispose()
        {
            var user = _context.Users.Where(u => u.Username == "pera").FirstOrDefault();
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}    

