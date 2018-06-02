using NUnit.Framework;
using System;
using System.Linq;

namespace SDP.TDD
{
    [TestFixture]
    public class PasswordVerifier_Tests
    {
        [Test]
        [TestCase(null)]
        [TestCase("12345678")]
        public void Verify_WhenPasswordNotLargerThan8_Throws(string password)
        {
            var passwordVerifier = new PasswordVerifier();

            Action<string> verify = passwordVerifier.Verify;

            var exception = Assert.Throws<Exception>(() => verify(password));
            StringAssert.Contains(PasswordVerifier.PasswordTooShortErrorMsg, exception.Message);
        }

        [Test]
        public void Verify_WhenPasswordIsNull_Throws()
        {
            var passwordVerifier = new PasswordVerifier();
            string password = null;

            Action<string> verify = passwordVerifier.Verify;

            var exception = Assert.Throws<Exception>(() => verify(password));
            StringAssert.Contains(PasswordVerifier.PasswordIsNullErrorMsg, exception.Message);
        }

        [Test]
        [TestCase(null)]
        [TestCase("12345678")]
        public void Verify_WhenPasswordHasNoUppercase_Throws(string password)
        {
            var passwordVerifier = new PasswordVerifier();

            Action<string> verify = passwordVerifier.Verify;

            var exception = Assert.Throws<Exception>(() => verify(password));
            StringAssert.Contains(PasswordVerifier.PasswordHasNoUppercase, exception.Message);
        }
    }

    public class PasswordVerifier
    {
        public const string PasswordTooShortErrorMsg = "Password too short!";
        public const string PasswordIsNullErrorMsg = "Password is null!";
        public const string PasswordHasNoUppercase = "Password has no uppercase letter!";
        public void Verify(string password)
        {
            var errorMessage = string.Empty;
            if(password == null)
            {
                errorMessage += PasswordIsNullErrorMsg;
            }
            if(password == null || password.Length <= 8)
            {
                errorMessage += PasswordTooShortErrorMsg;
            }
            if (password == null || !password.Any(char.IsUpper))
            {
                errorMessage += PasswordHasNoUppercase;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new Exception(errorMessage);
            }
        }
    }
}
