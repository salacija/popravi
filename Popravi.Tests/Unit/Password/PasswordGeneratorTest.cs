using FluentAssertions;
using Popravi.Mvc.Helpers;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace Popravi.Tests.Unit.Password
{
    public class PasswordGeneratorTest
    {
        [Theory]
        [InlineData("sifra1", "d0aeeef9a9aeddbaa999b7b65101b3a1")]
        [InlineData("milica", "932e512d0da2821efe2b81539f0b82c5")]
        [InlineData("teamlukic", "cf38f8a134798b739f23ab21dd0d7c39")]
        public void PasswordGeneratorMakesAppropriateHash(string password, string hashPassword)
        {
            var result = PasswordGenerator.Make(password);
            Assert.Equal(hashPassword, result);
        }

    }
}
