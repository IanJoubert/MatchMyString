using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mms.Framework.Validators;
using Mms.Framework.Validators.Exceptions;

namespace Mms.Business.Services.Tests
{
    [TestClass]
    public class ValidationServiceTests
    {
        private IFileValidationService _fileValidationService;

        [TestInitialize]
        public void TestInitialize()
        {
            _fileValidationService = new FileValidationService(new AlphanumericValidator(), new NonRepeatablesValidator());
        }

        [TestMethod]
        public void TestVerifyPositive()
        {
            // arrange
            const string file = "ABCD,EFGH";

            // act
            var result = _fileValidationService.Verify(file);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestVerifyNegativeLength()
        {
            // arrange
            const string file = "ABCD,EFTGH";

            // act + assert
            Assert.ThrowsException<ExactLengthException>(() => _fileValidationService.Verify(file));
        }

        [TestMethod]
        public void TestVerifyNegativeRepeat()
        {
            // arrange
            const string file = "ABCD,EFGH,ABBC";

            // act + assert
            Assert.ThrowsException<RepeatingCharactersException>(() => _fileValidationService.Verify(file));
        }

        [TestMethod]
        public void TestVerifyNegativeAlphaNum()
        {
            // arrange
            const string file = "ABCD,E(GH,ADBC";

            // act + assert
            Assert.ThrowsException<AlphanumericException>(() => _fileValidationService.Verify(file));
        }
    }
}
