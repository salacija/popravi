using FluentAssertions;
using Popravi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Popravi.Tests.Integration.Database
{
    public class EntityFrameworkConnectionTests
    {
        [Fact]
        public void CanConnectToTheDatabase()
        {
            var context = new PopraviDbContext();
            context.Database.CanConnect()
                .Should().BeTrue();
        }
    }
}
