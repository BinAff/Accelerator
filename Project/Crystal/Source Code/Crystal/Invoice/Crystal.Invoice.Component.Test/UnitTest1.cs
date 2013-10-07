using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinAff.Core;
using System.Collections.Generic;
using BinAff.Core.Observer;

namespace Crystal.Invoice.Component.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod(),
        TestCategory("Insert - Payment Type"),
        DeploymentItem("Crystal.Invoice.Component.dll")
        ]
        public void TestMethod1()
        {
            ICrud crud = new Payment.Type.Server(new Payment.Type.Data()
            {
                Name = "Debit card"
            });
            ReturnObject<Boolean> ret = crud.Save();
            //Assert.AreEqual(ret.MessageList[0].Description, "Payment Type data successfully inserted.");           
        }

        [TestMethod(),
        TestCategory("Read - Payment Type"),
        DeploymentItem("Crystal.Invoice.Component.dll")
        ]
        public void TestMethod2()
        {

            ICrud crud = new Payment.Type.Server(new Payment.Type.Data()
            {
                Id = 1
            });
            ReturnObject<BinAff.Core.Data> ret = crud.Read();

        }

        [TestMethod(),
        TestCategory("ReadAll - Payment Type"),
        DeploymentItem("Crystal.Invoice.Component.dll")
        ]
        public void TestMethod3()
        {

            ICrud crud = new Payment.Type.Server(null);
            ReturnObject<List<BinAff.Core.Data>> ret = crud.ReadAll();
        }

        [TestMethod(),
        TestCategory("Modify - Payment Type"),
        DeploymentItem("Crystal.Invoice.Component.dll")
        ]
        public void TestMethod4()
        {

            ICrud crud = new Payment.Type.Server(new Payment.Type.Data()
            {
                Id = 1,
                Name = "Sbi Debit Card"
            });
            ReturnObject<bool> ret = crud.Save();
            Assert.AreEqual(ret.MessageList[0].Description, "Payment Type data successfully updated.");
        }

        [TestMethod(),
        TestCategory("Delete - Payment Type"),
        DeploymentItem("Crystal.Invoice.Component.dll")
        ]
        public void TestMethod5()
        {

            Crystal.Invoice.Component.Payment.Type.Server paymentTypeServer = new Payment.Type.Server(new Payment.Type.Data()
            {
                Id = 2
            });
            IRegistrar reg = new Crystal.Invoice.Observer.PaymentType();
            ReturnObject<Boolean> ret = reg.Register(paymentTypeServer);

            BinAff.Core.ICrud paymentType = paymentTypeServer;
            ReturnObject<Boolean> del = paymentType.Delete();
        }


        [TestMethod(),
        TestCategory("Insert - Payment"),
        DeploymentItem("Crystal.Invoice.Component.dll")
        ]
        public void TestMethod6()
        {
            ICrud crud = new Payment.Server(new Payment.Data()
            {
                CardNumber = "2356",
                Remark = "test Payment",
                
                Type = new Payment.Type.Data(){
                    Id = 2
                }
            });
            ReturnObject<Boolean> ret = crud.Save();
            Assert.AreEqual(ret.MessageList[0].Description, "Payment data successfully inserted.");           
        }

        [TestMethod(),
        TestCategory("Read - Payment"),
        DeploymentItem("Crystal.Invoice.Component.dll")
        ]
        public void TestMethod7()
        {

            ICrud crud = new Payment.Server(new Payment.Data()
            {
                Id = 1
            });
            ReturnObject<BinAff.Core.Data> ret = crud.Read();

        }

        [TestMethod(),
        TestCategory("ReadAll - Payment"),
        DeploymentItem("Crystal.Invoice.Component.dll")
        ]
        public void TestMethod8()
        {

            ICrud crud = new Payment.Server(null);
            ReturnObject<List<BinAff.Core.Data>> ret = crud.ReadAll();
        }

        [TestMethod(),
        TestCategory("Modify - Payment"),
        DeploymentItem("Crystal.Invoice.Component.dll")
        ]
        public void TestMethod9()
        {

            ICrud crud = new Payment.Server(new Payment.Data()
            {
                Id = 1,                
                CardNumber = "2356",
                Remark = "test Payment update",
                
                Type = new Payment.Type.Data(){
                    Id = 2
                }
            });
            ReturnObject<bool> ret = crud.Save();
            Assert.AreEqual(ret.MessageList[0].Description, "Payment data successfully updated.");
        }


        [TestMethod(),
        TestCategory("Insert - Taxation"),
        DeploymentItem("Crystal.Invoice.Component.dll")
        ]
        public void TestMethod10()
        {
            ICrud crud = new Taxation.Server(new Taxation.Data()
            {
                Name = "Service Tax",
                Amount = 12.5,
                isPercentage = true
            });
            ReturnObject<Boolean> ret = crud.Save();
            //Assert.AreEqual(ret.MessageList[0].Description, "Payment Type data successfully inserted.");           
        }

        [TestMethod(),
        TestCategory("Read - Taxation"),
        DeploymentItem("Crystal.Invoice.Component.dll")
        ]
        public void TestMethod11()
        {

            ICrud crud = new Taxation.Server(new Taxation.Data()
            {
                Id = 1
            });
            ReturnObject<BinAff.Core.Data> ret = crud.Read();

        }

        [TestMethod(),
        TestCategory("ReadAll - Taxation"),
        DeploymentItem("Crystal.Invoice.Component.dll")
        ]
        public void TestMethod12()
        {

            ICrud crud = new Taxation.Server(null);
            ReturnObject<List<BinAff.Core.Data>> ret = crud.ReadAll();
        }

        [TestMethod(),
        TestCategory("Modify - Payment Type"),
        DeploymentItem("Crystal.Invoice.Component.dll")
        ]
        public void TestMethod13()
        {

            ICrud crud = new Taxation.Server(new Taxation.Data()
            {
                Id = 1,
                Name = "Service Tax",
                Amount = 1500,
                isPercentage = false
            });
            ReturnObject<bool> ret = crud.Save();
            //Assert.AreEqual(ret.MessageList[0].Description, "Payment Type data successfully updated.");
        }

        [TestMethod(),
        TestCategory("Insert Duplicate - Taxation"),
        DeploymentItem("Crystal.Invoice.Component.dll")
        ]
        public void TestMethod14()
        {
            ICrud crud = new Taxation.Server(new Taxation.Data()
            {
                Name = "Service Tax",
                Amount = 12.5,
                isPercentage = true
            });
            ReturnObject<Boolean> ret = crud.Save();
            //Assert.AreEqual(ret.MessageList[0].Description, "Payment Type data successfully inserted.");           
        }

        [TestMethod(),
        TestCategory("Insert - Invoice"),
        DeploymentItem("Crystal.Invoice.Component.dll")
        ]
        public void TestMethod15()
        {
            ICrud crud = new Invoice.Component.Server(new Invoice.Component.Data()
            {             
                InvoiceNumber = "12346",
                Seller = new Seller()
                {
                    Name = "SL",
                    Address = "HSR Layout",
                    Liscence = "A123",
                    Email = "bir@dd.com",
                    ContactNumber = "1236547896",
                },
                Buyer = new Buyer()
                {
                    Name = "BY",
                },
                LineItem = new List<BinAff.Core.Data>() { 
                    new LineItem.Data(){
                            Start = DateTime.Today,
                            End = DateTime.Today,
                            Description = "Bx 150",
                            UnitRate = 1572.75,
                            Count = 3
                    },
                    new LineItem.Data(){
                            Start = DateTime.Today,
                            End = DateTime.Today,
                            Description = "Zx 750",
                            UnitRate = 1572.75,
                            Count = 2
                    },
                },
            });
            ReturnObject<Boolean> ret = crud.Save();
            //Assert.AreEqual(ret.MessageList[0].Description, "Payment Type data successfully inserted.");           
        }

        [TestMethod(),
        TestCategory("Read - Invoice"),
        DeploymentItem("Crystal.Invoice.Component.dll")
        ]
        public void TestMethod16()
        {

            ICrud crud = new Invoice.Component.Server(new Invoice.Component.Data()
            {
                Id = 7
            });
            ReturnObject<BinAff.Core.Data> ret = crud.Read();

        }

        [TestMethod(),
        TestCategory("ReadAll - Invoice"),
        DeploymentItem("Crystal.Invoice.Component.dll")
        ]
        public void TestMethod17()
        {

            ICrud crud = new Invoice.Component.Server(null);
            ReturnObject<List<BinAff.Core.Data>> ret = crud.ReadAll();
        }

        [TestMethod(),
        TestCategory("Modify - Invoice"),
        DeploymentItem("Crystal.Invoice.Component.dll")
        ]
        public void TestMethod18()
        {

            ICrud crud = new Invoice.Component.Server(new Invoice.Component.Data()
            {
                Id = 2,
                InvoiceNumber = "123-45",
                Seller = new Seller()
                {
                    Name = "SL",
                    Address = "HSR Layout",
                    Liscence = "A123",
                    Email = "bir@dd.com",
                    ContactNumber = "1236547896",
                },
                Buyer = new Buyer()
                {
                    Name = "BY",
                    Address = "SL P",
                }
            });
            ReturnObject<bool> ret = crud.Save();            
        }


        [TestMethod(),
        TestCategory("Delete - Invoice"),
        DeploymentItem("Crystal.Invoice.Component.dll")
        ]
        public void TestMethod19()
        {

            ICrud crud = new Invoice.Component.Server(new Invoice.Component.Data()
            {
                Id = 7,               
            });
            ReturnObject<bool> ret = crud.Delete();            

            //Crystal.Invoice.Component.Payment.Type.Server paymentTypeServer = new Payment.Type.Server(new Payment.Type.Data()
            //{
            //    Id = 2
            //});
            //IRegistrar reg = new Crystal.Invoice.Observer.PaymentType();
            //ReturnObject<Boolean> ret = reg.Register(paymentTypeServer);

            //BinAff.Core.ICrud paymentType = paymentTypeServer;
            //ReturnObject<Boolean> del = paymentType.Delete();
        }

       [TestMethod(),
       TestCategory("Insert - Invoice Line Item"),
       DeploymentItem("Crystal.Invoice.Component.dll")
       ]
       public void TestMethod20()
        {
            ICrud crud = new Invoice.Component.LineItem.Server(new Invoice.Component.LineItem.Data()
            {
                Start = DateTime.Today,
                End = DateTime.Today,
                Description = "Bx 150",
                UnitRate = 1572.75,
                Count = 3
            });
            ReturnObject<Boolean> ret = crud.Save();
            
        }

       [TestMethod(),
       TestCategory("Read - Invoice Line Item"),
       DeploymentItem("Crystal.Invoice.Component.dll")
       ]
       public void TestMethod21()
        {

            ICrud crud = new Invoice.Component.LineItem.Server(new Invoice.Component.LineItem.Data()
            {
                Id = 1
            });
            ReturnObject<BinAff.Core.Data> ret = crud.Read();

        }

       [TestMethod(),
       TestCategory("ReadAll - Invoice Line Item"),
       DeploymentItem("Crystal.Invoice.Component.dll")
       ]
       public void TestMethod22()
        {
            ICrud crud = new Invoice.Component.LineItem.Server(null);
            ReturnObject<List<BinAff.Core.Data>> ret = crud.ReadAll();
        }

       [TestMethod(),
       TestCategory("Modify - Invoice Line Item"),
       DeploymentItem("Crystal.Invoice.Component.dll")
       ]
       public void TestMethod23()
       {

           ICrud crud = new Invoice.Component.LineItem.Server(new Invoice.Component.LineItem.Data()
           {
               Id = 1,
               Start = DateTime.Today,
               End = DateTime.Today,
               Description = "Bx 150",
               UnitRate = 1572.75,
               Count = 1
           });
           ReturnObject<bool> ret = crud.Save();
       }

       [TestMethod(),
       TestCategory("Delete - Invoice Line Item"),
       DeploymentItem("Crystal.Invoice.Component.dll")
       ]
       public void TestMethod24()
       {

           ICrud crud = new Invoice.Component.LineItem.Server(new Invoice.Component.LineItem.Data()
           {
               Id = 1,
           });
           ReturnObject<bool> ret = crud.Delete();
       }

       [TestMethod(),
       TestCategory("Insert - Invoice"),
       DeploymentItem("Crystal.Invoice.Component.dll")
       ]
       public void TestMethod25()
       {
           ICrud crud = new Invoice.Component.Server(new Invoice.Component.Data()
           {
               Id = 11,
               InvoiceNumber = "A12345",
               Seller = new Seller()
               {
                   Name = "SL",
                   Address = "HSR Layout",
                   Liscence = "A123",
                   Email = "biraj@dd.com",
                   ContactNumber = "1236547896",
               },
               Buyer = new Buyer()
               {
                   Name = "BY",
               },
               LineItem = new List<BinAff.Core.Data>() { 
                    new LineItem.Data(){
                            Start = DateTime.Today,
                            End = DateTime.Today,
                            Description = "Tx 150",
                            UnitRate = 1572.75,
                            Count = 3
                    },
                    new LineItem.Data(){
                            Start = DateTime.Today,
                            End = DateTime.Today,
                            Description = "Dx 750",
                            UnitRate = 1572.75,
                            Count = 2
                    },
                },
               Taxation = new List<BinAff.Core.Data>() { 
                    new Invoice.Component.Taxation.Data(){ Id = 1 },                  
               },
               Payment = new List<BinAff.Core.Data>() { 
                   new Invoice.Component.Payment.Data(){
                        CardNumber = "1234",
                        Remark = "test Payment 2",
                
                        Type = new Payment.Type.Data(){  Id = 2  }
                        }
               }
           });
           ReturnObject<Boolean> ret = crud.Save();
           //Assert.AreEqual(ret.MessageList[0].Description, "Payment Type data successfully inserted.");           
       }
    }
}

                