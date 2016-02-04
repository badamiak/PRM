using System;

namespace crm2.Controls.Interfaces
{
    interface IEnableEdit
    {
        bool EditMode
        {
            get;
            set;
        }
        event EventHandler DataChanged;
    }
}
