using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace crm2.Utils
{
    public static class HardType
    {
        public static string GetName(Expression<Func<object>> expression)
        {
            return (expression.Body as MemberExpression).Member.Name;
        }
    }
}
