using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using crm2.Model;

namespace crm2.Database.ModelMappings
{
    public class AddressMap : ClassMap<Address>
    {
        public AddressMap()
        {
            Table("awd_addresses");
            Id(x => x.ID).GeneratedBy.Sequence("awd_addresses_id_seq");
            Map(x => x.Country);
            Map(x => x.Province);
            Map(x => x.District);
            Map(x => x.Commune);
            Map(x => x.City);
            Map(x => x.PostOffice);
            Map(x => x.PostalCode);
            Map(x => x.Street);
            Map(x => x.BuildingNumber).Column("building_number");
            Map(x => x.ApartmentNumber).Column("apartment_number");
        }
    }
}
