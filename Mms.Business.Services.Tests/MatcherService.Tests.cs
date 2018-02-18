using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mms.Framework.Comparers;

namespace Mms.Business.Services.Tests
{
    [TestClass]
    public class MatcherServiceTests
    {

        private IMatcherService _matcherService;

        [TestInitialize]
        public void TestInitialize()
        {
            _matcherService = new StringMatcherService(new PresenceComparer());
        }

        [TestMethod]
        public void TestGetMatchesPositive()
        {
            // arrange
            const string file = "ABCD,EFGH";
            const string search = "EFGH";

            // act
            var result = _matcherService.GetMatches(search, file);

            // assert
            Assert.AreEqual(result, search);
        }

        [TestMethod]
        public void TestGetMatchesFindMultiples()
        {
            // arrange
            const string file = "EFGH,EFGH";
            const string search = "EFGH";

            // act
            var result = _matcherService.GetMatches(search, file);

            // assert
            Assert.AreEqual(result, file);
        }

        [TestMethod]
        public void TestGetMatchesNegative()
        {
            // arrange
            const string file = "ABCD,EFGH";
            const string search = "DFGB";

            // act
            var result = _matcherService.GetMatches(search, file);

            // assert
            Assert.AreEqual(result, "");
        }
    }
}
