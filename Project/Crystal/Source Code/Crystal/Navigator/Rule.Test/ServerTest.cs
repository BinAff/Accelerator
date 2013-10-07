using Crystal.Navigator.Rule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BinAff.Core;

namespace Crystal.Navigator.Rule.Test
{
        
    /// <summary>
    ///This is a test class for ServerTest and is intended
    ///to contain all ServerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ServerTest
    {

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        #region Save

        ///<summary>
        ///01: No value passed
        ///</summary>
        [TestMethod(),
            TestCategory("Create"),
            Description("01: No value passed")]
        [DeploymentItem("Crystal.Navigator.Rule.dll")]
        public void SaveTest01()
        {
            Data data; ICrud crud; ReturnObject<Boolean> ret;
            data = new Data();
            crud = new Server(data);
            ret = crud.Save();
            Assert.AreEqual<Int32>(ret.MessageList.Count, 2);
            Assert.AreEqual(ret.MessageList[0].Description, "Module seperator cannot be null.");
            Assert.AreEqual(ret.MessageList[1].Description, "Path seperator cannot be null.");
        }

        ///<summary>
        ///02: No module seperator passed
        ///</summary>
        [TestMethod(), TestCategory("Create"),
            Description("02: No module seperator passed")]
        [DeploymentItem("Crystal.Navigator.Rule.dll")]
        public void SaveTest02()
        {
            Data data; ICrud crud; ReturnObject<Boolean> ret;
            data = new Data { PathSeperator = "/" };
            crud = new Server(data);
            ret = crud.Save();
            Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            Assert.AreEqual(ret.MessageList[0].Description, "Module seperator cannot be null.");
        }

        ///<summary>
        ///03: No path seperator passed
        ///</summary>
        [TestMethod(), TestCategory("Create"),
            Description("03: No path seperator passed")]
        [DeploymentItem("Crystal.Navigator.Rule.dll")]
        public void SaveTest03()
        {
            Data data; ICrud crud; ReturnObject<Boolean> ret;
            data = new Data { ModuleSeperator = "-" };
            crud = new Server(data);
            ret = crud.Save();
            Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            Assert.AreEqual(ret.MessageList[0].Description, "Path seperator cannot be null.");
        }

        ///<summary>
        ///04: No module seperator, wrong length path seperator passed - 1
        ///</summary>
        [TestMethod(), TestCategory("Create"),
            Description("04: No module seperator, wrong length path seperator passed - 1")]
        [DeploymentItem("Crystal.Navigator.Rule.dll")]
        public void SaveTest04()
        {
            Data data; ICrud crud; ReturnObject<Boolean> ret;
            data = new Data { PathSeperator = "-k" };
            crud = new Server(data);
            ret = crud.Save();
            Assert.AreEqual<Int32>(ret.MessageList.Count, 2);
            Assert.AreEqual(ret.MessageList[0].Description, "Module seperator cannot be null.");
            Assert.AreEqual(ret.MessageList[1].Description, "Only one Symbol is available for path seperator.");
        }

        ///<summary>
        ///05: No module seperator, wrong length path seperator passed - 2
        ///</summary>
        [TestMethod(), TestCategory("Create"),
            Description("05: No module seperator, wrong length path seperator passed - 2")]
        [DeploymentItem("Crystal.Navigator.Rule.dll")]
        public void SaveTest05()
        {
            Data data; ICrud crud; ReturnObject<Boolean> ret;
            data = new Data { PathSeperator = "1f" };
            crud = new Server(data);
            ret = crud.Save();
            Assert.AreEqual<Int32>(ret.MessageList.Count, 2);
            Assert.AreEqual(ret.MessageList[0].Description, "Module seperator cannot be null.");
            Assert.AreEqual(ret.MessageList[1].Description, "Only one Symbol is available for path seperator.");
        }

        ///<summary>
        ///06: Correct module seperator, wrong length path seperator passed - 1
        ///</summary>
        [TestMethod(), TestCategory("Create"),
            Description("06: Correct module seperator, wrong length path seperator passed - 1")]
        [DeploymentItem("Crystal.Navigator.Rule.dll")]
        public void SaveTest06()
        {
            Data data; ICrud crud; ReturnObject<Boolean> ret;
            data = new Data { ModuleSeperator = "-", PathSeperator = ":'" };
            crud = new Server(data);
            ret = crud.Save();
            Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            Assert.AreEqual(ret.MessageList[0].Description, "Only one Symbol is available for path seperator.");
        }

        ///<summary>
        ///07: Correct module seperator, wrong length path seperator passed - 2
        ///</summary>
        [TestMethod(), TestCategory("Create"),
            Description("07: Correct module seperator, wrong length path seperator passed - 2")]
        [DeploymentItem("Crystal.Navigator.Rule.dll")]
        public void SaveTest07()
        {
            Data data; ICrud crud; ReturnObject<Boolean> ret;
            data = new Data { ModuleSeperator = "-", PathSeperator = "k5" };
            crud = new Server(data);
            ret = crud.Save();
            Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            Assert.AreEqual(ret.MessageList[0].Description, "Only one Symbol is available for path seperator.");
        }

        ///<summary>
        ///08: Wrong length module seperator, no path seperator passed - 1
        ///</summary>
        [TestMethod(), TestCategory("Create"),
            Description("08: Wrong length module seperator, no path seperator passed - 1")]
        [DeploymentItem("Crystal.Navigator.Rule.dll")]
        public void SaveTest08()
        {
            Data data; ICrud crud; ReturnObject<Boolean> ret;
            data = new Data { ModuleSeperator = "-p" };
            crud = new Server(data);
            ret = crud.Save();
            Assert.AreEqual<Int32>(ret.MessageList.Count, 2);
            Assert.AreEqual(ret.MessageList[0].Description, "Only one Symbol is available for module seperator.");
            Assert.AreEqual(ret.MessageList[1].Description, "Path seperator cannot be null.");
        }

        ///<summary>
        ///09: Wrong length module seperator, no path seperator passed - 2
        ///</summary>
        [TestMethod(), TestCategory("Create"),
            Description("09: Wrong length module seperator, no path seperator passed - 2")]
        [DeploymentItem("Crystal.Navigator.Rule.dll")]
        public void SaveTest09()
        {
            Data data; ICrud crud; ReturnObject<Boolean> ret;
            data = new Data { ModuleSeperator = "p3" };
            crud = new Server(data);
            ret = crud.Save();
            Assert.AreEqual<Int32>(ret.MessageList.Count, 2);
            Assert.AreEqual(ret.MessageList[0].Description, "Only one Symbol is available for module seperator.");
            Assert.AreEqual(ret.MessageList[1].Description, "Path seperator cannot be null.");            
        }

        ///<summary>
        ///10: Wrong length module seperator, correct path seperator passed - 1
        ///</summary>
        [TestMethod(), TestCategory("Create"),
            Description("10: Wrong length module seperator, correct path seperator passed - 1")]
        [DeploymentItem("Crystal.Navigator.Rule.dll")]
        public void SaveTest10()
        {
            Data data; ICrud crud; ReturnObject<Boolean> ret;
            data = new Data { ModuleSeperator = ":y", PathSeperator = "/" };
            crud = new Server(data);
            ret = crud.Save();
            Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            Assert.AreEqual(ret.MessageList[0].Description, "Only one Symbol is available for module seperator.");
        }

        ///<summary>
        ///11: Wrong length module seperator, correct path seperator passed - 2
        ///</summary>
        [TestMethod(), TestCategory("Create"),
            Description("11: Wrong length module seperator, correct path seperator passed - 2")]
        [DeploymentItem("Crystal.Navigator.Rule.dll")]
        public void SaveTest11()
        {
            Data data; ICrud crud; ReturnObject<Boolean> ret;
            data = new Data { ModuleSeperator = "5t", PathSeperator = "/" };
            crud = new Server(data);
            ret = crud.Save();
            Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            Assert.AreEqual(ret.MessageList[0].Description, "Only one Symbol is available for module seperator.");
        }

        ///<summary>
        ///12: Wrong length module seperator, wrong length path seperator passed - 1
        ///</summary>
        [TestMethod(), TestCategory("Create"),
            Description("12: Wrong length module seperator, wrong length path seperator passed - 1")]
        [DeploymentItem("Crystal.Navigator.Rule.dll")]
        public void SaveTest12()
        {
            Data data; ICrud crud; ReturnObject<Boolean> ret;
            data = new Data { ModuleSeperator = ":y", PathSeperator = "-P" };
            crud = new Server(data);
            ret = crud.Save();
            Assert.AreEqual<Int32>(ret.MessageList.Count, 2);
            Assert.AreEqual(ret.MessageList[0].Description, "Only one Symbol is available for module seperator.");
            Assert.AreEqual(ret.MessageList[1].Description, "Only one Symbol is available for path seperator.");
        }

        ///<summary>
        ///13: Wrong length module seperator, wrong length path seperator passed - 2
        ///</summary>
        [TestMethod(), TestCategory("Create"),
            Description("13: Wrong length module seperator, wrong length path seperator passed - 2")]
        [DeploymentItem("Crystal.Navigator.Rule.dll")]
        public void SaveTest13()
        {
            Data data; ICrud crud; ReturnObject<Boolean> ret;
            data = new Data { ModuleSeperator = "3r", PathSeperator = "m6" };
            crud = new Server(data);
            ret = crud.Save();
            Assert.AreEqual<Int32>(ret.MessageList.Count, 2);
            Assert.AreEqual(ret.MessageList[0].Description, "Only one Symbol is available for module seperator.");
            Assert.AreEqual(ret.MessageList[1].Description, "Only one Symbol is available for path seperator.");
        }

        ///<summary>
        ///14: No module seperator, wrong character path seperator passed
        ///</summary>
        [TestMethod(), TestCategory("Create"),
            Description("14: No module seperator, wrong character path seperator passed")]
        [DeploymentItem("Crystal.Navigator.Rule.dll")]
        public void SaveTest14()
        {
            Data data; ICrud crud; ReturnObject<Boolean> ret;
            data = new Data { PathSeperator = "p" };
            crud = new Server(data);
            ret = crud.Save();
            Assert.AreEqual<Int32>(ret.MessageList.Count, 2);
            Assert.AreEqual(ret.MessageList[0].Description, "Module seperator cannot be null.");
            Assert.AreEqual(ret.MessageList[1].Description, "Alphabet/number are not allowed for path seperator. Use special symbol.");
        }

        ///<summary>
        ///15: Correct module seperator, wrong character path seperator passed
        ///</summary>
        [TestMethod(), TestCategory("Create"),
            Description("15: Correct module seperator, wrong character path seperator passed")]
        [DeploymentItem("Crystal.Navigator.Rule.dll")]
        public void SaveTest15()
        {
            Data data; ICrud crud; ReturnObject<Boolean> ret;
            data = new Data { ModuleSeperator = "-", PathSeperator = "p" };
            crud = new Server(data);
            ret = crud.Save();
            Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            Assert.AreEqual(ret.MessageList[0].Description, "Alphabet/number are not allowed for path seperator. Use special symbol.");
        }

        ///<summary>
        ///16: Wrong character module seperator, no path seperator passed
        ///</summary>
        [TestMethod(), TestCategory("Create"),
            Description("16: Wrong character module seperator, no path seperator passed")]
        [DeploymentItem("Crystal.Navigator.Rule.dll")]
        public void SaveTest16()
        {
            Data data; ICrud crud; ReturnObject<Boolean> ret;
            data = new Data { ModuleSeperator = "1" };
            crud = new Server(data);
            ret = crud.Save();
            Assert.AreEqual<Int32>(ret.MessageList.Count, 2);
            Assert.AreEqual(ret.MessageList[0].Description, "Alphabet/number are not allowed for module seperator. Use special symbol.");
            Assert.AreEqual(ret.MessageList[1].Description, "Path seperator cannot be null.");
        }

        ///<summary>
        ///17: Wrong character module seperator, correct path seperator passed
        ///</summary>
        [TestMethod(), TestCategory("Create"),
            Description("17: Wrong character module seperator, correct path seperator passed")]
        [DeploymentItem("Crystal.Navigator.Rule.dll")]
        public void SaveTest17()
        {
            Data data; ICrud crud; ReturnObject<Boolean> ret;
            data = new Data { ModuleSeperator = "m", PathSeperator = "/" };
            crud = new Server(data);
            ret = crud.Save();
            Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            Assert.AreEqual(ret.MessageList[0].Description, "Alphabet/number are not allowed for module seperator. Use special symbol.");
        }

        ///<summary>
        ///18: Wrong character module seperator, wrong character path seperator passed
        ///</summary>
        [TestMethod(), TestCategory("Create"),
            Description("18: Wrong character module seperator, wrong character path seperator passed")]
        [DeploymentItem("Crystal.Navigator.Rule.dll")]
        public void SaveTest18()
        {
            Data data; ICrud crud; ReturnObject<Boolean> ret;
            data = new Data { ModuleSeperator = "m", PathSeperator = "p" };
            crud = new Server(data);
            ret = crud.Save();
            Assert.AreEqual<Int32>(ret.MessageList.Count, 2);
            Assert.AreEqual(ret.MessageList[0].Description, "Alphabet/number are not allowed for module seperator. Use special symbol.");
            Assert.AreEqual(ret.MessageList[1].Description, "Alphabet/number are not allowed for path seperator. Use special symbol.");
        }

        ///<summary>
        ///19: Valid data
        ///</summary>
        [TestMethod(), TestCategory("Create"),
            Description("19: Valid data")]
        [DeploymentItem("Crystal.Navigator.Rule.dll")]
        public void SaveTest19()
        {
            Data data; ICrud crud; ReturnObject<Boolean> ret;
            data = new Data { ModuleSeperator = "-", PathSeperator = "/" };
            crud = new Server(data);
            ret = crud.Save();
            Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            Assert.AreEqual(ret.MessageList[0].Description, "Navigator Rule data successfully updated.");
        }

        #endregion

    }

}
