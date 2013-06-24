using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinAff.Core.Observer;
using BinAff.Core;
using System;

namespace Crystal.Configuration.Component.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod(),
        TestCategory("Delete - State"),
        Description("TestMethod1")
        ]
        public void TestMethod1()
        {
            Crystal.Configuration.Component.State.Server stateServer = new State.Server(new State.Data() { 
                Id = 4
            });
            IRegistrar reg = new Crystal.Configuration.Observer.State();
            ReturnObject<Boolean> ret = reg.Register(stateServer);
            BinAff.Core.ICrud state = stateServer;
            ReturnObject<Boolean> del = state.Delete();
        }

        [TestMethod(),
        TestCategory("Delete - Initial"),
        Description("TestMethod2")
        ]
        public void TestMethod2()
        {
            Crystal.Configuration.Component.Initial.Server initialServer = new Initial.Server(new Initial.Data()
            {
                Id = 3
            });
            IRegistrar reg = new Crystal.Configuration.Observer.Initial();
            ReturnObject<Boolean> ret = reg.Register(initialServer);
            BinAff.Core.ICrud initial = initialServer;
            ReturnObject<Boolean> del = initial.Delete();
        }

        [TestMethod(),
        TestCategory("Delete - IdentityProofType"),
        Description("TestMethod3")
        ]
        public void TestMethod3()
        {
            Crystal.Configuration.Component.IdentityProofType.Server identityProofTypeServer = new IdentityProofType.Server(new IdentityProofType.Data()
            {
                Id = 3
            });
            IRegistrar reg = new Crystal.Configuration.Observer.IdentityProofType();
            ReturnObject<Boolean> ret = reg.Register(identityProofTypeServer);
            BinAff.Core.ICrud identityProofType = identityProofTypeServer;
            ReturnObject<Boolean> del = identityProofType.Delete();
        }


        [TestMethod(),
        TestCategory("Insert - Initial"),
        Description("TestMethod4")
        ]
        public void TestMethod4()
        {
            ICrud crud = new Initial.Server(new Initial.Data() { 
                Name = "DR"
            });            
            ReturnObject<Boolean> insert = crud.Save();
        }

        [TestMethod(),
        TestCategory("Insert - IdentityProofType"),
        Description("TestMethod5")
        ]
        public void TestMethod5()
        {
            ICrud crud = new IdentityProofType.Server(new IdentityProofType.Data()
            {
                Name = "Voter ID"
            });
            ReturnObject<Boolean> insert = crud.Save();
        }

        [TestMethod(),
        TestCategory("Insert - State"),
        Description("TestMethod6")
        ]
        public void TestMethod6()
        {
            ICrud crud = new State.Server(new State.Data()
            {
                Name = "Assam"
            });
            ReturnObject<Boolean> insert = crud.Save();
        }
    }
}
