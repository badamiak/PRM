using crm2.Controls.Interfaces;
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
    /// Interaction logic for AddressCard.xaml
    /// </summary>
    public partial class AddressCard : UserControl, INotifyPropertyChanged, IEnableEdit
    {
        public event EventHandler OnAddressDeletion;
        private Visibility _detailsVisible = Visibility.Collapsed;
        public Visibility DetailsVisible
        { 
            get 
            {
                return this._detailsVisible;
            }
            set
            {
                if (value == System.Windows.Visibility.Visible)
                {
                    DetailsButton.Content = "Hide details";
                }else
                {
                    DetailsButton.Content = "Show details";
                }
                this._detailsVisible = value;
                NotifyPropertyChanged("DetailsVisible");
            }
        }

        private Address preEditAddress;
        public static DependencyProperty AddresProperty = DependencyProperty.Register("Addres", typeof(Address), typeof(AddressCard));
        public Address Addres
        {
            get
            {
                return (Address)GetValue(AddresProperty);
            }

            set
            {
                preEditAddress = (Address)value.Clone();
                SetValue(AddresProperty, value);
                NotifyPropertyChanged("Addres");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public AddressCard()
        {
            InitializeComponent();
        }

        private void DeatilsClick(object sender, RoutedEventArgs e)
        {
            if(DetailsVisible == System.Windows.Visibility.Visible)
            {
                DetailsVisible = System.Windows.Visibility.Collapsed;
            }
            else
            {
                DetailsVisible = System.Windows.Visibility.Visible;
            }
        }
        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
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
                if(value)
                {
                    DetailsVisible = System.Windows.Visibility.Visible;
                }
                this._editMode = value;
                NotifyPropertyChanged("EditMode");
            }
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            preEditAddress = (Address)Addres.Clone();
            EditMode = true;
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            Database.DatabaseAccess.SaveOrUpdate(Addres);
            EditMode = false;
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Addres.SetValues(preEditAddress);
            NotifyPropertyChanged("Addres");
            EditMode = false;
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            OnAddressDeletion.Raise(this, EventArgs.Empty);
        }


        public event EventHandler DataChanged;
    }
}
