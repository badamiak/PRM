using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm2.Model.Interfaces
{
    public interface IProxy<T> where T:class
    {
        T ProxiedItem { get; set; }
    }
}
