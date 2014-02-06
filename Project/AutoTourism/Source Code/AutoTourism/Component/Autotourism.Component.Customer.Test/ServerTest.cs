using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinAff.Core;
using System.Collections.Generic;
using System;

namespace AutoTourism.Component.Customer.Test
{
    [TestClass]
    public class ServerTest
    {
        /// <summary>
        /// without Reservation
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            ICrud crud = new AutoTourism.Component.Customer.Server(new AutoTourism.Component.Customer.Data()
            {
                Address = "#6 S.K. Apts, Wind Tunnel Road",
                City = "Bangalore1",
                ContactNumberList = new List<Crystal.Customer.Component.ContactNumber.Data>() { 
                 new Crystal.Customer.Component.ContactNumber.Data(){ContactNumber = "08041128956"},
                 new Crystal.Customer.Component.ContactNumber.Data(){ContactNumber = "9875469857"},
                    },
                Email = "biraj.dhekial@3i-infotech.com",
                FirstName = "Biraj",
                IdentityProof = "AIOPD6173B",
                IdentityProofType = new Crystal.Configuration.Component.IdentityProofType.Data() { Id = 1 },
                Initial = new Crystal.Configuration.Component.Initial.Data() { Id = 2 },
                LastName = "Dhekial",
                MiddleName = "Kumar",
                Pin = 560017,
                State = new Crystal.Configuration.Component.State.Data() { Id = 1 }
            });
            ReturnObject<bool> ret = crud.Save();
        }

        /// <summary>
        /// With Reservation
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            ICrud crud = new AutoTourism.Component.Customer.Server(new AutoTourism.Component.Customer.Data()
            {
                Address = "#6 S.K. Apts, Wind Tunnel Road",
                City = "Bangalore",
                ContactNumberList = new List<Crystal.Customer.Component.ContactNumber.Data>() { 
                 new Crystal.Customer.Component.ContactNumber.Data(){ContactNumber = "08041128956"},
                 new Crystal.Customer.Component.ContactNumber.Data(){ContactNumber = "9875469857"},
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
                RoomReserver = new Crystal.Lodge.Component.Room.Reserver.Data
                {
                    Active = new Crystal.Lodge.Component.Room.Reservation.Data
                    {
                        ActivityDate = System.DateTime.Today.AddDays(5),
                        Status = new Crystal.Customer.Component.Action.Status.Data() { Id = 1 },
                        NoOfDays = 5,
                        NoOfPersons = 4,
                        NoOfRooms = 5,
                        Description = "2 single bed, AC2",
                        Advance = 570.75,
                    },
                },

            });
            ReturnObject<bool> ret = crud.Save();
        }

        /// <summary>
        /// With Reservation and Room 
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            ICrud crud = new AutoTourism.Component.Customer.Server(new AutoTourism.Component.Customer.Data()
            {
                Id=30,
                Address = "#6 S.K. Apts, Wind Tunnel Road",
                City = "Assam1",
                ContactNumberList = new List<Crystal.Customer.Component.ContactNumber.Data>() { 
                 new Crystal.Customer.Component.ContactNumber.Data(){ContactNumber = "08041128956"},
                 new Crystal.Customer.Component.ContactNumber.Data(){ContactNumber = "9875469857"},
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
                RoomReserver = new Crystal.Lodge.Component.Room.Reserver.Data
                {
                    Active = new Crystal.Lodge.Component.Room.Reservation.Data
                    {
                        //Id = 43,
                        ActivityDate = System.DateTime.Today.AddDays(5),
                        Status = new Crystal.Customer.Component.Action.Status.Data() { Id = 3 },
                        NoOfDays = 1,
                        NoOfPersons = 1,
                        NoOfRooms = 1,
                        Description = "1 single bed, AC4",
                        Advance = 1000,
                        ProductList = new List<BinAff.Core.Data>() { 
                            new Crystal.Lodge.Component.Room.Data(){ Id = 4 },
                            //new Crystal.Lodge.Component.Room.Data(){Id = 5}
                        }
                    },
                },

            });
            ReturnObject<bool> ret = crud.Save();
        }


        /// <summary>
        /// Read Customer
        /// </summary>
        [TestMethod]
        public void TestMethod4()
        {
            AutoTourism.Component.Customer.Data data = new Data() 
            {
                Id = 44
            };
            ICrud crud = new AutoTourism.Component.Customer.Server(data);
            ReturnObject<BinAff.Core.Data> ret = crud.Read();
            List<BinAff.Core.Data> Archive = data.RoomReserver.ArchiveList;
            List<BinAff.Core.Data> Current = data.RoomReserver.CurrentList;
        }

        /// <summary>
        /// ReadAll Customer
        /// </summary>
        [TestMethod]
        public void TestMethod5()
        {
            ICrud crud = new AutoTourism.Component.Customer.Server(null);
            ReturnObject<List<BinAff.Core.Data>> ret = crud.ReadAll();
            //List<BinAff.Core.Data> Archive = data.RoomReserver.ArchiveList;
            //List<BinAff.Core.Data> Current = data.RoomReserver.CurrentList;
        }


        /// <summary>        
        /// With Reservation and Room 
        /// Check In  included
        /// </summary>
        [TestMethod]
        public void TestMethod6()
        {
            ICrud crud = new AutoTourism.Component.Customer.Server(new AutoTourism.Component.Customer.Data()
            {
                Id = 30,
                Address = "#6 S.K. Apts, Wind Tunnel Road",
                City = "Bangalore",
                ContactNumberList = new List<Crystal.Customer.Component.ContactNumber.Data>() { 
                 new Crystal.Customer.Component.ContactNumber.Data(){ContactNumber = "08041128956"},
                 new Crystal.Customer.Component.ContactNumber.Data(){ContactNumber = "9875469857"},
                    },
                Email = "biraj.dhekial@3i-infotech.com",
                FirstName = "Biraj-CheckIn",
                IdentityProof = "AIOPD6173B",
                IdentityProofType = new Crystal.Configuration.Component.IdentityProofType.Data() { Id = 1 },
                Initial = new Crystal.Configuration.Component.Initial.Data() { Id = 2 },
                LastName = "Dhekial",
                MiddleName = "Kumar",
                Pin = 560017,
                State = new Crystal.Configuration.Component.State.Data() { Id = 1 },
                //RoomReserver = new Crystal.Lodge.Component.Room.Reserver.Data
                //{
                //    Active = new Crystal.Lodge.Component.Room.Reservation.Data
                //    {
                //        ActivityDate = System.DateTime.Today.AddDays(5),
                //        Status = new Crystal.Customer.Component.Action.Status.Data() { Id = 3 },
                //        NoOfDays = 2,
                //        NoOfPersons = 2,
                //        NoOfRooms = 2,
                //        Description = "1 single bed, AC4",
                //        Advance = 500,
                //    },
                //},
                //Checkin = new Crystal.Lodge.Component.Room.CheckInContainer.Data
                //{
                //    Active = new Crystal.Lodge.Component.Room.CheckIn.Data {        
                //        Id = 5,
                //        Advance = 200,
                //        Reservation = new Crystal.Lodge.Component.Room.Reservation.Data() { Id = 48 },
                //        ActivityDate = DateTime.Today,
                //        Date = DateTime.Today,                        
                //        Status = new Crystal.Customer.Component.Action.Status.Data() { Id = 3 }
                //    }
                //}
            });
            ReturnObject<bool> ret = crud.Save();
        }


        /// <summary>               
        /// Test Duplicate
        /// </summary>
        [TestMethod]
        public void TestMethod8()
        {
            ICrud crud = new AutoTourism.Component.Customer.Server(new AutoTourism.Component.Customer.Data()
            {              
                Id=45,
                Address = "#6 S.K. Apts, Wind Tunnel Road",
                City = "Bangalore",
                ContactNumberList = new List<Crystal.Customer.Component.ContactNumber.Data>() { 
                 new Crystal.Customer.Component.ContactNumber.Data(){ContactNumber = "41128956"},
                 new Crystal.Customer.Component.ContactNumber.Data(){ContactNumber = "9740650689"}
                    },
                Email = "b.dk@3i-infotech.com",
                FirstName = "Test",
                IdentityProof = "BIOPD6173B",
                IdentityProofType = new Crystal.Configuration.Component.IdentityProofType.Data() { Id = 1 },
                Initial = new Crystal.Configuration.Component.Initial.Data() { Id = 2 },
                LastName = "Dhekial",
                MiddleName = "Kumar",
                Pin = 560017,
                State = new Crystal.Configuration.Component.State.Data() { Id = 1 },

                RoomReserver = new Crystal.Lodge.Component.Room.Reserver.Data
                {
                    Active = new Crystal.Lodge.Component.Room.Reservation.Data
                    {
                        Id = 59,
                        ActivityDate = System.DateTime.Today.AddDays(3),
                        Status = new Crystal.Customer.Component.Action.Status.Data() { Id = 3 },
                        NoOfDays = 2,
                        NoOfPersons = 2,
                        NoOfRooms = 1,
                        Description = "2 single bed, AC",
                        Advance = 350,
                        ProductList = new List<BinAff.Core.Data>() { 
                                new Crystal.Lodge.Component.Room.Data(){Id = 2},
                                new Crystal.Lodge.Component.Room.Data(){Id = 4}
                            }
                    },
                },
            });
            ReturnObject<bool> ret = crud.Save();
        }
    }
}
