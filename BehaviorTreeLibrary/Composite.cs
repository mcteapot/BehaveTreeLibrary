﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BehaviorTreeLibrary
{
    public abstract class Composite : Behavior
    {
        protected List<IBehavior> Children { get; set; }

        protected Composite()
        {
            Children = new List<IBehavior>();
            Initialize = () => { };
            Terminate = status => { };
            Update = () => Status.BhRunning;

        }

        public IBehavior GetChild(int index)
        {
            return Children[index];
        }

        public int ChildCount
        {
            get { return Children.Count; }
        }
    }
}
