using crm2.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm2.Model
{
    public class ProjectState : crm2.Model.Interfaces.IProjectState
    {
        public const int ClosedId = 0;
        public const int OpenedId = 1;
        public const int InProgressId = 2;
        public const int CanceledId = 3;
        public virtual int ID { get; set; }
        public virtual string Description { get; set; }


    }
}
