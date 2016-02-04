using crm2.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm2.Model.GUIProxy
{
    public class AddressProxy : IAddress, INotifyPropertyChanged, IProxy<Address>
    {
        public string ApartmentNumber
        {
            get
            {
                return ProxiedItem.ApartmentNumber;
            }
            set
            {
                ProxiedItem.ApartmentNumber = value;
                NotifyPropertyChanged("ApartmentNumber");
            }
        }

        public string BuildingNumber
        {
            get
            {
                return ProxiedItem.BuildingNumber;
            }
            set
            {
                ProxiedItem.BuildingNumber = value;
                NotifyPropertyChanged("BuildingNumber");
            }
        }

        public string City
        {
            get
            {
                return ProxiedItem.City;
            }
            set
            {
                ProxiedItem.City = value;
                NotifyPropertyChanged("City");
            }
        }

        public string Commune
        {
            get
            {
                return ProxiedItem.Commune;
            }
            set
            {
                ProxiedItem.Commune = value;
                NotifyPropertyChanged("Commune");
            }
        }

        public string Country
        {
            get
            {
                return ProxiedItem.Country;
            }
            set
            {
                ProxiedItem.Country = value;
                NotifyPropertyChanged("Country");
            }
        }

        public string District
        {
            get
            {
                return ProxiedItem.District;
            }
            set
            {
                ProxiedItem.District = value;
                NotifyPropertyChanged("District");
            }
        }

        public int ID
        {
            get
            {
                return ProxiedItem.ID;
            }
            set
            {
                ProxiedItem.ID = value;
                NotifyPropertyChanged("ID");
            }
        }

        public string PostalCode
        {
            get
            {
                return ProxiedItem.PostalCode;
            }
            set
            {
                ProxiedItem.PostalCode = value;
                NotifyPropertyChanged("PostalCode");
            }
        }

        public string PostOffice
        {
            get
            {
                return ProxiedItem.PostOffice;
            }
            set
            {
                ProxiedItem.PostOffice = value;
                NotifyPropertyChanged("PostOffice");
            }
        }

        public string Province
        {
            get
            {
                return ProxiedItem.Province;
            }
            set
            {
                ProxiedItem.Province = value;
                NotifyPropertyChanged("Province");
            }
        }

        public string Street
        {
            get
            {
                return ProxiedItem.Street;
            }
            set
            {
                ProxiedItem.Street = value;
                NotifyPropertyChanged("Street");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Address ProxiedItem
        {
            get;
            set;
        }
    }
}
