using crm2.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using crm2.Extensions;

namespace crm2.Model.GUIProxy
{
    public class PersonProxy : IPerson, INotifyPropertyChanged, IProxy<Person>
    {
        public event EventHandler ProxyChanged;
        public Person ProxiedItem
        {
            get;
            set;
        }

        public IList<Address> Addresses
        {
            get
            {
                return ProxiedItem.Addresses;
            }
            set
            {
                ProxiedItem.Addresses = value;
                NotifyPropertyChanged("Addresses");
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

        public string Name
        {
            get
            {
                return ProxiedItem.Name;
            }
            set
            {
                ProxiedItem.Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string PersonalID
        {
            get
            {
                return ProxiedItem.PersonalID;
            }
            set
            {
                ProxiedItem.PersonalID = value;
                NotifyPropertyChanged("PersonalID");
            }
        }

        public IList<PhoneNumber> Phones
        {
            get
            {
                return ProxiedItem.Phones;
            }
            set
            {
                ProxiedItem.Phones = value;
                NotifyPropertyChanged("Phones");
            }
        }

        public byte[] Picture
        {
            get
            {
                return ProxiedItem.Picture;
            }
            set
            {
                ProxiedItem.Picture = value;
                NotifyPropertyChanged("Addresses");
            }
        }

        public string Surname
        {
            get
            {
                return ProxiedItem.Surname;
            }
            set
            {
                ProxiedItem.Surname = value;
                NotifyPropertyChanged("Surname");
            }
        }

        public string TaxNumber
        {
            get
            {
                return ProxiedItem.TaxNumber;
            }
            set
            {
                ProxiedItem.TaxNumber = value;
                NotifyPropertyChanged("TaxNumber");
            }
        }
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
