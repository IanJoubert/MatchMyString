using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mms.Framework.Validators.Exceptions;

namespace Mms.Framework.Validators.Tests
{
    [TestClass]
    public class NonRepeatablesValidatorTests
    {
        private NonRepeatablesValidator _nonRepeatablesValidator;

        [TestInitialize]
        public void TestInitialize()
        {
            _nonRepeatablesValidator = new NonRepeatablesValidator();
        }

        [TestMethod]
        public void TestValidate()
        {
            StringValidator.TestValidatePositive(_nonRepeatablesValidator, "ABCD");
        }

        [TestMethod]
        public void TestValidateNegative()
        {
            Assert.ThrowsException<RepeatingCharactersException>(() => StringValidator.TestValidateNegative(_nonRepeatablesValidator, "ABAD"));
        }
    }
}
