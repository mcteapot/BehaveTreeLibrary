﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BehaviorTreeLibrary;

namespace BehaviorTreeTests
{
    public class MockSequence : Sequence
    {
        public MockSequence(int size)
            :base()
        {
            for (int i = 0; i < size; i++)
            {
                Children.Add(new MockBehavior());
            }
        }

        public MockBehavior this[int i]
        {
            get { return Children[i] as MockBehavior; }
        }
    }

}
