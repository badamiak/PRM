using crm2.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm2.Database.ModelMappings
{
    public class ProjectMap : ClassMap<Project>
    {
        public ProjectMap()
        {
            Table("awd_projects");
            Id(x => x.ID).GeneratedBy.Sequence("awd_projects_id_seq");
            Map(x => x.Name);
            References(x => x.TargetCompany);
            HasManyToMany(x => x.InvolvedCompanies).Table("companies_to_projects");
            Map(x => x.Description).CustomSqlType("text");
            Map(x => x.StartDate);
            Map(x => x.EndDate);
            Map(x => x.Value);
            References(x => x.State);


        }
    }
}
