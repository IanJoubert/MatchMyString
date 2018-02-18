using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mms.Framework.Validators.Exceptions;

namespace Mms.Framework.Validators.Tests
{
    [TestClass]
    public class AlphanumericValidatorTests
    {
        private AlphanumericValidator _alphanumericValidator;

        [TestInitialize]
        public void TestInitialize()
        {
            _alphanumericValidator = new AlphanumericValidator();
        }

        [TestMethod]
        public void TestValidatePositive()
        {
            StringValidator.TestValidatePositive(_alphanumericValidator, "ABCD");
        }

        [TestMethod]
        public void TestValidateNegative()
        {
            Assert.ThrowsException<AlphanumericException>(() => StringValidator.TestValidateNegative(_alphanumericValidator, "A!C)D"));
        }
    }
}
