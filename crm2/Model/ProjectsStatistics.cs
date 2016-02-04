using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using crm2.Extensions;
namespace crm2.Model
{
    public class ProjectsStatistics
    {
        public int OpenedProjects { get; set; }
        public int InProgressProjects { get; set; }
        public int ClosedProjects { get; set; }
        public int CanceledProjects { get; set; }

        public ProjectsStatistics(Company sourceCompany)
        {
            if(sourceCompany.IsNull())
            {
                throw new ArgumentNullException();
            }
            List<Project> companyProjects = Database.DatabaseAccess.GetEntitiesOfType<Project>()
                .Where(x => x.InvolvedCompanies.Contains(sourceCompany) || (!x.TargetCompany.IsNull() && x.TargetCompany.ID == sourceCompany.ID)).ToList();
            
            OpenedProjects = companyProjects.Where(x => x.State.ID == ProjectState.OpenedId).Count();
            InProgressProjects = companyProjects.Where(x => x.State.ID == ProjectState.InProgressId).Count();
            ClosedProjects = companyProjects.Where(x => x.State.ID == ProjectState.ClosedId).Count();
            CanceledProjects = companyProjects.Where(x => x.State.ID == ProjectState.CanceledId).Count();
        }
    }
}
