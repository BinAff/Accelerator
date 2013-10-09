using Crystal.Navigator.Form.Customer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

using BinAff.Core;

using Artf = Crystal.Navigator.Component.Artifact;
using Cust = Crystal.Customer.Component;
using State = Crystal.Configuration.Component.State;
using IdentityProofType = Crystal.Configuration.Component.IdentityProofType;
using Crystal.Navigator.Component.Form;
using Crystal.Navigator.Component.Artifact;

namespace Crystal.Navigator.Form.Customer.Test
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
        
        ///<summary>
        ///01: No value passed in create
        ///</summary>
        [TestMethod(),
            TestCategory("Create"),
            Description("01: No value passed in create")]
        [DeploymentItem("Crystal.Navigator.Form.Customer.dll")]
        public void SaveTest01()
        {
            Data data; ICrud crud; ReturnObject<Boolean> ret;
            data = new Data();
            crud = new Crystal.Navigator.Form.Customer.Server(data);
            ret = crud.Save();
            Assert.AreEqual<Int32>(ret.MessageList.Count, 4);
            Assert.AreEqual(ret.MessageList[0].Description, "File/Directory name cannot be empty.");
            Assert.AreEqual(ret.MessageList[1].Description, "Creator of File/Directory cannot be empty.");
            Assert.AreEqual(ret.MessageList[2].Description, "Creation time of File/Directory cannot be empty.");
            Assert.AreEqual(ret.MessageList[3].Description, "Style cannot be empty.");
        }

        ///<summary>
        ///02: Empty Artifact and Customer passed in create
        ///</summary>
        [TestMethod(),
            TestCategory("Create"),
            Description("02: Empty Artifact and Customer passed in create")]
        [DeploymentItem("Crystal.Navigator.Form.Customer.dll")]
        public void SaveTest02()
        {
            Data data; ICrud crud; ReturnObject<Boolean> ret;
            data = new Data
            {
                ModuleData = new Cust.Data(),
            };
            crud = new Crystal.Navigator.Form.Customer.Server(data);
            ret = crud.Save();
            Assert.AreEqual<Int32>(ret.MessageList.Count, 8);
            Assert.AreEqual(ret.MessageList[0].Description, "File/Directory name cannot be empty.");
            Assert.AreEqual(ret.MessageList[1].Description, "Creator of File/Directory cannot be empty.");
            Assert.AreEqual(ret.MessageList[2].Description, "Creation time of File/Directory cannot be empty.");
            Assert.AreEqual(ret.MessageList[3].Description, "Style cannot be empty.");
            Assert.AreEqual(ret.MessageList[4].Description, "First name cannot be empty.");
            Assert.AreEqual(ret.MessageList[5].Description, "Address cannot be empty.");
            Assert.AreEqual(ret.MessageList[6].Description, "State cannot be empty.");
            Assert.AreEqual(ret.MessageList[7].Description, "City cannot be empty.");
        }

        ///<summary>
        ///03: Valid data to create
        ///</summary>
        [TestMethod(),
            TestCategory("Create"),
            Description("03: Valid data to create")]
        [DeploymentItem("Crystal.Navigator.Form.Customer.dll")]
        public void SaveTest03()
        {
            Data data; ICrud crud; ReturnObject<Boolean> ret;            
            List<BinAff.Core.Data> acountList;
            crud = new Guardian.Component.Account.Server(null);
            acountList = crud.ReadAll().Value;
            Assert.AreNotEqual<Int32>(acountList.Count, 0);//Fail if there is no record
            
            List<BinAff.Core.Data> stateList;
            crud = new State.Server(null);
            stateList = crud.ReadAll().Value;
            Assert.AreNotEqual<Int32>(stateList.Count, 0);//Fail if there is no record

            List<BinAff.Core.Data> identityProofList;
            crud = new IdentityProofType.Server(null);
            identityProofList = crud.ReadAll().Value;
            Assert.AreNotEqual<Int32>(identityProofList.Count, 0);//Fail if there is no record

            if (acountList.Count > 0 && stateList.Count > 0 && identityProofList.Count > 0)
            {
                data = new Data
                {
                    FileName = "CustomerForm1",
                    Style = Artf.Type.Document,
                    CreatedBy = new Guardian.Component.Account.Data { Id = acountList[0].Id },
                    CreatedAt = DateTime.Now,
                    ModuleData = new Cust.Data
                    {   //Need to change hard coding
                        FirstName = "Arpan",
                        Address = "Address1",
                        Email = "email4@binaff.in",//Not specifying throwing error
                        IdentityProofType = new IdentityProofType.Data { Id = identityProofList[0].Id },//Not specifying throwing error
                        IdentityProof = "AMLPK3166D",//Not specifying throwing error
                        State = new State.Data { Id = stateList[0].Id },
                        City = "City1",
                    },
                };
                crud = new Crystal.Navigator.Form.Customer.Server(data);
                ret = crud.Save();
                Assert.AreEqual<Int32>(ret.MessageList.Count, 2);
                Assert.AreEqual(ret.MessageList[0].Description, "Customer data successfully inserted.");
                Assert.AreEqual(ret.MessageList[1].Description, "Customer Form data successfully inserted.");
            }
        }

        ///<summary>
        ///03: Valid data to create
        ///</summary>
        [TestMethod(),
            TestCategory("Create"),
            Description("04: Valid data without customer to create")]
        [DeploymentItem("Crystal.Navigator.Form.Customer.dll")]
        public void SaveTest04()
        {
            Data data; ICrud crud; ReturnObject<Boolean> ret;
            List<BinAff.Core.Data> acountList;
            crud = new Guardian.Component.Account.Server(null);
            acountList = crud.ReadAll().Value;
            Assert.AreNotEqual<Int32>(acountList.Count, 0);//Fail if there is no record

            List<BinAff.Core.Data> stateList;
            crud = new State.Server(null);
            stateList = crud.ReadAll().Value;
            Assert.AreNotEqual<Int32>(stateList.Count, 0);//Fail if there is no record

            List<BinAff.Core.Data> identityProofList;
            crud = new IdentityProofType.Server(null);
            identityProofList = crud.ReadAll().Value;
            Assert.AreNotEqual<Int32>(identityProofList.Count, 0);//Fail if there is no record

            if (acountList.Count > 0 && stateList.Count > 0 && identityProofList.Count > 0)
            {
                data = new Data
                {
                    FileName = "CustomerForm1",
                    Style = Artf.Type.Document,
                    CreatedBy = new Guardian.Component.Account.Data { Id = acountList[0].Id },
                    CreatedAt = DateTime.Now,
                };
                crud = new Crystal.Navigator.Form.Customer.Server(data);
                ret = crud.Save();
                Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
                Assert.AreEqual(ret.MessageList[0].Description, "Customer Form data successfully inserted.");
            }
        }

        ///<summary>
        ///04: Read Exisiting record
        ///</summary>
        [TestMethod(),
            TestCategory("Read"),
            Description("901: Read Exisiting record")]
        [DeploymentItem("Crystal.Navigator.Form.Customer.dll")]
        public void ReadTest901()
        {
            //Not correct way to test
            Data data; ICrud crud; ReturnObject<BinAff.Core.Data> ret;
            //Hardcoding of id needs to be changed.
            data = new Data { Id = 37 };
            crud = new Crystal.Navigator.Form.Customer.Server(data);
            ret = crud.Read();
            int i = 0;          
        }

        ///<summary>
        ///05: Read All Records
        ///</summary>
        [TestMethod(),
            TestCategory("Read"),
            Description("902: Read All Records")]
        [DeploymentItem("Crystal.Navigator.Form.Customer.dll")]
        public void ReadTest902()
        {
            //Not correct way to test
            ICrud crud; ReturnObject<List<BinAff.Core.Data>> ret;
            crud = new Crystal.Navigator.Form.Customer.Server(null);
            ret = crud.ReadAll();
            int i = 0;       
        }

        ///<summary>
        ///06: Form Tree
        ///</summary>
        [TestMethod(),
            TestCategory("Read"),
            Description("903: Form Tree")]
        [DeploymentItem("Crystal.Navigator.Form.Customer.dll")]
        public void ReadTest903()
        {
            //Not correct way to test
            IArtifact crud; ReturnObject<Crystal.Navigator.Component.Artifact.Data> ret;
            crud = new Crystal.Navigator.Form.Customer.Server(null);
            ret = crud.FormTree();
            int i = 0;
        }

    }

}