using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using BinAff.Core;

using Artf = Crystal.Navigator.Component.Artifact;

namespace Crystal.Navigator.Component.Test
{    
    
    /// <summary>
    ///This is a test class for ServerTest and is intended
    ///to contain all ServerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ArtifactServerTest
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

        ///<summary>
        ///01: No value passed in create
        ///</summary>
        [TestMethod(),
            TestCategory("Create"),
            Description("01: No value passed in create")]
        [DeploymentItem("Crystal.Navigator.Component.dll")]
        public void SaveTest01()
        {
            Artf.Data data; ICrud crud; ReturnObject<Boolean> ret;
            data = new Artf.Data();
            crud = new Artf.Server(data);
            ret = crud.Save();
            Assert.AreEqual<Int32>(ret.MessageList.Count, 3);
            Assert.AreEqual(ret.MessageList[0].Description, "File/Directory name cannot be empty.");
            Assert.AreEqual(ret.MessageList[1].Description, "Creator of File/Directory cannot be empty.");
            Assert.AreEqual(ret.MessageList[2].Description, "Creation time of File/Directory cannot be empty.");
        }

        ///<summary>
        ///02: Valid data
        ///</summary>
        [TestMethod(),
            TestCategory("Create"),
            Description("02: Valid data")]
        [DeploymentItem("Crystal.Navigator.Component.dll")]
        public void SaveTest02()
        {
            Artf.Data data; ICrud crud; ReturnObject<Boolean> ret;
            List<BinAff.Core.Data> acountList;
            crud = new Guardian.Component.Account.Server(null);
            acountList = crud.ReadAll().Value;
            Assert.AreNotEqual<Int32>(acountList.Count, 0);//Fail if there is no record
            if (acountList.Count > 0)
            {
                data = new Artf.Data
                {
                    FileName = "File1",
                    CreatedBy = new Guardian.Component.Account.Data { Id = acountList[0].Id },
                    CreatedAt = DateTime.Now,
                };
                crud = new Artf.Server(data);
                ret = crud.Save();
                Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
                Assert.AreEqual(ret.MessageList[0].Description, "Artifact data successfully inserted.");
            }
        }

        ///<summary>
        ///03: Valid data
        ///</summary>
        [TestMethod(),
            TestCategory("Update"),
            Description("03: Valid data")]
        [DeploymentItem("Crystal.Navigator.Component.dll")]
        public void SaveTest03()
        {
            Artf.Data data; ICrud crud; ReturnObject<Boolean> ret;
            List<BinAff.Core.Data> acountList;
            crud = new Guardian.Component.Account.Server(null);
            acountList = crud.ReadAll().Value;
            Assert.AreNotEqual<Int32>(acountList.Count, 0);//Fail if there is no record
            if (acountList.Count > 0)
            {
                //Hardcoding of id needs to be changed.
                data = new Artf.Data
                {
                    Id = 10,
                    FileName = "File2",
                    ModifiedBy = new Guardian.Component.Account.Data { Id = acountList[0].Id },
                    ModifiedAt = DateTime.Now,
                    
                };
                crud = new Artf.Server(data);
                ret = crud.Save();
                Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
                Assert.AreEqual(ret.MessageList[0].Description, "Artifact data successfully updated.");
            }
        }

        ///<summary>
        ///02: Valid data
        ///</summary>
        [TestMethod(),
            TestCategory("Read"),
            Description("04: Valid data")]
        [DeploymentItem("Crystal.Navigator.Component.dll")]
        public void SaveTest04()
        {
            Artf.Data data; ICrud crud; ReturnObject<BinAff.Core.Data> ret;
            //Hardcoding of id needs to be changed.
            data = new Artf.Data
            {
                Id = 10,
            };
            crud = new Artf.Server(data);
            ret = crud.Read();
            //need to add asserts
            //Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            //Assert.AreEqual(ret.MessageList[0].Description, "Artifact data successfully updated.");
        }
                
        ///<summary>
        ///05: Read All
        ///</summary>
        [TestMethod(),
            TestCategory("Read"),
            Description("05: Read All")]
        [DeploymentItem("Crystal.Navigator.Component.dll")]
        public void SaveTest05()
        {
            ICrud crud; ReturnObject<List<BinAff.Core.Data>> ret;
            crud = new Artf.Server(null);
            ret = crud.ReadAll();
        }

        ///<summary>
        ///06: Form Tree
        ///</summary>
        [TestMethod(),
            TestCategory("Read"),
            Description("06: Form Tree")]
        [DeploymentItem("Crystal.Navigator.Component.dll")]
        public void SaveTest06()
        {
            Crystal.Navigator.Component.Artifact.IArtifact crud; ReturnObject<Crystal.Navigator.Component.Artifact.Data> ret;
            crud = new Artf.Server(null);
            ret = crud.FormTree();
            //need to add asserts
            //Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            //Assert.AreEqual(ret.MessageList[0].Description, "Artifact data successfully updated.");
        }

    }

}
