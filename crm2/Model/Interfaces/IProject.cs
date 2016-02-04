using System;
namespace crm2.Model.Interfaces
{
    interface IProject
    {
        string Description { get; set; }
        DateTime EndDate { get; set; }
        System.Collections.Generic.IList<Company> InvolvedCompanies { get; set; }
        DateTime StartDate { get; set; }
        ProjectState State { get; set; }
        Company TargetCompany { get; set; }
        decimal Value { get; set; }
    }
}
