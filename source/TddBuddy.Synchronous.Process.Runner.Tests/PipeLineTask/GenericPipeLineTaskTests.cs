using System;
using NUnit.Framework;

namespace TddBuddy.Synchronous.Process.Runner.Tests.PipeLineTask
{
    [TestFixture]
    public class GenericPipeLineTaskTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Ctor_WhenEmptyStringApplicationPath_ShouldThrowException(string applicationPath)
        {
            //---------------Set up test pack-------------------
            var expected = "applicationPath";
            //---------------Execute Test ----------------------
            var result = Assert.Throws<ArgumentException>(()=>new TestGenericPipeLineTask(applicationPath, "args"));
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result.Message);
        }
    }
}
