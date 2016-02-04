using System;
namespace crm2.Model
{
    interface ICompany
    {
        System.Collections.Generic.IList<Address> Addresses { get; set; }
        System.Collections.Generic.IList<Person> Employees { get; set; }
        int ID { get; set; }
        string Name { get; set; }
        System.Collections.Generic.IList<PhoneNumber> Phones { get; set; }
        Person RepresentedBy { get; set; }
        Person ServedBy { get; set; }
        string TaxNumber { get; set; }
    }
}
