using crm2.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm2.Database.ModelMappings
{
    public class ProjectStateMap : ClassMap<ProjectState>
    {
        public ProjectStateMap()
        {
            Table("awd_project_states");
            Id(x => x.ID);
            Map(x => x.Description);
        }
    }
}
