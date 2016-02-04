using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm2.Extensions
{
    public static class EventHandlerExtensions
    {
        public static void Raise(this EventHandler handler, object sender, EventArgs args)
        {
            if (handler != null)
            {
                handler.Invoke(sender, args);
            }
        }
        public static void RaiseEmpty(this EventHandler handler, object sender)
        {
            handler.Raise(sender,EventArgs.Empty);
        }
        public static void Raise<T>(this EventHandler<T> handler, object sender, T args) where T: EventArgs
        {
            if(handler!=null)
            {
                handler.Invoke(sender, args);
            }
        }
    }
}
