using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinAff.Core;
using BinAff.Core.Observer;

namespace Crystal.Organization.Component.Test
{
    [TestClass]
    public class ServerTest
    {

        [TestMethod(),
        TestCategory("Read"),
        Description("OrgTest01"),
        DeploymentItem("Crystal.Organization.Component.dll")
        ]
        public void OrgTest01()
        {

            ICrud crud = new Crystal.Organization.Component.Server(new Crystal.Organization.Component.Data());
            ReturnObject<BinAff.Core.Data> ret = crud.Read();

            Assert.AreEqual(ret.MessageList[0].Description, "No data found for Organization");
            Assert.AreEqual(ret.MessageList[1].Description, null);
            Assert.AreEqual(ret.MessageList[2].Description, null);
            Assert.AreEqual(ret.MessageList[3].Description, null);
        }

        [TestMethod(),
        TestCategory("Create"),
        Description("OrgTest02"),
        DeploymentItem("Crystal.Organization.Component.dll")
        ]
        public void OrgTest02()
        {

            ICrud crud = new Crystal.Organization.Component.Server(new Crystal.Organization.Component.Data()
            {
                Name = "ABC",
                Logo = null,
                LicenceNumber = "ABC237B",
                Tan = "ABCD12345E",
                Address = "Bangalore, Old Airport Road",
                City = "Bangalore",
                Pin = 560017,
                ContactName = "Manjunath",
                State = new Crystal.Configuration.Component.State.Data() { Id = 1 },
                EmailList = new List<BinAff.Core.Data>() { 
                     new Crystal.Organization.Component.Email.Data(){Email="abc@yahoo.com"},
                     new Crystal.Organization.Component.Email.Data(){Email="xyp@yahoo.com"},
                }               
            });
            ReturnObject<bool> ret = crud.Save();

            Assert.AreEqual(ret.MessageList[0].Description, "Organization data successfully inserted.");
            Assert.AreEqual(ret.MessageList[1].Description, "Organization Email data successfully inserted.");
            Assert.AreEqual(ret.MessageList[2].Description, "Organization Email data successfully inserted.");
            
        }

        [TestMethod(),
        TestCategory("Delete"),
        Description("OrgTest03"),
        DeploymentItem("Crystal.Organization.Component.dll")
        ]
        public void OrgTest03()
        {
            //int organizationID = 6; //Read from [Organization].[Organization] table
            //ICrud crud = new Crystal.Organization.Component.Server(new Crystal.Organization.Component.Data() { Id = organizationID });
            //ReturnObject<bool> ret = crud.Delete();

            //Assert.AreEqual(ret.MessageList[0].Description, "Organization Email data successfully deleted.");
            //Assert.AreEqual(ret.MessageList[1].Description, "Organization Email data successfully deleted.");
            //Assert.AreEqual(ret.MessageList[2].Description, "Organization data successfully deleted.");

            Crystal.Organization.Component.Server organizationServer = new Crystal.Organization.Component.Server(new Crystal.Organization.Component.Data
            {
                Id = 12
            });
            IRegistrar reg = new Crystal.Organization.Observer.Organization();
            ReturnObject<Boolean> ret = reg.Register(organizationServer);

            BinAff.Core.ICrud organization = organizationServer;
            ReturnObject<Boolean> del = organization.Delete();
        }


        [TestMethod(),
        TestCategory("Delete"),
        Description("OrgTest03"),
        DeploymentItem("Crystal.Organization.Component.dll")
        ]
        
        public void OrgTest03A()
        {           

            Crystal.Organization.Component.Server organizationServer = new Crystal.Organization.Component.Server(new Crystal.Organization.Component.Data
            {
                Id = 13
            });
            IRegistrar reg = new Crystal.Organization.Observer.Organization();
            ReturnObject<Boolean> ret = reg.Register(organizationServer);

            BinAff.Core.ICrud organization = organizationServer;
            ReturnObject<Boolean> del = organization.Delete();
        }


        [TestMethod(),
       TestCategory("Read"),
       Description("OrgTest04"),
       DeploymentItem("Crystal.Organization.Component.dll")
       ]
        public void OrgTest04()
        {
            int organizationID = 7; //Read from [Organization].[Organization] table
            ICrud crud = new Crystal.Organization.Component.Server(new Crystal.Organization.Component.Data() { Id = organizationID });
            ReturnObject<BinAff.Core.Data> ret = crud.Read();           
        }


       [TestMethod(),
       TestCategory("Modify"),
       Description("OrgTest05"),
       DeploymentItem("Crystal.Organization.Component.dll")
       ]
        public void OrgTest05()
        {
            int organizationID = 6; //Read from [Organization].[Organization] table
            ICrud crud = new Crystal.Organization.Component.Server(new Crystal.Organization.Component.Data()
            {
                Id = organizationID,
                Name = "ABC Lodge - Modify",
                Logo = null,
                LicenceNumber = "ABC237B",
                Tan = "ABCD12345E",
                Address = "Bangalore, Old Airport Road",
                City = "Bangalore",
                Pin = 560017,
                ContactName = "Manjunath",
                State = new Crystal.Configuration.Component.State.Data() { Id = 1 },               
            });
            ReturnObject<bool> ret = crud.Save();

            Assert.AreEqual(ret.MessageList[0].Description, "Organization data successfully updated.");
            Assert.AreEqual(ret.MessageList[1].Description, "Organization Email data successfully deleted.");
            Assert.AreEqual(ret.MessageList[2].Description, "Organization Email data successfully deleted.");

        }

         [TestMethod(),
         TestCategory("Modify"),
         Description("OrgTest06"),
         DeploymentItem("Crystal.Organization.Component.dll")
         ]
       public void OrgTest06()
       {
           int organizationID = 6; //Read from [Organization].[Organization] table
           ICrud crud = new Crystal.Organization.Component.Server(new Crystal.Organization.Component.Data()
           {
               Id = organizationID,
               Name = "ABC Lodge - Modify",
               Logo = null,
               LicenceNumber = "ABC237B",
               Tan = "ABCD12345E",
               Address = "Bangalore, Old Airport Road",
               City = "Bangalore",
               Pin = 560017,
               ContactName = "Manjunath",
               State = new Crystal.Configuration.Component.State.Data() { Id = 1 },
               EmailList = new List<BinAff.Core.Data>() { 
                    new Crystal.Organization.Component.Email.Data(){Email="abcMod@yahoo.com"},
                    new Crystal.Organization.Component.Email.Data(){Email="abcMod@yahoo.com"}
               }
           });
           ReturnObject<bool> ret = crud.Save();

           Assert.AreEqual(ret.MessageList[0].Description, "Organization data successfully updated.");
           Assert.AreEqual(ret.MessageList[1].Description, "Organization Email data successfully inserted.");
           Assert.AreEqual(ret.MessageList[2].Description, "Organization Email data successfully inserted.");

       }

         [TestMethod(),
         TestCategory("Modify"),
         Description("OrgTest07"),
         DeploymentItem("Crystal.Organization.Component.dll")
         ]
         public void OrgTest07()
         {
             int organizationID = 6; //Read from [Organization].[Organization] table
             ICrud crud = new Crystal.Organization.Component.Server(new Crystal.Organization.Component.Data()
             {
                 Id = organizationID,
                 Name = "ABC Lodge - Modify",
                 Logo = null,
                 LicenceNumber = "ABC237B",
                 Tan = "ABCD12345E",
                 Address = "Bangalore, Old Airport Road",
                 City = "Bangalore",
                 Pin = 560017,
                 ContactName = "Manjunath",
                 State = new Crystal.Configuration.Component.State.Data() { Id = 1 },
                 EmailList = new List<BinAff.Core.Data>() { 
                    new Crystal.Organization.Component.Email.Data(){Email="xya@yahoo.com"}
                },
                 ContactNumberList = new List<BinAff.Core.Data>() { 
                     new Crystal.Organization.Component.ContactNumber.Data(){ContactNumber = "9876567824"},
                     new Crystal.Organization.Component.ContactNumber.Data(){ContactNumber = "1254789658"},
                 },
                 FaxList = new List<BinAff.Core.Data>() { 
                     new Crystal.Organization.Component.Fax.Data(){Fax="1263546475"}
                 }
             });
             ReturnObject<bool> ret = crud.Save();

             Assert.AreEqual(ret.MessageList[0].Description, "Organization data successfully updated.");
             Assert.AreEqual(ret.MessageList[1].Description, "Organization ContactNumber data successfully inserted.");
             Assert.AreEqual(ret.MessageList[2].Description, "Organization ContactNumber data successfully inserted.");
             Assert.AreEqual(ret.MessageList[4].Description, "Organization Email data successfully inserted.");
             Assert.AreEqual(ret.MessageList[5].Description, "Organization ContactNumber data successfully inserted.");
             Assert.AreEqual(ret.MessageList[6].Description, "Organization Email data successfully deleted.");
             Assert.AreEqual(ret.MessageList[7].Description, "Organization Email data successfully deleted.");

         }

          [TestMethod(),
          TestCategory("Modify"),
          Description("OrgTest08"),
          DeploymentItem("Crystal.Organization.Component.dll")
          ]
         public void OrgTest08()
         {
             int organizationID = 6; //Read from [Organization].[Organization] table
             ICrud crud = new Crystal.Organization.Component.Server(new Crystal.Organization.Component.Data()
             {
                 Id = organizationID,
                 Name = "ABC Lodge - Modify",
                 Logo = null,
                 LicenceNumber = "ABC237B",
                 Tan = "ABCD12345E",
                 Address = "Bangalore, Old Airport Road",
                 City = "Bangalore",
                 Pin = 560017,
                 ContactName = "Manjunath",
                 State = new Crystal.Configuration.Component.State.Data() { Id = 1 }
             });
             ReturnObject<bool> ret = crud.Save();

             Assert.AreEqual(ret.MessageList[0].Description, "Organization data successfully updated.");
             Assert.AreEqual(ret.MessageList[1].Description, "Organization ContactNumber data successfully deleted.");
             Assert.AreEqual(ret.MessageList[2].Description, "Organization ContactNumber data successfully deleted.");
             Assert.AreEqual(ret.MessageList[3].Description, "Organization Email data successfully deleted.");
             Assert.AreEqual(ret.MessageList[4].Description, "Organization ContactNumber data successfully deleted.");
            

         }

          [TestMethod(),
           TestCategory("Create"),
           Description("OrgTest09"),
           DeploymentItem("Crystal.Organization.Component.dll")
           ]
          public void OrgTest09()
          {              
              ICrud crud = new Crystal.Organization.Component.Server(new Crystal.Organization.Component.Data()
              {                 
                  Name = "ABC Lodge - Modify",
                  Logo = null,
                  LicenceNumber = "ABC237B",
                  Tan = "ABCD12345E",
                  Address = "Bangalore, Old Airport Road",
                  City = "Bangalore",
                  Pin = 560017,
                  ContactName = "Manjunath",
                  State = new Crystal.Configuration.Component.State.Data() { Id = 1 },
                  EmailList = new List<BinAff.Core.Data>() { 
                    new Crystal.Organization.Component.Email.Data(){Email="xya@yahoo.com"}
                },
                  ContactNumberList = new List<BinAff.Core.Data>() { 
                     new Crystal.Organization.Component.ContactNumber.Data(){ContactNumber = "9876567824"},
                     new Crystal.Organization.Component.ContactNumber.Data(){ContactNumber = "1254789658"},
                 },
                  FaxList = new List<BinAff.Core.Data>() { 
                     new Crystal.Organization.Component.Fax.Data(){Fax="1263546475"}
                 }
              });
              ReturnObject<bool> ret = crud.Save();

              Assert.AreEqual(ret.MessageList[0].Description, "Organization data successfully inserted.");
              Assert.AreEqual(ret.MessageList[1].Description, "Organization ContactNumber data successfully inserted.");
              Assert.AreEqual(ret.MessageList[2].Description, "Organization ContactNumber data successfully inserted.");
              Assert.AreEqual(ret.MessageList[4].Description, "Organization Email data successfully inserted.");
              Assert.AreEqual(ret.MessageList[5].Description, "Organization ContactNumber data successfully inserted.");           

          }

          [TestMethod(),
           TestCategory("Modify"),
           Description("OrgTest10"),
           DeploymentItem("Crystal.Organization.Component.dll")
          ]
          public void OrgTest10()
          {
              int organizationID = 7; //Read from [Organization].[Organization] table
              ICrud crud = new Crystal.Organization.Component.Server(new Crystal.Organization.Component.Data()
              {
                  Id = organizationID,
                  Name = "ABC Lodge - Modify",
                  Logo = null,
                  LicenceNumber = "ABC237B",
                  Tan = "ABCD12345E",
                  Address = "Bangalore, Old Airport Road",
                  City = "Bangalore",
                  Pin = 560017,
                  ContactName = "Manjunath",
                  State = new Crystal.Configuration.Component.State.Data() { Id = 1 },
                  EmailList = new List<BinAff.Core.Data>() { 
                    new Crystal.Organization.Component.Email.Data(){Email="x@ya@yah.oo.com"}
                },
                  ContactNumberList = new List<BinAff.Core.Data>() { 
                     new Crystal.Organization.Component.ContactNumber.Data(){ContactNumber = "9876567824"},
                     new Crystal.Organization.Component.ContactNumber.Data(){ContactNumber = "1254789658"},
                 },
                  FaxList = new List<BinAff.Core.Data>() { 
                     new Crystal.Organization.Component.Fax.Data(){Fax="1263546475"}
                 }
              });
              ReturnObject<bool> ret = crud.Save();

              Assert.AreEqual(ret.MessageList[0].Description, "Email is not valid.");
              

          }

          [TestMethod(),
           TestCategory("Modify"),
           Description("OrgTest11"),
           DeploymentItem("Crystal.Organization.Component.dll")
          ]
          public void OrgTest11()
          {
              int organizationID = 7; //Read from [Organization].[Organization] table
              ICrud crud = new Crystal.Organization.Component.Server(new Crystal.Organization.Component.Data()
              {
                  Id = organizationID,
                  Name = "ABC Lodge - Modify",
                  Logo = null,
                  LicenceNumber = "ABC237B",
                  Tan = "ABCD12345E",
                  Address = "Bangalore, Old Airport Road",
                  City = "Bangalore",
                  Pin = 560017,
                  ContactName = "Manjunath",
                  State = new Crystal.Configuration.Component.State.Data() { Id = 1 },
                  EmailList = new List<BinAff.Core.Data>() { 
                    new Crystal.Organization.Component.Email.Data(){Email="x@ya@yah.oo.com"}
                },
                  ContactNumberList = new List<BinAff.Core.Data>() { 
                     new Crystal.Organization.Component.ContactNumber.Data(){ContactNumber = "XYZ-9876567824"},
                     new Crystal.Organization.Component.ContactNumber.Data(){ContactNumber = "ABC-12547-89658"},
                 },
                  FaxList = new List<BinAff.Core.Data>() { 
                     new Crystal.Organization.Component.Fax.Data(){Fax="1263546475"}
                 }
              });
              ReturnObject<bool> ret = crud.Save();

              Assert.AreEqual(ret.MessageList[0].Description, "Contact number is not valid.");
              Assert.AreEqual(ret.MessageList[1].Description, "Contact number is not valid.");
              Assert.AreEqual(ret.MessageList[2].Description, "Email is not valid.");
          }

          [TestMethod(),
           TestCategory("Modify"),
           Description("OrgTest12"),
           DeploymentItem("Crystal.Organization.Component.dll")
          ]
          public void OrgTest12()
          {
              int organizationID = 7; //Read from [Organization].[Organization] table
              ICrud crud = new Crystal.Organization.Component.Server(new Crystal.Organization.Component.Data()
              {
                  Id = organizationID,
                  Name = "ABC Lodge - Modify",
                  Logo = null,
                  LicenceNumber = "ABC237B",
                  Tan = "ABCD12345E",
                  Address = "Bangalore, Old Airport Road",
                  City = "Bangalore",
                  Pin = 560017,
                  ContactName = "Manjunath",
                  State = new Crystal.Configuration.Component.State.Data() { Id = 1 },
                  EmailList = new List<BinAff.Core.Data>() { 
                    new Crystal.Organization.Component.Email.Data(){Email="x@ya@yah.oo.com"}
                },
                  ContactNumberList = new List<BinAff.Core.Data>() { 
                     new Crystal.Organization.Component.ContactNumber.Data(){ContactNumber = "XYZ-9876567824"},
                     new Crystal.Organization.Component.ContactNumber.Data(){ContactNumber = "ABC-12547-89658"},
                 },
                  FaxList = new List<BinAff.Core.Data>() { 
                     new Crystal.Organization.Component.Fax.Data(){Fax="FX-1263546475"}
                 }
              });
              ReturnObject<bool> ret = crud.Save();

              Assert.AreEqual(ret.MessageList[0].Description, "Contact number is not valid.");
              Assert.AreEqual(ret.MessageList[1].Description, "Contact number is not valid.");
              Assert.AreEqual(ret.MessageList[2].Description, "Email is not valid.");
              Assert.AreEqual(ret.MessageList[3].Description, "Fax is not valid.");
              
          }

          [TestMethod(),
           TestCategory("Modify"),
           Description("OrgTest13"),
           DeploymentItem("Crystal.Organization.Component.dll")
           ]
          public void OrgTest13()
          {
              int organizationID = 7; //Read from [Organization].[Organization] table
              ICrud crud = new Crystal.Organization.Component.Server(new Crystal.Organization.Component.Data()
              {
                  Id = organizationID,
                  Name = "ABC Lodge - Modify",
                  Logo = null,
                  LicenceNumber = "ABC237B",
                  Tan = "Poi2",
                  Address = "Bangalore, Old Airport Road",
                  City = "Bangalore",
                  Pin = 55555555560017,
                  ContactName = "Manjunath",
                  State = new Crystal.Configuration.Component.State.Data() { Id = 1 },
                  EmailList = new List<BinAff.Core.Data>() { 
                    new Crystal.Organization.Component.Email.Data(){Email="xya@yahoo.com"}
                },
                  ContactNumberList = new List<BinAff.Core.Data>() { 
                     new Crystal.Organization.Component.ContactNumber.Data(){ContactNumber = "9876567824"},
                     new Crystal.Organization.Component.ContactNumber.Data(){ContactNumber = "1254789658"},
                 },
                  FaxList = new List<BinAff.Core.Data>() { 
                     new Crystal.Organization.Component.Fax.Data(){Fax="1263546475"}
                 }
              });
              ReturnObject<bool> ret = crud.Save();

              Assert.AreEqual(ret.MessageList[0].Description, "Pin code is not valid.");
              Assert.AreEqual(ret.MessageList[1].Description, "Tan number is not valid.");              
              
          }
    }
}
