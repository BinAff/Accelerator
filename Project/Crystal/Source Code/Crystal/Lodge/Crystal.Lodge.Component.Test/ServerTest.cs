using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinAff.Core;
using Crystal.Lodge.Component.Building;
using Crystal.Lodge.Component.Room;
using Crystal.Lodge.Component.Room.Tariff;
using Crystal.Reservation.Component;
using System;
using BinAff.Core.Observer;

namespace Crystal.Lodge.Component.Test
{
    [TestClass]
    public class ServerTest
    {       

        [TestMethod(),
        TestCategory("Create - Building Type"),
        Description("LodgeTest01"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest01()
        {

            ICrud crud = new Crystal.Lodge.Component.Building.Type.Server(new Crystal.Lodge.Component.Building.Type.Data()
            {
                Name = "Pony"               
            });
            ReturnObject<bool> ret = crud.Save();
            Assert.AreEqual(ret.MessageList[0].Description, "Building Type data successfully inserted.");           

        }

        [TestMethod(),
        TestCategory("Read - Building Type"),
        Description("LodgeTest02"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest02()
        {

            ICrud crud = new Crystal.Lodge.Component.Building.Type.Server(new Crystal.Lodge.Component.Building.Type.Data()
            {
                Id = 1
            });
            ReturnObject<BinAff.Core.Data> ret = crud.Read();

        }

        [TestMethod(),
        TestCategory("Modify - Building Type"),
        Description("LodgeTest03"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest03()
        {

            ICrud crud = new Crystal.Lodge.Component.Building.Type.Server(new Crystal.Lodge.Component.Building.Type.Data()
            {
                Id = 1,
                Name = "Daffodils"
            });
            ReturnObject<bool> ret = crud.Save();
            Assert.AreEqual(ret.MessageList[0].Description, "Building Type data successfully updated.");
        }

        [TestMethod(),
        TestCategory("Delete - Building Type"),
        Description("LodgeTest04"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest04()
        {

            ICrud crud = new Crystal.Lodge.Component.Building.Type.Server(new Crystal.Lodge.Component.Building.Type.Data()
            {
                Id = 1
            });
            ReturnObject<bool> ret = crud.Delete();
            Assert.AreEqual(ret.MessageList[0].Description, "Building Type data successfully deleted.");
        }

        [TestMethod(),
        TestCategory("ReadAll - Building Type"),
        Description("LodgeTest05"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest05()
        {

            ICrud crud = new Crystal.Lodge.Component.Building.Type.Server(null);
            ReturnObject<List<BinAff.Core.Data>> ret = crud.ReadAll();            
        }

        [TestMethod(),
        TestCategory("Create - Building Status"),
        Description("LodgeTest06"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest06()
        {

            ICrud crud = new Crystal.Lodge.Component.Building.Status.Server(new Crystal.Lodge.Component.Building.Status.Data()
            {
                Name = "Closed"
            });
            ReturnObject<bool> ret = crud.Save();
            Assert.AreEqual(ret.MessageList[0].Description, "Building Status data successfully inserted.");

        }

        [TestMethod(),
        TestCategory("Read - Building Status"),
        Description("LodgeTest07"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest07()
        {

            ICrud crud = new Crystal.Lodge.Component.Building.Status.Server(new Crystal.Lodge.Component.Building.Status.Data()
            {
                Id = 1
            });
            ReturnObject<BinAff.Core.Data> ret = crud.Read();

        }

        [TestMethod(),
        TestCategory("Modify - Building Status"),
        Description("LodgeTest08"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest08()
        {

            ICrud crud = new Crystal.Lodge.Component.Building.Status.Server(new Crystal.Lodge.Component.Building.Status.Data()
            {
                Id = 1,
                Name = "Closed"
            });
            ReturnObject<bool> ret = crud.Save();
            Assert.AreEqual(ret.MessageList[0].Description, "Building Status data successfully updated.");
        }


        [TestMethod(),
        TestCategory("Delete - Building status"),
        Description("LodgeTest09"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest09()
        {
            Crystal.Lodge.Component.Building.Status.Server buildingStatusServer = new Crystal.Lodge.Component.Building.Status.Server(new Crystal.Lodge.Component.Building.Status.Data
            {
                Id = 10002
            });
            IRegistrar reg = new Crystal.Lodge.Observer.BuildingStatus();
            ReturnObject<Boolean> ret = reg.Register(buildingStatusServer);

            BinAff.Core.ICrud buildingStatus = buildingStatusServer;
            ReturnObject<Boolean> del = buildingStatus.Delete();
        }

        [TestMethod(),
        TestCategory("ReadAll - Building Status"),
        Description("LodgeTest10"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest10()
        {

            ICrud crud = new Crystal.Lodge.Component.Building.Status.Server(null);
            ReturnObject<List<BinAff.Core.Data>> ret = crud.ReadAll();
        }

        [TestMethod(),
        TestCategory("Create - Building"),
        Description("LodgeTest11"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest11()
        {

            ICrud crud = new Crystal.Lodge.Component.Building.Server(new Crystal.Lodge.Component.Building.Data()
            {
                Name = "Sai Archad",
                Type = new Building.Type.Data() { Id = 2 },
                Status = new Building.Status.Data() { Id = 2 },
                Organization = new Crystal.Organization.Component.Data() {Id = 12 },
            });
            ReturnObject<bool> ret = crud.Save();
            Assert.AreEqual(ret.MessageList[0].Description, "Building data successfully inserted.");

        }

        [TestMethod(),
        TestCategory("Create - Building"),
        Description("LodgeTest12"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest12()
        {

            ICrud crud = new Crystal.Lodge.Component.Building.Server(new Crystal.Lodge.Component.Building.Data()
            {
                Name = "Sai Archad",
                Type = new Building.Type.Data() { Id = 2 },
                Status = new Building.Status.Data() { Id = 2 },
                Organization = new Crystal.Organization.Component.Data() { Id = 12 },

                FloorList = new List<BinAff.Core.Data>() { 
                    new Crystal.Lodge.Component.Building.Floor.Data(){Name = "1 st Floor" },
                    new Crystal.Lodge.Component.Building.Floor.Data(){Name = "2 nd Floor" }
                },
            });
            ReturnObject<bool> ret = crud.Save();            

        }

        [TestMethod(),
        TestCategory("Create - Building"),
        Description("LodgeTest13"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest13()
        {

            ICrud crud = new Crystal.Lodge.Component.Building.Server(new Crystal.Lodge.Component.Building.Data()
            {
                Name = "Sai Archad",
                Type = new Building.Type.Data() { Id = 2 },
                Status = new Building.Status.Data() { Id = 2 },
                Organization = new Crystal.Organization.Component.Data() { Id = 12 },

                FloorList = new List<BinAff.Core.Data>() { 
                    new Crystal.Lodge.Component.Building.Floor.Data(){Name = "1 st Floor" },
                    new Crystal.Lodge.Component.Building.Floor.Data(){Name = "2 nd Floor" }
                },

                ClosureReasonList = new List<BinAff.Core.Data>() { 
                    new Crystal.Lodge.Component.Building.ClosureReason.Data(){Reason = "renovate"},
                    new Crystal.Lodge.Component.Building.ClosureReason.Data(){Reason = "renovate 1"},
                },
            });
            ReturnObject<bool> ret = crud.Save();

        }

        [TestMethod(),
        TestCategory("Modify - Building"),
        Description("LodgeTest14"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest14()
        {

            ICrud crud = new Crystal.Lodge.Component.Building.Server(new Crystal.Lodge.Component.Building.Data()
            {
                Id = 5,
                Name = "Sai Archad",
                Type = new Building.Type.Data() { Id = 2 },
                Status = new Building.Status.Data() { Id = 2 },
                Organization = new Crystal.Organization.Component.Data() { Id = 12 },

                FloorList = new List<BinAff.Core.Data>() { 
                    new Crystal.Lodge.Component.Building.Floor.Data(){Name = "1 st Floor" },
                    new Crystal.Lodge.Component.Building.Floor.Data(){Name = "2 nd Floor" }
                },

                ClosureReasonList = new List<BinAff.Core.Data>() { 
                    new Crystal.Lodge.Component.Building.ClosureReason.Data(){Reason = "renovate"},
                    new Crystal.Lodge.Component.Building.ClosureReason.Data(){Reason = "renovate 1"},
                },
            });
            ReturnObject<bool> ret = crud.Save();

        }

        [TestMethod(),
        TestCategory("Delete - Building"),
        Description("LodgeTest15"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest15()
        {

            ICrud crud = new Crystal.Lodge.Component.Building.Server(new Crystal.Lodge.Component.Building.Data() { Id = 5 });
            ReturnObject<bool> ret = crud.Delete();
        }

        [TestMethod(),
        TestCategory("Read - Building"),
        Description("LodgeTest16"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest16()
        {

            ICrud crud = new Crystal.Lodge.Component.Building.Server(new Crystal.Lodge.Component.Building.Data() { Id = 6 });
            ReturnObject<BinAff.Core.Data> ret = crud.Read();
        }

        [TestMethod(),
        TestCategory("ReadAll - Building"),
        Description("LodgeTest17"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest17()
        {

            ICrud crud = new Crystal.Lodge.Component.Building.Server(null);
            ReturnObject<List<BinAff.Core.Data>> ret = crud.ReadAll();
        }

        [TestMethod(),
        TestCategory("Modify - Building"),
        Description("LodgeTest18"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest18()
        {

            ICrud crud = new Crystal.Lodge.Component.Building.Server(new Crystal.Lodge.Component.Building.Data()
            {
                Id = 3,
                Name = "Sai Archad",
                Type = new Building.Type.Data() { Id = 2 },
                Status = new Building.Status.Data() { Id = 2 },
                Organization = new Crystal.Organization.Component.Data() { Id = 12 },

                FloorList = new List<BinAff.Core.Data>() {                   
                    new Crystal.Lodge.Component.Building.Floor.Data(){Name = "4 nd Floor" },
                    new Crystal.Lodge.Component.Building.Floor.Data(){Name = "5 nd Floor" }
                },              
            });
            ReturnObject<bool> ret = crud.Save();

        }

        [TestMethod(),
        TestCategory("Modify - BuildingClosure"),
        Description("LodgeTest19"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest19()
        {
            IBuilding building = new Crystal.Lodge.Component.Building.Server(new Crystal.Lodge.Component.Building.Data()
            {
                Id = 6,              
                ClosureReasonList = new List<BinAff.Core.Data>() { 
                    new Crystal.Lodge.Component.Building.ClosureReason.Data(){Reason = "Test Closure"}
                }
            });
            ReturnObject<bool> ret = building.Close();

        }

        [TestMethod(),
        TestCategory("Modify - BuildingOpen"),
        Description("LodgeTest20"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest20()
        {
            IBuilding building = new Crystal.Lodge.Component.Building.Server(new Crystal.Lodge.Component.Building.Data()
            {
                Id = 6
                
            });
            ReturnObject<bool> ret = building.Open();

        }



        [TestMethod(),
        TestCategory("Read - Room Status"),
        Description("LodgeTest21"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest21()
        {
            ICrud crud = new Crystal.Lodge.Component.Room.Status.Server(new Crystal.Lodge.Component.Room.Status.Data()
            {
                Id = 10001
            });
            ReturnObject<BinAff.Core.Data> ret = crud.Read();

        }

        [TestMethod(),
        TestCategory("Create - Room category"),
        Description("LodgeTest22"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest22()
        {
            ICrud crud = new Crystal.Lodge.Component.Room.Category.Server(new Crystal.Lodge.Component.Room.Category.Data()
            {
               Name = "BXYVVVV"
            });
            ReturnObject<bool> ret = crud.Save();

        }

        [TestMethod(),
        TestCategory("ReadAll - Room category"),
        Description("LodgeTest23"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest23()
        {
            ICrud crud = new Crystal.Lodge.Component.Room.Category.Server(null);
            ReturnObject<List<BinAff.Core.Data>> ret = crud.ReadAll();

        }

        [TestMethod(),
        TestCategory("Modify - Room category"),
        Description("LodgeTest24"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest24()
        {
            ICrud crud = new Crystal.Lodge.Component.Room.Category.Server(new Crystal.Lodge.Component.Room.Category.Data() { 
                Id = 1,
                Name = "cat xyz"
            });
            ReturnObject<bool> ret = crud.Save();

        }

        [TestMethod(),
        TestCategory("Delete - Room category"),
        Description("LodgeTest25"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest25()
        {
            ICrud crud = new Crystal.Lodge.Component.Room.Category.Server(new Crystal.Lodge.Component.Room.Category.Data()
            {
                Id = 1
            });
            ReturnObject<bool> ret = crud.Delete();

        }

        [TestMethod(),
        TestCategory("Create - Room Type"),
        Description("LodgeTest26"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest26()
        {
            ICrud crud = new Crystal.Lodge.Component.Room.Type.Server(new Crystal.Lodge.Component.Room.Type.Data()
            {
                Name = "AC double room"
            });
            ReturnObject<bool> ret = crud.Save();

        }

        [TestMethod(),
        TestCategory("Read - Room Type"),
        Description("LodgeTest27"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest27()
        {
            ICrud crud = new Crystal.Lodge.Component.Room.Type.Server(new Crystal.Lodge.Component.Room.Type.Data()
            {
                Id=1
            });
            ReturnObject<BinAff.Core.Data> ret = crud.Read();

        }

        [TestMethod(),
        TestCategory("ReadAll - Room Type"),
        Description("LodgeTest28"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest28()
        {
            ICrud crud = new Crystal.Lodge.Component.Room.Type.Server(null);
            ReturnObject<List<BinAff.Core.Data>> ret = crud.ReadAll();

        }

        [TestMethod(),
        TestCategory("Modify - Room Type"),
        Description("LodgeTest29"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest29()
        {
            ICrud crud = new Crystal.Lodge.Component.Room.Type.Server(new Crystal.Lodge.Component.Room.Type.Data()
            {
                Id = 2,
                Name = "Dormitory"
            });
            ReturnObject<bool> ret = crud.Save();

        }


        [TestMethod(),
        TestCategory("Delete - Room Type"),
        Description("LodgeTest30"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest30()
        {
            ICrud crud = new Crystal.Lodge.Component.Room.Type.Server(new Crystal.Lodge.Component.Room.Type.Data()
            {
                Id = 2                
            });
            ReturnObject<bool> ret = crud.Delete();

        }

        [TestMethod(),
        TestCategory("Create - Room"),
        Description("LodgeTest31"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest31()
        {
            ICrud crud = new Crystal.Lodge.Component.Room.Server(new Crystal.Lodge.Component.Room.Data
            {
                Number = "R-123",
                Name = "Suit",
                Description = "Luxury room",
                Building = new Building.Data() { Id = 6 },
                Floor = new Building.Floor.Data() { Id = 17 },
                Category = new Room.Category.Data() { Id = 2 },
                Type = new Room.Type.Data() { Id = 1 },
                IsAirConditioned = true,
                Status = new Room.Status.Data() { Id = 10001 },

                ImageList = null,
                ClosureReasonList = null
            });
            ReturnObject<bool> ret = crud.Save();

        }

        [TestMethod(),
        TestCategory("Read - Room"),
        Description("LodgeTest32"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest32()
        {
            ICrud crud = new Crystal.Lodge.Component.Room.Server(new Crystal.Lodge.Component.Room.Data
            {
                Id=3
            });
            ReturnObject<BinAff.Core.Data> ret = crud.Read();

        }


        [TestMethod(),
        TestCategory("ReadAll - Room"),
        Description("LodgeTest33"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest33()
        {
            ICrud crud = new Crystal.Lodge.Component.Room.Server(null);
            ReturnObject<List<BinAff.Core.Data>> ret = crud.ReadAll();

        }


        [TestMethod(),
        TestCategory("Modify - Room"),
        Description("LodgeTest34"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest34()
        {
            ICrud crud = new Crystal.Lodge.Component.Room.Server(new Crystal.Lodge.Component.Room.Data
            {
                Id = 1,
                Number = "123",
                Name = "Suit",
                Description = "Luxury room Modified",
                Building = new Building.Data() { Id = 6 },
                Floor = new Building.Floor.Data() { Id = 17 },
                Category = new Room.Category.Data() { Id = 2 },
                Type = new Room.Type.Data() { Id = 1 },
                IsAirConditioned = true,
                Status = new Room.Status.Data() { Id = 10002 }
                     
            });
            ReturnObject<bool> ret = crud.Save();

        }

        [TestMethod(),
        TestCategory("Delete - Room"),
        Description("LodgeTest35"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest35()
        {
            Crystal.Lodge.Component.Room.Server roomServer = new Crystal.Lodge.Component.Room.Server(new Crystal.Lodge.Component.Room.Data
            {
                Id = 4
            });
            IRegistrar reg = new Crystal.Lodge.Observer.Room();
            ReturnObject<Boolean> ret = reg.Register(roomServer);

            BinAff.Core.ICrud room = roomServer;
            ReturnObject<Boolean> del = room.Delete();

            //if (ret.HasError())
            //{
            //    BinAff.Core.ICrud room = roomServer;
            //    ReturnObject<Boolean> del = room.Delete();
            //}
            //else
            //{
            //    //Show message
            //}
            
        }

        [TestMethod(),
        TestCategory("Close - Room"),
        Description("LodgeTest36"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest36()
        {
            IRoom room = new Crystal.Lodge.Component.Room.Server(new Crystal.Lodge.Component.Room.Data
            {
                Id = 2,
                ClosureReasonList = new List<BinAff.Core.Data>() { 
                    new Crystal.Lodge.Component.Room.ClosureReason.Data(){
                        Reason = "close room  temporarily"
                    }
                }
            });
            ReturnObject<bool> ret = room.Close();

        }


        [TestMethod(),
        TestCategory("Open - Room"),
        Description("LodgeTest37"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest37()
        {
            IRoom room = new Crystal.Lodge.Component.Room.Server(new Crystal.Lodge.Component.Room.Data
            {
                Id = 2
            });
            ReturnObject<bool> ret = room.Open();

        }

        [TestMethod(),
        TestCategory("Create - RoomTariff"),
        Description("LodgeTest38"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest38()
        {
            ICrud crud = new Crystal.Lodge.Component.Room.Tariff.Server(new Crystal.Lodge.Component.Room.Tariff.Data
            {
                Rate = 2000,
                StartDate = System.DateTime.Today,
                EndDate = System.DateTime.Today.AddDays(10),
                Product = new Product.Component.Data() { Id = 2 }
            });
            ReturnObject<bool> ret = crud.Save();

        }

        [TestMethod(),
        TestCategory("Read - RoomTariff"),
        Description("LodgeTest39"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest39()
        {
            ICrud crud = new Crystal.Lodge.Component.Room.Tariff.Server(new Crystal.Lodge.Component.Room.Tariff.Data
            {
                Id = 1
            });
            ReturnObject<BinAff.Core.Data> ret = crud.Read();

        }

        [TestMethod(),
        TestCategory("ReadAll - RoomTariff"),
        Description("LodgeTest40"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest40()
        {
            ICrud crud = new Crystal.Lodge.Component.Room.Tariff.Server(null);
            ReturnObject<List<BinAff.Core.Data>> ret = crud.ReadAll();

        }

        [TestMethod(),
        TestCategory("Modify - RoomTariff"),
        Description("LodgeTest41"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest41()
        {
            ICrud crud = new Crystal.Lodge.Component.Room.Tariff.Server(new Crystal.Lodge.Component.Room.Tariff.Data
            {
                Id = 1,
                Rate = 200,
                StartDate = System.DateTime.Today,
                EndDate = System.DateTime.Today.AddDays(2),
                Product = new Product.Component.Data() { Id = 2 }
            });
            ReturnObject<bool> ret = crud.Save();

        }

        [TestMethod(),
        TestCategory("Delete - RoomTariff"),
        Description("LodgeTest42"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest42()
        {
            ICrud crud = new Crystal.Lodge.Component.Room.Tariff.Server(new Crystal.Lodge.Component.Room.Tariff.Data
            {
                Id = 1
            });
            ReturnObject<bool> ret = crud.Delete();

        }

        [TestMethod(),
        TestCategory("Modify - RoomTariff rate"),
        Description("LodgeTest43"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest43()
        {
            IRoomTariff tariff = new Crystal.Lodge.Component.Room.Tariff.Server(null);

            ReturnObject<bool> ret = tariff.UpdateForCategoryAndType(
                new Room.Category.Data() { Id = 2 },
                new Room.Type.Data() { Id = 1 },
                500.75);

        }


        [TestMethod(),
        TestCategory("Create - Room Reservation"),
        Description("LodgeTest44"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest44()
        {

            //ICrud crud = new Crystal.Lodge.Component.Room.Reservation.Server(new Crystal.Lodge.Component.Room.Reservation.Data()
            //{  
            //    ActivityDate = System.DateTime.Today.AddDays(5),
            //    Status = new Reservation.Component.Status.Data(){Id=1},
            //    NoOfDays = 5,
            //    NoOfPersons = 4,
            //    NoOfRooms = 5,
            //    Description = "2 single bed, AC",
            //    Advance = 570.75
            //});
            //ReturnObject<bool> ret = crud.Save();
            //Assert.AreEqual(ret.MessageList[0].Description, "Room reservation data successfully inserted.");

        }

        [TestMethod(),
        TestCategory("Read - Room Reservation"),
        Description("LodgeTest45"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest45()
        {

            ICrud crud = new Crystal.Lodge.Component.Room.Reservation.Server(new Crystal.Lodge.Component.Room.Reservation.Data()
            {
               Id=33
            });
            ReturnObject<BinAff.Core.Data> ret = crud.Read();            

        }

        [TestMethod(),
        TestCategory("ReadAll - Room Reservation"),
        Description("LodgeTest46"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest46()
        {

            ICrud crud = new Crystal.Lodge.Component.Room.Reservation.Server(null);
            ReturnObject<List<BinAff.Core.Data>> ret = crud.ReadAll();

        }

        [TestMethod(),
        TestCategory("Modify - Room Reservation"),
        Description("LodgeTest47"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest47()
        {

            //ICrud crud = new Crystal.Lodge.Component.Room.Reservation.Server(new Crystal.Lodge.Component.Room.Reservation.Data()
            //{
            //    Id = 1,
            //    ActivityDate = System.DateTime.Today.AddDays(1),
            //    Status = new Reservation.Component.Status.Data(){Id=3},
            //    NoOfDays = 3,
            //    NoOfPersons = 3,
            //    NoOfRooms = 3,
            //    Advance = 3.75
            //});
            //ReturnObject<bool> ret = crud.Save();
            //Assert.AreEqual(ret.MessageList[0].Description, "Room reservation data successfully updated.");

        }

        [TestMethod(),
        TestCategory("Delete - Room Reservation"),
        Description("LodgeTest48"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest48()
        {

            ICrud crud = new Crystal.Lodge.Component.Room.Reservation.Server(new Crystal.Lodge.Component.Room.Reservation.Data()
            {
                Id = 18
            });
            ReturnObject<bool> ret = crud.Delete();
            Assert.AreEqual(ret.MessageList[0].Description, "Room reservation data successfully deleted.");

        }

        [TestMethod(),
        TestCategory("Search - Room Reservation"),
        Description("LodgeTest49"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest49()
        {

            //IReservation reservation = new Crystal.Lodge.Component.Room.Reservation.Server(null);
            //ReturnObject<List<Crystal.Reservation.Component.Data>> ret = reservation.Search(new Reservation.Component.Status.Data(){Id=1}, Convert.ToDateTime("03-26-2013"),Convert.ToDateTime("04-28-2013"));           

        }


        [TestMethod(),
        TestCategory("Update - Room Reservation status"),
        Description("LodgeTest50"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest50()
        {

            //IReservation reservation = new Crystal.Lodge.Component.Room.Reservation.Server(new Crystal.Lodge.Component.Room.Reservation.Data() { 
            //    Id = 2
            //});

            //ReturnObject<Boolean> ret = reservation.UpdateStatus(new Reservation.Component.Status.Data() { Id = 3 });

        }

        [TestMethod(),
        TestCategory("Create - Room Reservation"),
        Description("LodgeTest44"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest51()
        {

            //ICrud crud = new Crystal.Lodge.Component.Room.Reservation.Server(new Crystal.Lodge.Component.Room.Reservation.Data()
            //{
            //    //Id = 14,
            //    ActivityDate = System.DateTime.Today.AddDays(5),
            //    Status = new Reservation.Component.Status.Data() { Id = 1 },
            //    NoOfDays = 5,
            //    NoOfPersons = 4,
            //    NoOfRooms = 5,
            //    Description = "5 single bed, AC",
            //    Advance = 570.75,
            //    ProductList = new List<BinAff.Core.Data>() { 
            //        new Crystal.Lodge.Component.Room.Data(){Id = 2},
            //        //new Crystal.Lodge.Component.Room.Data(){Id = 3}
            //    }
            //});
            //ReturnObject<bool> ret = crud.Save();
            ////Assert.AreEqual(ret.MessageList[0].Description, "Room reservation data successfully inserted.");

        }


        [TestMethod(),
        TestCategory("Create - Room CheckIn"),
        Description("LodgeTest52"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest52()
        {

            ICrud crud = new Crystal.Lodge.Component.Room.CheckIn.Server(new Crystal.Lodge.Component.Room.CheckIn.Data()
            {
                Advance = 570.75,
                Reservation = new Room.Reservation.Data() { Id = 48 },
                ActivityDate = DateTime.Today,
                Date = DateTime.Today,
                Status = new Customer.Component.Action.Status.Data() { Id = 3 }
            });
            ReturnObject<bool> ret = crud.Save();
            Assert.AreEqual(ret.MessageList[0].Description, "Room checkin data successfully inserted.");

        }

        [TestMethod(),
        TestCategory("Read - Room CheckIn"),
        Description("LodgeTest53"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest53()
        {

            ICrud crud = new Crystal.Lodge.Component.Room.CheckIn.Server(new Crystal.Lodge.Component.Room.CheckIn.Data()
            {
               Id=2
            });
            ReturnObject<BinAff.Core.Data> ret = crud.Read();
            //Assert.AreEqual(ret.MessageList, null);

        }

        [TestMethod(),
        TestCategory("Modify - Room CheckIn"),
        Description("LodgeTest54"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest54()
        {

            ICrud crud = new Crystal.Lodge.Component.Room.CheckIn.Server(new Crystal.Lodge.Component.Room.CheckIn.Data()
            {
                Id = 1,
                Advance = 0,
                Reservation = new Room.Reservation.Data() { Id = 48 },
                ActivityDate = DateTime.Today,
                Date = DateTime.Today,
                Status = new Customer.Component.Action.Status.Data() { Id = 3 }
            });
            ReturnObject<bool> ret = crud.Save();
            Assert.AreEqual(ret.MessageList[0].Description, "Room checkin data successfully updated.");

        }

        [TestMethod(),
        TestCategory("Delete - Room CheckIn"),
        Description("LodgeTest55"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest55()
        {

            ICrud crud = new Crystal.Lodge.Component.Room.CheckIn.Server(new Crystal.Lodge.Component.Room.CheckIn.Data()
            {
                Id = 1
            });
            ReturnObject<bool> ret = crud.Delete();
            Assert.AreEqual(ret.MessageList[0].Description, "Room checkin data successfully deleted.");

        }


        [TestMethod(),
        TestCategory("Delete - Room Status"),
        Description("LodgeTest56"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest56()
        {
            Crystal.Lodge.Component.Room.Status.Server roomStatusServer = new Crystal.Lodge.Component.Room.Status.Server(new Crystal.Lodge.Component.Room.Status.Data
            {
                Id = 10002
            });
            IRegistrar reg = new Crystal.Lodge.Observer.RoomStatus();
            ReturnObject<Boolean> ret = reg.Register(roomStatusServer);

            BinAff.Core.ICrud roomStatus = roomStatusServer;
            ReturnObject<Boolean> del = roomStatus.Delete();

        }

        [TestMethod(),
        TestCategory("Delete - Building Type"),
        Description("LodgeTest57"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest57()
        {
            Crystal.Lodge.Component.Building.Type.Server buildingTypeServer = new Crystal.Lodge.Component.Building.Type.Server(new Crystal.Lodge.Component.Building.Type.Data
            {
                Id = 3
            });
            IRegistrar reg = new Crystal.Lodge.Observer.BuildingType();
            ReturnObject<Boolean> ret = reg.Register(buildingTypeServer);

            BinAff.Core.ICrud buildingType = buildingTypeServer;
            ReturnObject<Boolean> del = buildingType.Delete();

        }

        [TestMethod(),
        TestCategory("Delete - Room Type"),
        Description("LodgeTest58"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest58()
        {
            Crystal.Lodge.Component.Room.Type.Server roomTypeServer = new Crystal.Lodge.Component.Room.Type.Server(new Crystal.Lodge.Component.Room.Type.Data
            {
                Id = 3
            });
            IRegistrar reg = new Crystal.Lodge.Observer.RoomType();
            ReturnObject<Boolean> ret = reg.Register(roomTypeServer);

            BinAff.Core.ICrud roomType = roomTypeServer;
            ReturnObject<Boolean> del = roomType.Delete();

        }

        [TestMethod(),
        TestCategory("Delete - Building Floor"),
        Description("LodgeTest59"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest59()
        {
            Crystal.Lodge.Component.Building.Floor.Server floorServer = new Crystal.Lodge.Component.Building.Floor.Server(new Crystal.Lodge.Component.Building.Floor.Data
            {
                Id = 30
            });
            IRegistrar reg = new Crystal.Lodge.Observer.BuildingFloor();
            ReturnObject<Boolean> ret = reg.Register(floorServer);

            BinAff.Core.ICrud buildingFloor = floorServer;
            ReturnObject<Boolean> del = buildingFloor.Delete();

        }

        [TestMethod(),
        TestCategory("Delete - Room Category"),
        Description("LodgeTest60"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest60()
        {
            Crystal.Lodge.Component.Room.Category.Server categoryServer = new Crystal.Lodge.Component.Room.Category.Server(new Crystal.Lodge.Component.Room.Category.Data
            {
                Id = 2
            });
            IRegistrar reg = new Crystal.Lodge.Observer.RoomCategory();
            ReturnObject<Boolean> ret = reg.Register(categoryServer);

            BinAff.Core.ICrud roomCategory = categoryServer;
            ReturnObject<Boolean> del = roomCategory.Delete();

        }


        [TestMethod(),
        TestCategory("Delete - Lodge Building"),
        Description("LodgeTest61"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest61()
        {
            Crystal.Lodge.Component.Building.Server buildingServer = new Crystal.Lodge.Component.Building.Server(new Crystal.Lodge.Component.Building.Data
            {
                Id = 8
            });
            IRegistrar reg = new Crystal.Lodge.Observer.Building();
            ReturnObject<Boolean> ret = reg.Register(buildingServer);

            BinAff.Core.ICrud building = buildingServer;
            ReturnObject<Boolean> del = building.Delete();

        }

        [TestMethod(),
        TestCategory("Delete - Lodge Reservation"),
        Description("LodgeTest62"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest62()
        {
            Crystal.Lodge.Component.Room.Reservation.Server reservationServer = new Crystal.Lodge.Component.Room.Reservation.Server(new Crystal.Lodge.Component.Room.Reservation.Data
            {
                Id = 51
            });
            IRegistrar reg = new Crystal.Lodge.Observer.Reservation();
            ReturnObject<Boolean> ret = reg.Register(reservationServer);

            BinAff.Core.ICrud reservation = reservationServer;
            ReturnObject<Boolean> del = reservation.Delete();

        }


        [TestMethod(),
        TestCategory("Create - RoomTariff"),
        Description("LodgeTest63"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest63()
        {
            ICrud crud = new Crystal.Lodge.Component.Room.Tariff.Server(new Crystal.Lodge.Component.Room.Tariff.Data
            {
                Id = 4,
                Rate = 2000,
                StartDate = System.DateTime.Today,
                EndDate = System.DateTime.Today.AddDays(10),
                Product = new Product.Component.Data() { Id = 3 }
            });
            ReturnObject<bool> ret = crud.Save();

        }


        [TestMethod(),
        TestCategory("Insert - Room CheckIn - Update Reservation checkIn status"),
        Description("LodgeTest64"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest64()
        {

            ICrud crud = new Crystal.Lodge.Component.Room.CheckIn.Server(new Crystal.Lodge.Component.Room.CheckIn.Data()
            {
                Advance = 666.75,
                Reservation = new Room.Reservation.Data() { Id = 51 },
                ActivityDate = DateTime.Today,
                Date = DateTime.Today,
                Status = new Customer.Component.Action.Status.Data() { Id = 3 }
            });
            ReturnObject<bool> ret = crud.Save();

        }


        [TestMethod(),
        TestCategory("Create - Building - check duplicate Floor"),
        Description("LodgeTest65"),
        DeploymentItem("Crystal.Lodge.Component.dll")
        ]
        public void LodgeTest65()
        {

            ICrud crud = new Crystal.Lodge.Component.Building.Server(new Crystal.Lodge.Component.Building.Data()
            {
                Name = "Sai Archad Dup",
                Type = new Building.Type.Data() { Id = 2 },
                Status = new Building.Status.Data() { Id = 2 },
                Organization = new Crystal.Organization.Component.Data() { Id = 12 },
                FloorList = new List<BinAff.Core.Data>() { 
                    new Building.Floor.Data(){ Name = "1st Floor" },
                    new Building.Floor.Data(){ Name = "1st Floor" }
                }
            });
            ReturnObject<bool> ret = crud.Save();
        }   
        
    }

}
