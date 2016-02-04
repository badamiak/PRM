using crm2.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using crm2.Extensions;
namespace crm2.Model
{
    public class Company : crm2.Model.ICompany, ICloneable
    {
        object statisticsLock = new object();
        private ProjectsStatistics _statistics;
        public virtual ProjectsStatistics Statistics
        {
            get
            {
                lock (statisticsLock)
                {

                    if (_statistics.IsNull())
                    {
                        _statistics = new ProjectsStatistics(this);
                    }
                }
                return _statistics;
            }
        }
        public Company()
        {
            Name = String.Empty;
            TaxNumber = String.Empty;
            Addresses = new List<Address>();
            RepresentedBy = new Person();
            ServedBy = new Person();
            Employees = new List<Person>();
            Phones = new List<PhoneNumber>();
            WebAddress = String.Empty;
            EmailAddress = String.Empty;

        }
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string TaxNumber { get; set; }
        public virtual IList<Address> Addresses { get; set; }
        public virtual Person RepresentedBy { get; set; }
        public virtual Person ServedBy { get; set; }
        public virtual IList<Person> Employees { get; set; }
        public virtual IList<PhoneNumber> Phones { get; set; }
        public virtual string WebAddress { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual Company SaveChildren()
        {
            foreach (var address in Addresses)
            {
                DatabaseAccess.SaveOrUpdate(address);
            }
            foreach (var employee in Employees)
            {
                DatabaseAccess.SaveOrUpdate(employee);
            }
            foreach (var phone in Phones)
            {
                DatabaseAccess.SaveOrUpdate(phone);
            }
            DatabaseAccess.SaveOrUpdate(RepresentedBy);
            DatabaseAccess.SaveOrUpdate(ServedBy);
            return this;
        }

        /// <summary>
        /// Does not clone containers items, due to further problems how to resolve them (to clone every one of them or just to reassigns the container content)
        /// </summary>
        /// <returns></returns>
        public virtual object Clone()
        {
            var clonedCompany = new Company();
            clonedCompany.Name = this.Name;
            clonedCompany.TaxNumber = this.TaxNumber;
            clonedCompany.RepresentedBy = this.RepresentedBy;
            clonedCompany.ServedBy = this.ServedBy;
            clonedCompany.WebAddress = this.WebAddress;
            clonedCompany.EmailAddress = this.EmailAddress;
            clonedCompany.Addresses = new List<Address>();
            clonedCompany.Employees = new List<Person>();
            clonedCompany.Phones = new List<PhoneNumber>();

            return clonedCompany;
        }

        public virtual void SetValues(Company sourceCompany)
        {
            this.ID = sourceCompany.ID;
            this.Name = sourceCompany.Name;
            this.TaxNumber = sourceCompany.TaxNumber;
            this.RepresentedBy = sourceCompany.RepresentedBy;
            this.ServedBy = sourceCompany.ServedBy;
            this.WebAddress = sourceCompany.WebAddress;
            this.EmailAddress = sourceCompany.EmailAddress;
        }
    }
}
