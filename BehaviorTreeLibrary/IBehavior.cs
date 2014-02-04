﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BehaviorTreeLibrary
{
    public interface IBehavior
    {
        Status Tick();
        Status Status { get; set; }
        
        Action Initialize { set; }
        Func<Status> Update { set; }
        Action<Status> Terminate { set; }

    }
}
