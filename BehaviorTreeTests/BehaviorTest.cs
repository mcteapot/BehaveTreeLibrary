using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BehaviorTreeLibrary;
using NUnit.Framework;

namespace BehaviorTreeTests
{
    class BehaviorTest
    {
        [Test]
        public void Tick_DoesInitialize_Successful()
        {
            MockBehavior t = new MockBehavior();

            Assert.AreEqual(0, t._iInitializeCalled);
            
            t.Tick();

            Assert.AreEqual(1, t._iInitializeCalled);
        }

        [Test]
        public void Tick_UpdateCalled_RreturnSuccess()
        {
            MockBehavior t = new MockBehavior();

            t.Tick();
            Assert.AreEqual(1, t._iUpdateCalled); // Update called

            t._eReturnStatus = Status.BhSuccuss;

            t.Tick();
            Assert.AreEqual(2, t._iUpdateCalled); // Checking if up update is called more than once
        }

        [Test]
        public void Tick_TerminateCalled_ReturnsSucess()
        {
            MockBehavior t = new MockBehavior();

            t.Tick();
            Assert.AreEqual(0, t._iTerminateCalled);

            t._eReturnStatus = Status.BhSuccuss;
            t.Tick();

            Assert.AreEqual(1, t._iTerminateCalled);
        }

    }
}
