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

        [Test]
        public void Verify_WhenPasswordIsNull_Throws()
        {
            var passwordVerifier = new PasswordVerifier();
            string password = null;

            Action<string> verify = passwordVerifier.Verify;

            var exception = Assert.Throws<Exception>(() => verify(password));
            Assert.AreEqual(PasswordVerifier.PasswordIsNullErrorMsg, exception.Message);
        }
    }

    public class PasswordVerifier
    {
        public const string PasswordTooShortErrorMsg = "Password too short!";
        public const string PasswordIsNullErrorMsg = "Password is null!";
        public void Verify(string password)
        {
            if(password == null)
            {
                throw new Exception(PasswordIsNullErrorMsg);
            }
            if(password.Length <= 8)
            {
                throw new Exception(PasswordTooShortErrorMsg);
            }
        }
    }
}
