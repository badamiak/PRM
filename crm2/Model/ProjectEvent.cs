using crm2.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm2.Model
{
    public class ProjectEvent : IProjectEvent
    {
        public virtual int ID { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string Description { get; set; }
        public virtual List<Company> InvolvedCompanies { get; set; }
        public virtual Project ParentProject { get; set; }
    }
}
