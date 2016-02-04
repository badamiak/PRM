using crm2.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm2.Database.ModelMappings
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Table("awd_people");
            Id(x => x.ID).Column("id").GeneratedBy.Sequence("awd_people_id_seq");
            Map(x => x.Name).Column("name");
            Map(x => x.Surname).Column("surname");
            Map(x => x.PersonalID).Column("pid");
            Map(x => x.TaxNumber).Column("tax_id");
            HasManyToMany<PhoneNumber>(x => x.Phones).Cascade.AllDeleteOrphan().Table("phones_to_persons");
            HasManyToMany<Address>(x => x.Addresses).Cascade.AllDeleteOrphan().Table("addresses_to_persons");
            Map(x => x.Picture).Column("picture");
        }
    }
}
