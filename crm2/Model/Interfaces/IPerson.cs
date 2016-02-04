using System;
namespace crm2.Model
{
    interface IPerson
    {
        System.Collections.Generic.IList<Address> Addresses { get; set; }
        int ID { get; set; }
        string Name { get; set; }
        string PersonalID { get; set; }
        System.Collections.Generic.IList<PhoneNumber> Phones { get; set; }
        byte[] Picture { get; set; }
        string Surname { get; set; }
        string TaxNumber { get; set; }
    }
}
