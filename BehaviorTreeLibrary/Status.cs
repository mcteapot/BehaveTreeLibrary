using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BehaviorTreeLibrary
{
    public enum Status
    {
        BhInvalid, // On initialize the will return dude to doing nothing with it
        BhSuccuss,
        BhFailure,
        BhRunning // On unsatisfied loops, might take a few ticks such as in-between way-point, move to node
    }
}
