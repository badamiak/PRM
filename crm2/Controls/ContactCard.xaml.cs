using crm2.Controls.Interfaces;
using crm2.Database;
using crm2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using crm2.Extensions;

namespace crm2.Controls
{
    /// <summary>
    /// Interaction logic for ContactCard.xaml
    /// </summary>
    public partial class ContactCard : UserControl, INotifyPropertyChanged, IEnableEdit
    {
        public ContactCard()
        {
            InitializeComponent();
        }
        private object addressesLock = new object();
        public static DependencyProperty ContactDataProperty = DependencyProperty.Register("ContactData", typeof(Person), typeof(ContactCard));
        public Person ContactData
        {
            get
            {
                return (Person)GetValue(ContactDataProperty);
            }
            set
            {
                SetValue(ContactDataProperty, value);
                NotifyPropertyChanged("ContactData");
                DataChanged.RaiseEmpty(this);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void AddAddressButtonClick(object sender, RoutedEventArgs e)
        {
            var newAddress = new Address();
            ContactData.AddAddress(newAddress);
            RebindContact();
        }

        private void RemoveAddressButtonClick(object sender, RoutedEventArgs e)
        {
            var toDelete = addressesList.SelectedItem as Address;
            ContactData.DelAddress(toDelete);
            RebindContact();
        }
        private void RebindContact()
        {
            var temp = ContactData;
            ContactData = null;
            ContactData = temp;
        }

        private bool _editMode = false;
        public bool EditMode
        {
            get
            {
                return _editMode;
            }
            set
            {
                this._editMode = value;
                NotifyPropertyChanged("EditMode");
            }
        }

        Person preEditData;
        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            EditMode = true;
            preEditData = ContactData.Clone() as Person;
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            EditMode = false;
            DatabaseAccess.SaveOrUpdate(ContactData);
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            EditMode = false;
            ContactData.SetValues(preEditData);
            RebindContact();
        }


        public event EventHandler DataChanged;
    }
}
