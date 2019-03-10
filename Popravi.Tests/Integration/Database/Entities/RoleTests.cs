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
    public class RoleTests : IDisposable
    {
        private PopraviDbContext _context = new PopraviDbContext();
        public RoleTests()
        {
            var role = new Role
            {
                Name = "Test Role"
            };

            _context.Roles.Add(role);

            _context.SaveChanges();
        }
        [Fact]
        public void TestRoleIsWrittenToDatabase()
        {
            var role = _context.Roles.Where(r => r.Name == "Test Role").FirstOrDefault();
            role.Should().NotBeNull();
        }

        public void Dispose()
        {
            var role = _context.Roles.Where(r => r.Name == "Test Role").FirstOrDefault();
            _context.Roles.Remove(role);
            _context.SaveChanges();
        }
    }
}
