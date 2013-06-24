using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinAff.Core;
using System.Collections.Generic;

namespace Crystal.Reservation.Component.Test
{
    [TestClass]
    public class ServerTest
    {

        [TestMethod(),
        TestCategory("Create - Reservation Status"),
        Description("ReservationTest01"),
        DeploymentItem("Crystal.Reservation.Component.dll")
        ]
        public void ReservationTest01()
        {

            ICrud crud = new Crystal.Reservation.Component.Status.Server(new Crystal.Reservation.Component.Status.Data()
            {
                Name = "Close2"
            });
            ReturnObject<bool> ret = crud.Save();
            Assert.AreEqual(ret.MessageList[0].Description, "Reservation Status data successfully inserted.");

        }


        [TestMethod(),
        TestCategory("Read - Reservation Status"),
        Description("ReservationTest02"),
        DeploymentItem("Crystal.Reservation.Component.dll")
        ]
        public void ReservationTest02()
        {

            ICrud crud = new Crystal.Reservation.Component.Status.Server(new Crystal.Reservation.Component.Status.Data()
            {
                Id = 1
            });
            ReturnObject<BinAff.Core.Data> ret = crud.Read();
        }

        [TestMethod(),
        TestCategory("ReadAll - Reservation Status"),
        Description("ReservationTest03"),
        DeploymentItem("Crystal.Reservation.Component.dll")
        ]
        public void ReservationTest03()
        {

            ICrud crud = new Crystal.Reservation.Component.Status.Server(null);
            ReturnObject<List<BinAff.Core.Data>> ret = crud.ReadAll();
        }


        [TestMethod(),
        TestCategory("Modify - Reservation Status"),
        Description("ReservationTest04"),
        DeploymentItem("Crystal.Reservation.Component.dll")
        ]
        public void ReservationTest04()
        {

            ICrud crud = new Crystal.Reservation.Component.Status.Server(new Crystal.Reservation.Component.Status.Data()
            {
                Id = 4,
                Name = "Closed4"
            });
            ReturnObject<bool> ret = crud.Save();
            Assert.AreEqual(ret.MessageList[0].Description, "Reservation Status data successfully updated.");

        }


        [TestMethod(),
        TestCategory("Delete - Reservation Status"),
        Description("ReservationTest05"),
        DeploymentItem("Crystal.Reservation.Component.dll")
        ]
        public void ReservationTest05()
        {

            ICrud crud = new Crystal.Reservation.Component.Status.Server(new Crystal.Reservation.Component.Status.Data()
            {
                Id = 5
            });
            ReturnObject<bool> ret = crud.Delete();
            Assert.AreEqual(ret.MessageList[0].Description, "Reservation Status data successfully deleted.");
            
        }
    }
}
