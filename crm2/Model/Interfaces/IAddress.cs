using System;
namespace crm2.Model
{
    interface IAddress
    {
        string ApartmentNumber { get; set; }
        string BuildingNumber { get; set; }
        string City { get; set; }
        string Commune { get; set; }
        string Country { get; set; }
        string District { get; set; }
        int ID { get; set; }
        string PostalCode { get; set; }
        string PostOffice { get; set; }
        string Province { get; set; }
        string Street { get; set; }
    }
}
