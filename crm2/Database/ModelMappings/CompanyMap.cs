using crm2.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm2.Database.ModelMappings
{
    public class CompanyMap : ClassMap<Company>
    {
        public CompanyMap()
        {
            Table("awd_companies");
            Id(x => x.ID);
            Map(x => x.Name);
            Map(x => x.TaxNumber);
            HasManyToMany(x => x.Addresses).Table("addresses_to_companies");
            References(x => x.RepresentedBy);
            References(x => x.ServedBy);
            HasManyToMany(x => x.Employees).Table("employees_to_companies");
            HasManyToMany(x => x.Phones).Table("phones_to_companies");
            Map(x => x.EmailAddress);
            Map(x => x.WebAddress);
        }
    }
}
