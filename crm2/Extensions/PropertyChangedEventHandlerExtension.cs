using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm2.Extensions
{
    public static class PropertyChangedEventHandlerExtension
    {
        public static void SafeRise(this PropertyChangedEventHandler handler, object sender ,string propertyName)
        {
            if(handler != null)
            {
                handler.Invoke(sender,new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
