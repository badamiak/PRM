using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm2.Model
{
    public class PhoneNumber : ICloneable, crm2.Model.IPhoneNumber
    {
        public PhoneNumber()
        {
                
        }
        public PhoneNumber(string number)
        {
            this.Number = number;
        }

        public virtual int ID { get; set; }
        public virtual string Number { get; set; }

        public virtual object Clone()
        {
            return new PhoneNumber() { ID = this.ID, Number = this.Number };
        }
    }
}
