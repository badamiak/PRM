using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace crm2.Extensions
{
    public static class ObjectExtensions
    {
        public static T Cast<T>(this object o) where T:class
        {
            if (o is T)
            {
                return o as T;
            }
            else
            {
                throw new InvalidCastException("Object is not an instance of " + typeof(T));
            }
        }

        public static bool IsNull(this object o)
        {
            return o == null;
        }
    }
}
