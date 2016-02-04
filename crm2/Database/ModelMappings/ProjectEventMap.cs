using crm2.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm2.Database.ModelMappings
{
    public class ProjectEventMap : ClassMap<ProjectEvent>
    {
        public ProjectEventMap()
        {
            Table("awd_projects");
            Id(x => x.ID);
            Map(x => x.Date);
            HasManyToMany(x => x.InvolvedCompanies).Table("companies_to_events");
            References(x => x.ParentProject);
        }
    }
}
