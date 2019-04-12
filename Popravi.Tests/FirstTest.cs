using System;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace Popravi.Tests
{
    public class FirstTest
    {
        [Fact]
        public void FirstTestPassed()
        {

        }

        [Fact]
        public void HashTest()
        {
            var md5 = MD5.Create();
            var result = md5.ComputeHash(Encoding.UTF8.GetBytes("sifra1"));
            var sifra = BitConverter.ToString(result).Replace("-", "").ToLower();
        }
    }
}
