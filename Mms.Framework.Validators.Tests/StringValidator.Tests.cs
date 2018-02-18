using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mms.Framework.Validators.Tests
{
    public static class StringValidator
    {
        public static void TestValidatePositive(IStringValidator stringValidator, string testString)
        {
            // act
            var result = stringValidator.Validate(testString);

            // assert
            Assert.IsTrue(result);
        }

        public static void TestValidateNegative(IStringValidator stringValidator, string testString)
        {
            // act
            var result = stringValidator.Validate(testString);

            // assert
            Assert.IsFalse(result);
        }
    }
}
