using BetterPaths;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BetterPathTesting
{
    [TestClass]
    public class ExtensionsTests
    {
        [TestMethod]
        public void IsValidPath_Test()
        {
            Assert.AreEqual(false, BetterPath.IsWellFormedPath("r"), "");
        }
    }
}
