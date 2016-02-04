using crm2.Database.ModelMappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm2.Model
{
    public class Address : ICloneable, crm2.Model.IAddress 
    {
        public virtual int ID { get; set; }
        public virtual string Country { get; set; }
        public virtual string Province { get; set; }
        public virtual string District { get; set; }
        public virtual string Commune { get; set; }
        public virtual string City { get; set; }
        public virtual string PostOffice { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Street { get; set; }
        public virtual string BuildingNumber { get; set; }
        public virtual string ApartmentNumber { get; set; }

        public virtual object Clone()
        {
            return new Address()
            {
                Country = this.Country,
                Province = this.Province,
                District = this.District,
                Commune = this.Commune,
                City = this.City,
                PostOffice = this.PostOffice,
                PostalCode = this.PostalCode,
                Street = this.Street,
                BuildingNumber = this.BuildingNumber,
                ApartmentNumber = this.ApartmentNumber
            };
        }

        public virtual void SetValues(Address sourceValues)
        {
            if (sourceValues == null)
            {
                return;
            }
            Country = sourceValues.Country;
            Province = sourceValues.Province;
            District = sourceValues.District;
            Commune = sourceValues.Commune;
            City = sourceValues.City;
            PostOffice = sourceValues.PostOffice;
            PostalCode = sourceValues.PostalCode;
            Street = sourceValues.Street;
            BuildingNumber = sourceValues.BuildingNumber;
            ApartmentNumber = sourceValues.ApartmentNumber;
        }
    }
}
