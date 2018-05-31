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

            var exception = Assert.Throws<Exception>(() => verify(password));
            Assert.AreEqual(PasswordVerifier.PasswordTooShortErrorMsg, exception.Message);
        }   
    }

    public class PasswordVerifier
    {
        public const string PasswordTooShortErrorMsg = "Password too short!";
        public void Verify(string password)
        {
            if(password.Length <= 8)
            {
                throw new Exception(PasswordTooShortErrorMsg);
            }
        }
    }
}
