using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mms.Framework.Validators.Exceptions;

namespace Mms.Framework.Validators.Tests
{
    [TestClass]
    public class ExactLengthValidatorTest
    {
        [TestMethod]
        public void TestContructor()
        {
            // arrange
            const int expected = 5;

            // act
            var lengthValidator = new ExactLengthValidator(expected);

            // assert
            Assert.AreEqual(lengthValidator.Length, expected);
        }

        [TestMethod]
        public void TestValidatePositive()
        {
            // arrange
            const string testString = "MyString";
            var lengthValidator = new ExactLengthValidator(testString.Length);

            StringValidator.TestValidatePositive(lengthValidator, testString);
        }

        [TestMethod]
        public void TestValidateNegative()
        {
            // arrange
            const string testString = "MyString";
            var lengthValidator = new ExactLengthValidator(testString.Length + 1);

            Assert.ThrowsException<ExactLengthException>(() => StringValidator.TestValidateNegative(lengthValidator, testString));
        }
    }
}
