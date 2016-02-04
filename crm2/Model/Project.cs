using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm2.Model
{
    public class Project : crm2.Model.Interfaces.IProject, ICloneable
    {
        public Project()
        {
            Description = string.Empty;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(1);
            Value = 0;
        }
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual Company TargetCompany { get; set; }
        public virtual IList<Company> InvolvedCompanies { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual Decimal Value { get; set; }
        public virtual ProjectState State { get; set; }


        public virtual object Clone()
        {
            return new Project()
            {
                Name = this.Name,
                Description = this.Description,
                StartDate = this.StartDate,
                EndDate = this.EndDate,
                Value = this.Value,
                State = this.State
            };
        }
        public virtual void SetValues(Project source)
        {
            this.Name = source.Name;
            this.Description = source.Description;
            this.StartDate = source.StartDate;
            this.EndDate = source.EndDate;
            this.Value = source.Value;
            this.State = source.State;
        }
    }
}
