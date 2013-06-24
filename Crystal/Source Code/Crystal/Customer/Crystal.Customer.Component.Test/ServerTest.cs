using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinAff.Core;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Transactions;

namespace Crystal.Customer.Component.Test
{
    [TestClass]
    public class ServerTest
    {
        [TestMethod(),
        TestCategory("Create"),
        Description("CusTest01"),
        DeploymentItem("Crystal.Customer.Rule.dll")
        ]
        public void CusTest01()
        {
            //Crystal.Customer.Rule.Data ruleData = ReadRule();

            //ICrud crud = new Crystal.Customer.Rule.Server(new Crystal.Customer.Rule.Data()
            //{
            //    IsPinNumber = false,
            //    IsAlternateContactNumber = false,
            //    IsEmail = false,
            //    IsIdentityProof = false
            //});
            //crud.Save();

            //Data data; ReturnObject<Boolean> ret;
            //data = new Data();
            ////crud = new Server(data);
            //ret = crud.Save();

            //SaveRule(ruleData);

            //Assert.AreEqual<Int32>(ret.MessageList.Count, 4);
            //Assert.AreEqual(ret.MessageList[0].Description, "First name cannot be empty.");
            //Assert.AreEqual(ret.MessageList[1].Description, "Address cannot be empty.");
            //Assert.AreEqual(ret.MessageList[2].Description, "State cannot be empty.");
            //Assert.AreEqual(ret.MessageList[3].Description, "City cannot be empty.");
        }

        [TestMethod(),
        TestCategory("Create"),
        Description("CusTest02"),
        DeploymentItem("Crystal.Customer.Rule.dll")
        ]
        public void CusTest02()
        {
            Crystal.Customer.Rule.Data ruleData = ReadRule();

            ICrud crud = new Crystal.Customer.Rule.Server(new Crystal.Customer.Rule.Data()
            {
                IsPinNumber = true,
                IsAlternateContactNumber = true,
                IsEmail = true,
                IsIdentityProof = true
            });
            crud.Save();

            Data data; ReturnObject<Boolean> ret;
            data = new Data();
            //crud = new Server(data);
            ret = crud.Save();

            SaveRule(ruleData);

            Assert.AreEqual<Int32>(ret.MessageList.Count, 8);
            Assert.AreEqual(ret.MessageList[0].Description, "Pin cannot be empty.");
            Assert.AreEqual(ret.MessageList[1].Description, "AlternateContactNumber cannot be empty.");
            Assert.AreEqual(ret.MessageList[2].Description, "Email cannot be empty.");
            Assert.AreEqual(ret.MessageList[3].Description, "Identity Proof cannot be empty.");
            Assert.AreEqual(ret.MessageList[4].Description, "First name cannot be empty.");
            Assert.AreEqual(ret.MessageList[5].Description, "Address cannot be empty.");
            Assert.AreEqual(ret.MessageList[6].Description, "State cannot be empty.");
            Assert.AreEqual(ret.MessageList[7].Description, "City cannot be empty.");
        }


        [TestMethod(),
         TestCategory("Create"),
         Description("CusTest03"),
         DeploymentItem("Crystal.Customer.Rule.dll")
        ]
        public void CusTest03()
        {
            Crystal.Customer.Rule.Data ruleData = ReadRule();

            ICrud crud = new Crystal.Customer.Rule.Server(new Crystal.Customer.Rule.Data()
            {
                IsPinNumber = false,
                IsAlternateContactNumber = true,
                IsEmail = true,
                IsIdentityProof = true
            });
            crud.Save();

            Data data; ReturnObject<Boolean> ret;
            data = new Data();
            //crud = new Server(data);
            ret = crud.Save();

            SaveRule(ruleData);

            Assert.AreEqual<Int32>(ret.MessageList.Count, 7);
            Assert.AreEqual(ret.MessageList[0].Description, "AlternateContactNumber cannot be empty.");
            Assert.AreEqual(ret.MessageList[1].Description, "Email cannot be empty.");
            Assert.AreEqual(ret.MessageList[2].Description, "Identity Proof cannot be empty.");
            Assert.AreEqual(ret.MessageList[3].Description, "First name cannot be empty.");
            Assert.AreEqual(ret.MessageList[4].Description, "Address cannot be empty.");
            Assert.AreEqual(ret.MessageList[5].Description, "State cannot be empty.");
            Assert.AreEqual(ret.MessageList[6].Description, "City cannot be empty.");
        }

        [TestMethod(),
         TestCategory("Create"),
         Description("CusTest04"),
         DeploymentItem("Crystal.Customer.Rule.dll")]
        public void CusTest04()
        {
            Crystal.Customer.Rule.Data ruleData = ReadRule();

            ICrud crud = new Crystal.Customer.Rule.Server(new Crystal.Customer.Rule.Data()
            {
                IsPinNumber = false,
                IsAlternateContactNumber = false,
                IsEmail = true,
                IsIdentityProof = true
            });
            crud.Save();

            Data data; ReturnObject<Boolean> ret;
            data = new Data();
            //crud = new Server(data);
            ret = crud.Save();

            SaveRule(ruleData);

            Assert.AreEqual<Int32>(ret.MessageList.Count, 6);
            Assert.AreEqual(ret.MessageList[0].Description, "Email cannot be empty.");
            Assert.AreEqual(ret.MessageList[1].Description, "Identity Proof cannot be empty.");
            Assert.AreEqual(ret.MessageList[2].Description, "First name cannot be empty.");
            Assert.AreEqual(ret.MessageList[3].Description, "Address cannot be empty.");
            Assert.AreEqual(ret.MessageList[4].Description, "State cannot be empty.");
            Assert.AreEqual(ret.MessageList[5].Description, "City cannot be empty.");
        }

        [TestMethod(),
        TestCategory("Create"),
        Description("CusTest05"),
        DeploymentItem("Crystal.Customer.Rule.dll")]
        public void CusTest05()
        {
            //Crystal.Customer.Rule.Data ruleData = ReadRule();

            //ICrud crud = new Crystal.Customer.Rule.Server(new Crystal.Customer.Rule.Data()
            //{
            //    IsPinNumber = false,
            //    IsAlternateContactNumber = false,
            //    IsEmail = false,
            //    IsIdentityProof = true
            //});
            //crud.Save();

            //Data data; ReturnObject<Boolean> ret;
            //data = new Data();
            //crud = new Server(data);
            //ret = crud.Save();

            //SaveRule(ruleData);

            //Assert.AreEqual<Int32>(ret.MessageList.Count, 5);
            //Assert.AreEqual(ret.MessageList[0].Description, "Identity Proof cannot be empty.");
            //Assert.AreEqual(ret.MessageList[1].Description, "First name cannot be empty.");
            //Assert.AreEqual(ret.MessageList[2].Description, "Address cannot be empty.");
            //Assert.AreEqual(ret.MessageList[3].Description, "State cannot be empty.");
            //Assert.AreEqual(ret.MessageList[4].Description, "City cannot be empty.");
        }

        [TestMethod(),
         TestCategory("Create"),
         Description("CusTest06"),
         DeploymentItem("Crystal.Customer.Rule.dll")]
        public void CusTest06()
        {
            Crystal.Customer.Rule.Data ruleData = ReadRule();

            ICrud crud = new Crystal.Customer.Rule.Server(new Crystal.Customer.Rule.Data()
            {
                IsPinNumber = false,
                IsAlternateContactNumber = false,
                IsEmail = false,
                IsIdentityProof = false
            });
            crud.Save();

            Data data; ReturnObject<Boolean> ret;
            data = new Data()
            {
                Address = "#6 S.K. Apts, Wind Tunnel Road",
                City = "Bangalore",
                ContactNumberList = new List<ContactNumber.Data>() { 
                 new ContactNumber.Data(){ContactNumber = "08041128956"},
                 new ContactNumber.Data(){ContactNumber = "9875469857"},
             },
                Email = "biraj.dhekial@3i-infotech.com",
                FirstName = "Biraj",
                IdentityProof = "AIOPD6173B",
                IdentityProofType = new Crystal.Configuration.Component.IdentityProofType.Data() { Id = 1 },
                Initial = new Crystal.Configuration.Component.Initial.Data() { Id = 2 },
                LastName = "Dhekial",
                MiddleName = "Kumar",
                Pin = 560017,
                State = new Crystal.Configuration.Component.State.Data() { Id = 1 },
            };
            //crud = new Server(data);
            ret = crud.Save();

            SaveRule(ruleData);

            Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            Assert.AreEqual(ret.MessageList[0].Description, "Customer data successfully inserted.");
        }

        [TestMethod(),
          TestCategory("Create"),
          Description("CusTest07"),
          DeploymentItem("Crystal.Customer.Rule.dll")]
        public void CusTest07()
        {
            //Crystal.Customer.Rule.Data ruleData = ReadRule();

            //ICrud crud = new Crystal.Customer.Rule.Server(new Crystal.Customer.Rule.Data()
            //{
            //    IsPinNumber = true,
            //    IsAlternateContactNumber = true,
            //    IsEmail = true,
            //    IsIdentityProof = true
            //});
            //crud.Save();

            //Data data; ReturnObject<Boolean> ret;
            //data = new Data()
            //{
            //    Address = "#6 S.K. Apts, Wind Tunnel Road",
            //    City = "Bangalore",
            //    ContactNumberList = new List<ContactNumber.Data>() { 
            //     new ContactNumber.Data(){ContactNumber = "08041128956"},
            //     new ContactNumber.Data(){ContactNumber = "9875469857"},
            // },
            //    Email = "biraj.dhekial@3i-infotech.com",
            //    FirstName = "Biraj",
            //    IdentityProof = "AIOPD6173B",
            //    IdentityProofType = new Crystal.Configuration.Component.IdentityProofType.Data() { Id = 1 },
            //    Initial = new Crystal.Configuration.Component.Initial.Data() { Id = 2 },
            //    LastName = "Dhekial",
            //    MiddleName = "Kumar",
            //    Pin = 56001781,
            //    State = new Crystal.Configuration.Component.State.Data() { Id = 1 },
            //};
            //crud = new Server(data);
            //ret = crud.Save();

            //SaveRule(ruleData);

            //Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            //Assert.AreEqual(ret.MessageList[0].Description, "Pin is not valid.");
        }

        [TestMethod(),
         TestCategory("Create"),
         Description("CusTest08"),
         DeploymentItem("Crystal.Customer.Rule.dll")]
        public void CusTest08()
        {
            //Crystal.Customer.Rule.Data ruleData = ReadRule();

            //ICrud crud = new Crystal.Customer.Rule.Server(new Crystal.Customer.Rule.Data()
            //{
            //    IsPinNumber = true,
            //    IsAlternateContactNumber = true,
            //    IsEmail = true,
            //    IsIdentityProof = true
            //});
            //crud.Save();

            //Data data; ReturnObject<Boolean> ret;
            //data = new Data()
            //{
            //    Address = "#6 S.K. Apts, Wind Tunnel Road",
            //    City = "Bangalore",
            //    ContactNumberList = new List<ContactNumber.Data>() { 
            //     new ContactNumber.Data(){ContactNumber = "08041128956"},
            //     new ContactNumber.Data(){ContactNumber = "9875469857"},
            // },
            //    Email = "bir@aj.dhekial@3i-infotech.com",
            //    FirstName = "Biraj",
            //    IdentityProof = "AIOPD6173B",
            //    IdentityProofType = new Crystal.Configuration.Component.IdentityProofType.Data() { Id = 1 },
            //    Initial = new Crystal.Configuration.Component.Initial.Data() { Id = 2 },
            //    LastName = "Dhekial",
            //    MiddleName = "Kumar",
            //    Pin = 560017,
            //    State = new Crystal.Configuration.Component.State.Data() { Id = 1 },
            //};
            //crud = new Server(data);
            //ret = crud.Save();

            //SaveRule(ruleData);

            //Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            //Assert.AreEqual(ret.MessageList[0].Description, "Email is not valid.");
        }

        [TestMethod(),
         TestCategory("Create"),
         Description("CusTest09"),
         DeploymentItem("Crystal.Customer.Rule.dll")]
        public void CusTest09()
        {
            //Crystal.Customer.Rule.Data ruleData = ReadRule();

            //ICrud crud = new Crystal.Customer.Rule.Server(new Crystal.Customer.Rule.Data()
            //{
            //    IsPinNumber = true,
            //    IsAlternateContactNumber = true,
            //    IsEmail = true,
            //    IsIdentityProof = true
            //});
            //crud.Save();

            //Data data; ReturnObject<Boolean> ret;
            //data = new Data()
            //{
            //    Address = "#6 S.K. Apts, Wind Tunnel Road",
            //    City = "Bangalore",
            //    ContactNumberList = new List<ContactNumber.Data>() { 
            //     new ContactNumber.Data(){ContactNumber = "08041128956"},
            //     new ContactNumber.Data(){ContactNumber = "9875469857x"},
            // },
            //    Email = "biraj.dhekial@3i-infotech.com",
            //    FirstName = "Biraj",
            //    IdentityProof = "AIOPD6173B",
            //    IdentityProofType = new Crystal.Configuration.Component.IdentityProofType.Data() { Id = 1 },
            //    Initial = new Crystal.Configuration.Component.Initial.Data() { Id = 2 },
            //    LastName = "Dhekial",
            //    MiddleName = "Kumar",
            //    Pin = 560017,
            //    State = new Crystal.Configuration.Component.State.Data() { Id = 1 },
            //};
            //crud = new Server(data);
            //ret = crud.Save();

            //SaveRule(ruleData);

            //Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            //Assert.AreEqual(ret.MessageList[0].Description, "Phone number is not valid.");
        }

        [TestMethod(),
         TestCategory("Create"),
         Description("CusTest10"),
         DeploymentItem("Crystal.Customer.Rule.dll")]
        public void CusTest10()
        {
            //Crystal.Customer.Rule.Data ruleData = ReadRule();

            //ICrud crud = new Crystal.Customer.Rule.Server(new Crystal.Customer.Rule.Data()
            //{
            //    IsPinNumber = true,
            //    IsAlternateContactNumber = true,
            //    IsEmail = true,
            //    IsIdentityProof = true
            //});
            //crud.Save();

            //Data data; ReturnObject<Boolean> ret;
            //data = new Data()
            //{
            //    Address = "#6 S.K. Apts, Wind Tunnel Road",
            //    City = "Bangalore",
            //    ContactNumberList = new List<ContactNumber.Data>() { 
            //     new ContactNumber.Data(){ContactNumber = "08041128956"},
            //     new ContactNumber.Data(){ContactNumber = "9875469857"},
            // },
            //    Email = "biraj.dhekial@3i-infotech.com",
            //    FirstName = "Biraj12",
            //    IdentityProof = "AIOPD6173B",
            //    IdentityProofType = new Crystal.Configuration.Component.IdentityProofType.Data() { Id = 1 },
            //    Initial = new Crystal.Configuration.Component.Initial.Data() { Id = 2 },
            //    LastName = "Dhekial12",
            //    MiddleName = "Kumar12",
            //    Pin = 560017,
            //    State = new Crystal.Configuration.Component.State.Data() { Id = 1 },
            //};
            //crud = new Server(data);
            //ret = crud.Save();

            //SaveRule(ruleData);

            //Assert.AreEqual<Int32>(ret.MessageList.Count, 3);
            //Assert.AreEqual(ret.MessageList[0].Description, "First name is not valid.");
            //Assert.AreEqual(ret.MessageList[1].Description, "Middle name is not valid.");
            //Assert.AreEqual(ret.MessageList[2].Description, "Last name is not valid.");
        }

        [TestMethod(),
         TestCategory("Create"),
         Description("CusTest11"),
         DeploymentItem("Crystal.Customer.Rule.dll")]
        public void CusTest11()
        {
            //String duplicateCustomerInfo = String.Empty; ;
            //Crystal.Customer.Rule.Data ruleData = ReadRule();
            //Data data; ReturnObject<Boolean> ret = new ReturnObject<bool>();

            //using (TransactionScope scope = new TransactionScope())
            //{
            //    ICrud crud = new Crystal.Customer.Rule.Server(new Crystal.Customer.Rule.Data()
            //    {
            //        IsPinNumber = true,
            //        IsAlternateContactNumber = true,
            //        IsEmail = true,
            //        IsIdentityProof = true
            //    });
            //    crud.Save();

            //    crud = new Crystal.Customer.Component.Server(new Data());
            //    ReturnObject<List<BinAff.Core.Data>> retVal = crud.ReadAll();

            //    if (retVal.Value != null && retVal.Value.Count > 0)
            //    {
            //        data = (Data)retVal.Value[0];

            //        data = new Data()
            //        {
            //            Address = "#6 S.K. Apts, Wind Tunnel Road",
            //            City = "Bangalore",
            //            ContactNumberList = new List<ContactNumber.Data>() { 
            //         new ContactNumber.Data(){ContactNumber = "08041121156"},
            //         new ContactNumber.Data(){ContactNumber = "9875111857"},
            //     },
            //            Email = data.Email,
            //            FirstName = "Biraj",
            //            IdentityProof = "DL123",
            //            IdentityProofType = new Crystal.Configuration.Component.IdentityProofType.Data() { Id = 2 },
            //            Initial = new Crystal.Configuration.Component.Initial.Data() { Id = 2 },
            //            LastName = "Dhekial",
            //            MiddleName = "Kumar",
            //            Pin = 560017,
            //            State = new Crystal.Configuration.Component.State.Data() { Id = 1 },
            //        };
            //        //crud = new Server(data);
            //        ret = crud.Save();

            //        duplicateCustomerInfo = this.IsExists(data);

            //    }

            //    SaveRule(ruleData);

            //    scope.Complete();
            //}
            //Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            //Assert.AreEqual(ret.MessageList[0].Description, duplicateCustomerInfo);
        }


        [TestMethod(),
        TestCategory("Create"),
        Description("CusTest12"),
        DeploymentItem("Crystal.Customer.Rule.dll")]
        public void CusTest12()
        {
            //String duplicateCustomerInfo = String.Empty; ;
            //Crystal.Customer.Rule.Data ruleData = ReadRule();
            //Data data; ReturnObject<Boolean> ret = new ReturnObject<bool>();

            //using (TransactionScope scope = new TransactionScope())
            //{
            //    ICrud crud = new Crystal.Customer.Rule.Server(new Crystal.Customer.Rule.Data()
            //    {
            //        IsPinNumber = false,
            //        IsAlternateContactNumber = false,
            //        IsEmail = false,
            //        IsIdentityProof = false
            //    });
            //    crud.Save();

            //    crud = new Crystal.Customer.Component.Server(new Data());
            //    ReturnObject<List<BinAff.Core.Data>> retVal = crud.ReadAll();

            //    if (retVal.Value != null && retVal.Value.Count > 0)
            //    {
            //        data = (Data)retVal.Value[0];

            //        data = new Data()
            //        {
            //            Address = "#6 S.K. Apts, Wind Tunnel Road",
            //            City = "Bangalore",
            //            ContactNumberList = new List<ContactNumber.Data>() { 
            //                                     new ContactNumber.Data(){ContactNumber = "08041121156"},
            //                                     new ContactNumber.Data(){ContactNumber = "9875469857"},
            //                                 },
            //            Email = "abc@nic.com@",
            //            FirstName = "Biraj",
            //            IdentityProof = "DL123",
            //            IdentityProofType = new Crystal.Configuration.Component.IdentityProofType.Data() { Id = 2 },
            //            Initial = new Crystal.Configuration.Component.Initial.Data() { Id = 2 },
            //            LastName = "Dhekial",
            //            MiddleName = "Kumar",
            //            Pin = 560017,
            //            State = new Crystal.Configuration.Component.State.Data() { Id = 1 },
            //        };
            //        //crud = new Server(data);
            //        ret = crud.Save();

            //        duplicateCustomerInfo = this.IsExists(data);

            //    }

            //    SaveRule(ruleData);
            //    scope.Complete();
            //}
            //Assert.AreEqual<Int32>(ret.MessageList.Count, 2);
            //Assert.AreEqual(ret.MessageList[0].Description, "Email is not valid.");
            //Assert.AreEqual(ret.MessageList[1].Description, duplicateCustomerInfo);
        }

        [TestMethod(),
         TestCategory("Delete"),
         Description("CusTest13"),
         DeploymentItem("Crystal.Customer.Rule.dll")]
        public void CusTest13()
        {
            //String duplicateCustomerInfo = String.Empty; ;
            //Crystal.Customer.Rule.Data ruleData = ReadRule();
            //Data data; ReturnObject<Boolean> ret = new ReturnObject<bool>();

            //using (TransactionScope scope = new TransactionScope())
            //{
            //    ICrud crud = new Crystal.Customer.Component.Server(new Data());
            //    ReturnObject<List<BinAff.Core.Data>> retVal = crud.ReadAll();

            //    if (retVal.Value != null && retVal.Value.Count > 0)
            //    {
            //        data = (Data)retVal.Value[0];

            //        crud = new Server(data);
            //        ret = crud.Delete();
            //    }

            //    Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            //    Assert.AreEqual(ret.MessageList[0].Description, "Customer data successfully deleted.");

            //    data = (Data)retVal.Value[0];
            //    data.Id = 0;
            //    crud = new Server(data);
            //    ret = crud.Save();
            //    if (ret.MessageList[0].Description == "Customer data successfully inserted.")
            //        scope.Complete();
            //}
        }

        [TestMethod(),
         TestCategory("Update"),
         Description("CusTest14"),
         DeploymentItem("Crystal.Customer.Rule.dll")]
        public void CusTest14()
        {
            
            //Data data = new Data(); 
            //ReturnObject<Boolean> ret = new ReturnObject<bool>();

            //ICrud crud = new Crystal.Customer.Component.Server(new Data());
            //ReturnObject<List<BinAff.Core.Data>> retVal = crud.ReadAll();
            //String email = String.Empty;

            //using (TransactionScope scope = new TransactionScope())
            //{
            //    if (retVal.Value != null && retVal.Value.Count > 0)
            //    {
            //        data = (Data)retVal.Value[0];
            //        email = data.Email;
            //        data.Email = "abaac@ppp.com";

            //        crud = new Server(data);
            //        ret = crud.Save();
            //    }

            //    Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            //    Assert.AreEqual(ret.MessageList[0].Description, "Customer data successfully updated.");

            //    data.Email = email;
            //    ret = crud.Save();

            //    scope.Complete();
            //}

            
        }

        [TestMethod(),
        TestCategory("Update"),
        Description("CusTest15"),
        DeploymentItem("Crystal.Customer.Rule.dll")]
        public void CusTest15()
        {

            //Data data = new Data();
            //ReturnObject<Boolean> ret = new ReturnObject<bool>();

            //ICrud crud = new Crystal.Customer.Component.Server(new Data());
            //ReturnObject<List<BinAff.Core.Data>> retVal = crud.ReadAll();

            //using (TransactionScope scope = new TransactionScope())
            //{
            //    if (retVal.Value != null && retVal.Value.Count > 0)
            //    {
            //        data = (Data)retVal.Value[0];
            //        data.FirstName = "123dd";
            //        data.MiddleName = "34fff";
            //        data.LastName = "asa22";

            //        crud = new Server(data);
            //        ret = crud.Save();
            //    }

            //    Assert.AreEqual<Int32>(ret.MessageList.Count, 3);
            //    Assert.AreEqual(ret.MessageList[0].Description, "First name is not valid.");
            //    Assert.AreEqual(ret.MessageList[1].Description, "Middle name is not valid.");
            //    Assert.AreEqual(ret.MessageList[2].Description, "Last name is not valid.");

            //    //scope.Complete();
            //}


        }


        [TestMethod(),
        TestCategory("Update"),
        Description("CusTest16"),
        DeploymentItem("Crystal.Customer.Rule.dll")]
        public void CusTest16()
        {

            //Data data = new Data();
            //ReturnObject<Boolean> ret = new ReturnObject<bool>();

            //ICrud crud = new Crystal.Customer.Component.Server(new Data());
            //ReturnObject<List<BinAff.Core.Data>> retVal = crud.ReadAll();
            //List<ContactNumber.Data> contactNumber = new List<ContactNumber.Data>();

            //using (TransactionScope scope = new TransactionScope())
            //{
            //    if (retVal.Value != null && retVal.Value.Count > 0)
            //    {
            //        data = (Data)retVal.Value[0];
            //        contactNumber = data.ContactNumberList;
            //        data.ContactNumberList = new List<ContactNumber.Data>() { 
            //            new ContactNumber.Data(){ContactNumber = "2222233333" },
            //            new ContactNumber.Data(){ContactNumber = "1111122222" },                       
            //        };

            //        crud = new Server(data);
            //        ret = crud.Save();
            //    }

            //    Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            //    Assert.AreEqual(ret.MessageList[0].Description, "Customer data successfully updated.");

            //    data.ContactNumberList = contactNumber;
            //    ret = crud.Save();

            //    scope.Complete();
            //}


        }

        [TestMethod(),
           TestCategory("Update"),
           Description("CusTest17"),
           DeploymentItem("Crystal.Customer.Rule.dll")]
        public void CusTest17()
        {

            //Data data = new Data();
            //ReturnObject<Boolean> ret = new ReturnObject<bool>();

            //ICrud crud = new Crystal.Customer.Component.Server(new Data());
            //ReturnObject<List<BinAff.Core.Data>> retVal = crud.ReadAll();
            //String middleName = String.Empty;

            //using (TransactionScope scope = new TransactionScope())
            //{
            //    if (retVal.Value != null && retVal.Value.Count > 0)
            //    {
            //        data = (Data)retVal.Value[0];
            //        middleName = data.MiddleName;

            //        data.MiddleName = "";

            //        crud = new Server(data);
            //        ret = crud.Save();
            //    }

            //    Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            //    Assert.AreEqual(ret.MessageList[0].Description, "Customer data successfully updated.");

            //    data.MiddleName = middleName;
            //    ret = crud.Save();

            //    scope.Complete();
            //}


        }

        [TestMethod(),
          TestCategory("Update"),
          Description("CusTest18"),
          DeploymentItem("Crystal.Customer.Rule.dll")]
        public void CusTest18()
        {

            //Crystal.Customer.Rule.Data ruleData = ReadRule();

            //Data data = new Data();
            //ReturnObject<Boolean> ret = new ReturnObject<bool>();

            //using (TransactionScope scope = new TransactionScope())
            //{
            //    ICrud crud = new Crystal.Customer.Rule.Server(new Crystal.Customer.Rule.Data()
            //    {
            //        IsPinNumber = false,
            //        IsAlternateContactNumber = false,
            //        IsEmail = false,
            //        IsIdentityProof = false
            //    });
            //    crud.Save();

            //    crud = new Crystal.Customer.Component.Server(new Data());
            //    ReturnObject<List<BinAff.Core.Data>> retVal = crud.ReadAll();  

            //    if (retVal.Value != null && retVal.Value.Count > 0)
            //    {
            //        data = (Data)retVal.Value[0];                 

            //        data.ContactNumberList = new List<ContactNumber.Data>() { 
            //            new ContactNumber.Data(){ContactNumber = "1234565432"},
            //            new ContactNumber.Data()
            //        };

            //        crud = new Server(data);
            //        ret = crud.Save();
            //    }

            //    Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            //    Assert.AreEqual(ret.MessageList[0].Description, "Phone number is not valid.");
                
            //    SaveRule(ruleData);

            //    scope.Complete();
            //}


        }

        [TestMethod(),
         TestCategory("Update"),
         Description("CusTest19"),
         DeploymentItem("Crystal.Customer.Rule.dll")]
        public void CusTest19()
        {

            //Crystal.Customer.Rule.Data ruleData = ReadRule();

            //Data data = new Data();
            //ReturnObject<Boolean> ret = new ReturnObject<bool>();

            //using (TransactionScope scope = new TransactionScope())
            //{
            //    ICrud crud = new Crystal.Customer.Rule.Server(new Crystal.Customer.Rule.Data()
            //    {
            //        IsPinNumber = true,
            //        IsAlternateContactNumber = true,
            //        IsEmail = true,
            //        IsIdentityProof = true
            //    });
            //    crud.Save();

            //    crud = new Crystal.Customer.Component.Server(new Data());
            //    ReturnObject<List<BinAff.Core.Data>> retVal = crud.ReadAll();

            //    if (retVal.Value != null && retVal.Value.Count > 0)
            //    {
            //        data = (Data)retVal.Value[0];

            //        data.ContactNumberList = new List<ContactNumber.Data>() { 
            //            new ContactNumber.Data(){ContactNumber = "1234565432"},
            //            new ContactNumber.Data(){ContactNumber = String.Empty }
            //        };

            //        crud = new Server(data);
            //        ret = crud.Save();
            //    }

            //    Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            //    Assert.AreEqual(ret.MessageList[0].Description, "Phone number is not valid.");

            //    SaveRule(ruleData);

            //    scope.Complete();
            //}


        }


        [TestMethod(),
         TestCategory("Create - Action Status"),
         Description("CusTest20"),
         DeploymentItem("Crystal.Customer.Rule.dll")]
        public void CusTest20()
        {
            Crystal.Customer.Component.Action.Status.Data data = new Action.Status.Data() { 
                Name = "Close",
            };
            ICrud crud = new Crystal.Customer.Component.Action.Status.Server(data);
            ReturnObject<Boolean> ret = crud.Save();

            Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            Assert.AreEqual(ret.MessageList[0].Description, "Action Status data successfully inserted.");
        }

        [TestMethod(),
        TestCategory("Read - Action Status"),
        Description("CusTest21"),
        DeploymentItem("Crystal.Customer.Rule.dll")]
        public void CusTest21()
        {
            Crystal.Customer.Component.Action.Status.Data data = new Action.Status.Data()
            {
                Id = 1
            };
            ICrud crud = new Crystal.Customer.Component.Action.Status.Server(data);
            ReturnObject<BinAff.Core.Data> ret = crud.Read();
            Assert.AreEqual(ret.MessageList, null);
        }

        [TestMethod(),
        TestCategory("ReadAll - Action Status"),
        Description("CusTest22"),
        DeploymentItem("Crystal.Customer.Rule.dll")]
        public void CusTest22()
        {            
            ICrud crud = new Crystal.Customer.Component.Action.Status.Server(null);
            ReturnObject<List<BinAff.Core.Data>> ret = crud.ReadAll();
            Assert.AreEqual(ret.MessageList, null);
        }

        [TestMethod(),
        TestCategory("Modify - Action Status"),
        Description("CusTest23"),
        DeploymentItem("Crystal.Customer.Rule.dll")]
        public void CusTest23()
        {
            Crystal.Customer.Component.Action.Status.Data data = new Action.Status.Data()
            {
                Id = 1,
                Name = "Open"
            };
            ICrud crud = new Crystal.Customer.Component.Action.Status.Server(data);
            ReturnObject<Boolean> ret = crud.Save();
            Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            Assert.AreEqual(ret.MessageList[0].Description, "Action Status data successfully updated.");
        }

        [TestMethod(),
        TestCategory("Delete - Action Status"),
        Description("CusTest24"),
        DeploymentItem("Crystal.Customer.Rule.dll")]
        public void CusTest24()
        {
            Crystal.Customer.Component.Action.Status.Data data = new Action.Status.Data()
            {
                Id = 2
            };
            ICrud crud = new Crystal.Customer.Component.Action.Status.Server(data);
            ReturnObject<Boolean> ret = crud.Delete();
            Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            Assert.AreEqual(ret.MessageList[0].Description, "Action Status data successfully deleted.");
        }


        private Crystal.Customer.Rule.Data ReadRule()
        {
            ICrud crud = new Crystal.Customer.Rule.Server(new Crystal.Customer.Rule.Data());
            return (Crystal.Customer.Rule.Data)crud.Read().Value;
        }

        private void SaveRule(Crystal.Customer.Rule.Data data)
        {
            ICrud crud = new Crystal.Customer.Rule.Server(data);
            crud.Save();
        }

        private String IsExists(Data data)
        {
            StringBuilder ret = new StringBuilder();
            //List<Int64> duplicateIdList = CheckDuplicate(data);
            //if (duplicateIdList != null && duplicateIdList.Count > 0)
            //{
            //    ret.Append("Customer with similar information exists. Customer list:\r\n");
            //    Data d;
            //    foreach (Int64 id in duplicateIdList)
            //    {
            //        d = new Data { Id = id };
            //        ICrud server = new Server(d);
            //        server.Read();
            //        ret.Append(d.FirstName + ":: ");
            //        if (!String.IsNullOrEmpty(d.Email) && String.Compare(d.Email, data.Email, StringComparison.OrdinalIgnoreCase) == 0)
            //        {
            //            ret.Append("Email: '" + d.Email + "' ");
            //        }
            //        if (d.IdentityProofType.Id != 0 && d.IdentityProofType.Id == data.IdentityProofType.Id && String.Compare(d.IdentityProof, data.IdentityProof, StringComparison.OrdinalIgnoreCase) == 0)
            //        {
            //            ret.Append("Identity: '" + d.IdentityProofType.Name + " " + d.IdentityProof + "' ");
            //        }
            //        Int32 len = d.ContactNumberList.Count;
            //        Boolean isFirst = true;
            //        if (d.ContactNumberList != null)
            //        {
            //            foreach (ContactNumber.Data phone in d.ContactNumberList)
            //            {
            //                String phoneNumber = phone.ContactNumber;
            //                if (data.ContactNumberList.Exists((p) => p.ContactNumber == phoneNumber))
            //                {
            //                    if (isFirst) { ret.Append("Matching contact number: "); isFirst = false; }
            //                    ret.Append("'" + phoneNumber + "' ");
            //                }
            //            }
            //        }
            //        ret.Append("\r\n");
            //    }
            //}

            return ret.ToString();
        }

        private List<Int64> CheckDuplicate(Data data)
        {
            string strCon = @"Data Source=RENTAL2;Initial Catalog=AutoTourism;User Id=sa;Password=infotech@1;";

            String contactNumberList = String.Empty;
            Int32 len = (data.ContactNumberList != null) ? data.ContactNumberList.Count : 0;
            if (len > 0)
            {
                for (Int32 i = 0; i < len; i++)
                {
                    contactNumberList += data.ContactNumberList[i].ContactNumber;
                    if (i < len - 1) contactNumberList += ",";
                }
            }

            string strSql = "SELECT Id FROM Customer WHERE (IdentityProofId = " + data.IdentityProofType.Id;
            strSql += " AND IdentityProofName = '" + data.IdentityProof + "')";
            strSql += " OR (Email = '" + data.Email + "' AND '" + data.Email + "' != '')";
            strSql += " OR ID IN (SELECT CustomerId FROM CustomerContactNumber";
            strSql += " WHERE Number IN (SELECT SplitText FROM Split('" + contactNumberList + "', ',')))";


            SqlConnection con = new SqlConnection(strCon);
            con.Open();

            SqlDataAdapter dadapter = new SqlDataAdapter();
            dadapter.SelectCommand = new SqlCommand(strSql, con);
            DataSet ds = new DataSet();
            dadapter.Fill(ds);
            con.Close();

            List<Int64> retIds = new List<Int64>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (!Convert.IsDBNull(dr["Id"]) && Convert.ToInt64(dr["Id"]) != data.Id) retIds.Add(Convert.ToInt64(dr["Id"]));
                }
            }

            return retIds;

        }


    }
}
