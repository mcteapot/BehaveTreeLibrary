using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BehaviorTreeLibrary
{
    public class Sequence : Composite
    {
        private int _sequence;

        public Sequence()
        {
            Update = () =>
                        {
                            for (;;)
                            {
                                Status s = GetChild(_sequence).Tick();
                                if (s != Status.BhSuccuss)
                                {
                                    if (s != Status.BhFailure)
                                    {
                                        _sequence = 0;
                                    }
                                    return s;
                                }
                                if (++_sequence == ChildCount)
                                {
                                    _sequence = 0;
                                    return Status.BhSuccuss;
                                }
                            }
                        };
            Initialize = () =>
                            {
                                _sequence = 0;
                            };

        }
    }
}
