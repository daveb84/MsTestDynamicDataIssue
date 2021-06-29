using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MsTest225_NotWorking
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test cases - 3 are defined, and should result in pass, fail, pass.
        /// Does not work correctly - only last test case is run.
        /// </summary>
        public static IEnumerable<object[]> TestCases
        {
            get
            {
                var obj1 = new TestClass { MyProp = "should pass" };
                var obj2 = new TestClass { MyProp = "should pass" };
                yield return new object[] { obj1, obj2 }; // <- this is not run

                obj1.MyProp = "should fail now";
                obj2.MyProp = "should fail now x";
                yield return new object[] { obj1, obj2 };  // <- this is not run

                obj1.MyProp = "should pass again";
                obj2.MyProp = "should pass again";
                yield return new object[] { obj1, obj2 };  // <- only this is run
            }
        }

        [TestMethod]
        [DynamicData(nameof(TestCases))]
        public void ShouldPassFailPass(TestClass obj1, TestClass obj2)
        {
            Assert.AreEqual(obj1.MyProp, obj2.MyProp);
        }

        public class TestClass
        {
            public string MyProp { get; set; }
        }
    }
}
