using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace crm2.Model
{
    public class Person : ICloneable, crm2.Model.IPerson
    {
        public Person()
        {
            Name = String.Empty;
            Surname = String.Empty;
            PersonalID = String.Empty;
            TaxNumber = String.Empty;
            Addresses = new List<Address>();
            Phones = new List<PhoneNumber>();
        }
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string PersonalID { get; set; }
        public virtual string TaxNumber { get; set; }
        public virtual IList<Address> Addresses { get; set; }
        public virtual IList<PhoneNumber> Phones { get; set; }
        public virtual byte[] Picture { get; set; }


        public virtual object Clone()
        {
            var clonedPerson = new Person
            {
                ID = this.ID,
                Name = this.Name,
                Surname = this.Surname,
                PersonalID = this.PersonalID,
                TaxNumber = this.TaxNumber,
                Picture = this.Picture,
                Addresses = new List<Address>(),
                Phones = new List<PhoneNumber>()
            };
            foreach (var address in this.Addresses)
            {
                clonedPerson.Addresses.Add((Address)address.Clone());
            }
            foreach (var phone in this.Phones)
            {
                clonedPerson.Phones.Add((PhoneNumber)phone.Clone());
            }

            return clonedPerson;
        }
        public virtual void SetValues(Person sourceValues)
        {
            if (sourceValues == null)
            {
                return;
            }
            ID = sourceValues.ID;
            Name = sourceValues.Name;
            Surname = sourceValues.Surname;
            PersonalID = sourceValues.PersonalID;
            TaxNumber = sourceValues.TaxNumber;
            Picture = sourceValues.Picture;
            Addresses = new List<Address>();
            Phones = new List<PhoneNumber>();
            this.Addresses = sourceValues.Addresses;
            this.Phones = sourceValues.Phones;
        }
        public virtual void AddAddress(Address addressToAdd)
        {
            Addresses.Add(addressToAdd);
            Database.DatabaseAccess.SaveOrUpdate(this);
        }
        public virtual void DelAddress(Address addressToDelete)
        {
            Addresses.Remove(addressToDelete);
            Database.DatabaseAccess.SaveOrUpdate(this);
        }
    }
}
