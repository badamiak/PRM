using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestProject1
{
    class MockEventHandlerException : Exception
    {
        public object sender { get; private set; }
        public EventArgs args {get; private set;}

        public MockEventHandlerException(object sender, EventArgs args)
        {
            this.sender = sender;
            this.args = args;
        }
    }
}
