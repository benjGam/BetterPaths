using BetterPaths;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BetterPathTesting
{
    [TestClass]
    public class ExtensionsTests
    {
        [TestMethod]
        public void IsValidPath_Test()
        {
            Dictionary<string, bool> pathWithExpectedResult = new Dictionary<string, bool>()
            {
                { @"C:\", true },
                { @"c:\", true },
                { "c", false},
                { "c:", false },
                { @"c\", false },
                { "c:e", false },
                { $@"C:\>", false },

            }; 

            foreach (KeyValuePair<string, bool> entry in pathWithExpectedResult)
            {
                bool callReturn = BetterPath.IsWellFormedPath(entry.Key);

                Assert.AreEqual(entry.Value, callReturn, $"Failed for {entry.Key} value. Expected {entry.Value}, instead got {callReturn}");
            }
        }
    }
}
