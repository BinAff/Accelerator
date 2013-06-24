
using Crystal.Customer.Rule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinAff.Core;
using System;

namespace Crystal.Customer.Rule.Test
{
    [TestClass]
    public class ServerTest
    {
        [TestMethod(),
        TestCategory("Create"),
        Description("01: No value passed"),
        DeploymentItem("Crystal.Customer.Rule.dll")
        ]
        public void SaveTest01()
        {
            Data data; ICrud crud; ReturnObject<Boolean> ret;
            data = new Data();
            crud = new Server(data);
            ret = crud.Save();

            Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            Assert.AreEqual(ret.MessageList[0].Description, "Customer Rule data successfully updated.");            

        }

        [TestMethod(),
        TestCategory("Create"),
        Description("02: Valid Data passed"),
        DeploymentItem("Crystal.Customer.Rule.dll")
        ]
        public void SaveTest02()
        {
            Data data; ICrud crud; ReturnObject<Boolean> ret;
            data = new Data() { 
                IsPinNumber = true,
                IsAlternateContactNumber = true,
                IsEmail = true,
                IsIdentityProof = true
            };
            crud = new Server(data);
            ret = crud.Save();

            Assert.AreEqual<Int32>(ret.MessageList.Count, 1);
            Assert.AreEqual(ret.MessageList[0].Description, "Customer Rule data successfully updated.");            

        }

        
    }
}
