using System;
namespace crm2.Model.Interfaces
{
    interface IProjectEvent
    {
        DateTime Date { get; set; }
        string Description { get; set; }
        System.Collections.Generic.List<Company> InvolvedCompanies { get; set; }
        Project ParentProject { get; set; }
    }
}
