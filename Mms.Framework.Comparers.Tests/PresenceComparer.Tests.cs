using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mms.Framework.Comparers.Tests
{
    [TestClass]
    public class PresenceComparerTests
    {
        private PresenceComparer _presenceComparer;


        [TestInitialize]
        public void TestInitialize()
        {
            _presenceComparer = new PresenceComparer();
        }

        [TestMethod]
        public void TestComparePositive()
        {
            // arrange
            const string str1 = "ABCC";
            const string str2 = "CBAA";

            // act
            var result = _presenceComparer.Compare(str1, str2);

            // assert
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void TestCompareNegative()
        {
            // arrange
            const string str1 = "ABCD";
            const string str2 = "CEDA";

            // act
            var result = _presenceComparer.Compare(str1, str2);

            // assert
            Assert.IsFalse(result);
        }
    }
}
