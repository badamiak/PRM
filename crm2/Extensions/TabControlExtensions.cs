using crm2.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace crm2.Extensions
{
    public static class TabControlExtensions
    {
        public static void RemoveTabItem(this TabControl tabControl, TabHeader item)
        {
            tabControl.Items.Remove(item.Parent);
        }
    }
}
