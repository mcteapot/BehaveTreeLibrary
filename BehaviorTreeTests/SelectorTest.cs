using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BehaviorTreeLibrary;
using NUnit.Framework;

namespace BehaviorTreeTests
{
    class SelectorTest
    {
        [Test]
        public void Tick_PassThorughtToSibling_ReturnTerminated()
        {
            Status[] status = {Status.BhSuccuss, Status.BhFailure,};
            for (int i = 0; i < 2; i++)
            {
                MockSelector selector = new MockSelector(1);
                
                selector.Tick();
                Assert.AreEqual(selector.Status, Status.BhRunning);
                Assert.AreEqual(0, selector[0]._iTerminateCalled);

                selector[0]._eReturnStatus = status[i];
                selector.Tick();
                Assert.AreEqual(selector.Status, status[i]);
                Assert.AreEqual(1, selector[0]._iTerminateCalled);
            }
        }

        [Test]
        public void Tick_SelectorFirstFailureSecondRuns_EndsWithScussess()
        {
            MockSelector selector = new MockSelector(2);

            selector.Tick();
            Assert.AreEqual(selector.Status, Status.BhRunning);
            Assert.AreEqual(0, selector[0]._iTerminateCalled);

            selector[0]._eReturnStatus = Status.BhFailure;
            selector.Tick();
            Assert.AreEqual(selector.Status, Status.BhRunning);
            Assert.AreEqual(1, selector[0]._iTerminateCalled);
            Assert.AreEqual(1, selector[1]._iInitializeCalled);

        }

        [Test]
        public void Tick_SelectorFirstSecondNotInitalized_EndsWithSuccuss()
        {
            MockSelector selector = new MockSelector(2);

            selector.Tick();
            Assert.AreEqual(selector.Status, Status.BhRunning);
            Assert.AreEqual(0, selector[0]._iTerminateCalled);

            selector[0]._eReturnStatus = Status.BhSuccuss;
            selector.Tick();
            Assert.AreEqual(selector.Status, Status.BhSuccuss);
            Assert.AreEqual(1, selector[0]._iTerminateCalled);
            Assert.AreEqual(0, selector[1]._iInitializeCalled);
        }
    }
}
