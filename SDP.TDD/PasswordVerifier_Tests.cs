using NUnit.Framework;
using System;

namespace SDP.TDD
{
    [TestFixture]
    public class PasswordVerifier_Tests
    {
        [Test]
        public void Verify_WhenPasswordNotLargerThan8_Throws()
        {
            var passwordVerifier = new PasswordVerifier();
            var password = "12345678";

            Action<string> verify = passwordVerifier.Verify;

            Assert.Throws<Exception>(() => verify(password));
        }   
    }

    public class PasswordVerifier
    {
        public void Verify(string password)
        {

        }
    }
}
