using crm2.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm2.Database.ModelMappings
{
    public class PhoneNumberMap : ClassMap<PhoneNumber>
    {
        public PhoneNumberMap()
        {
            Table("awd_phone_numbers");
            Id(x => x.ID).GeneratedBy.Sequence("awd_phone_numbers_id_seq");
            Map(x => x.Number).Column("number");
        }
    }
}
