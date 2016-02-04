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
using crm2.Database;
using crm2.Controls.Tabs;
using crm2.Views;

namespace crm2.Controls
{
    /// <summary>
    /// Interaction logic for CompanyCard.xaml
    /// </summary>
    public partial class CompanyCard : UserControl, INotifyPropertyChanged, IEnableEdit
    {
        public static DependencyProperty ShowDetailsProperty = DependencyProperty.Register("ShowDetails", typeof(bool), typeof(CompanyCard));
        public bool ShowDetails
        {
            get
            {
                return (bool)GetValue(ShowDetailsProperty);
            }
            set
            {
                SetValue(ShowDetailsProperty, value);
                NotifyPropertyChanged("ShowDetails");

            }
        }
        public static DependencyProperty SourceCompanyProperty = DependencyProperty.Register("SourceCompany", typeof(Company), typeof(CompanyCard));
        public Company SourceCompany
        {
            get
            {
                return (Company)GetValue(SourceCompanyProperty);
            }
            set
            {
                SetValue(SourceCompanyProperty, value);
                NotifyPropertyChanged("SourceCompany");

            }
        }
        public CompanyCard()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
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
                _editMode = value;
                NotifyPropertyChanged("EditMode");
            }
        }

        public event EventHandler DataChanged;

        private Company preEditData;

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (SourceCompany == null)
            {
                return;
            }
            EditMode = true;
            preEditData = SourceCompany.Clone() as Company;
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            EditMode = false;
            DatabaseAccess.SaveOrUpdate(SourceCompany);
            preEditData = null;
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            EditMode = false;
            SourceCompany.SetValues(preEditData);
            RebindCompany();
        }

        private void RebindCompany()
        {
            var tempCompany = SourceCompany;
            SourceCompany = null;
            SourceCompany = tempCompany;
        }
        private Person SelectExistingPerson()
        {
            var selectExistingView = new SelectExistingPersonView();
            selectExistingView.PeopleToDisplay = DatabaseAccess.GetEntitiesOfType<Person>().ToList();
            selectExistingView.ShowDialog();
            return selectExistingView.SelectedPerson;
        }
        private Person CreateNewPerson()
        {
            var newPerson = new Person();
            DatabaseAccess.SaveOrUpdate(newPerson);
            return newPerson;
        }

        private void AddNewRepresentantClick(object sender, RoutedEventArgs e)
        {
            if (SourceCompany == null)
            {
                return;
            }
            SourceCompany.RepresentedBy = CreateNewPerson();
            DatabaseAccess.SaveOrUpdate(SourceCompany);
        }

        private void SelectExistingRepresentantClick(object sender, RoutedEventArgs e)
        {
            if(SourceCompany == null)
            {
                return;
            }
            var selectedPerson = SelectExistingPerson();
            if(selectedPerson == null)
            {
                return;
            }
            else
            {
                SourceCompany.RepresentedBy = selectedPerson;
            }
            DatabaseAccess.SaveOrUpdate(SourceCompany);
            RebindCompany();
        }

        private void AddNewTechnicianClick(object sender, RoutedEventArgs e)
        {
            SourceCompany.ServedBy = CreateNewPerson();
            DatabaseAccess.SaveOrUpdate(SourceCompany);
        }

        private void AddExistingServiceCrewClick(object sender, RoutedEventArgs e)
        {
            if (SourceCompany == null)
            {
                return;
            }
            var selectedPerson = SelectExistingPerson();
            if (selectedPerson == null)
            {
                return;
            }
            else
            {
                SourceCompany.ServedBy = selectedPerson;
            }
            DatabaseAccess.SaveOrUpdate(SourceCompany);
            RebindCompany();

        }

        private void AddNewEmployeeClick(object sender, RoutedEventArgs e)
        {
            if (SourceCompany == null)
            {
                return;
            }
            if (SourceCompany.Employees == null)
            {
                var temp = new List<Person>();
                SourceCompany.Employees = temp;
            }
            var toAdd = CreateNewPerson();
            SourceCompany.Employees.Add(toAdd);
            var tempCompany = SourceCompany;
            SourceCompany = null;
            SourceCompany = tempCompany;
            DatabaseAccess.SaveOrUpdate(SourceCompany);
        }

        private void AddExistingEmployeeClick(object sender, RoutedEventArgs e)
        {
            if (SourceCompany == null)
            {
                return;
            }
            var selectedPerson = SelectExistingPerson();
            if (selectedPerson == null)
            {
                return;
            }
            else
            {
                SourceCompany.Employees.Add(selectedPerson);
            }
            DatabaseAccess.SaveOrUpdate(SourceCompany);
            RebindCompany();
        }

        private void DeleteEmployeeClick(object sender, RoutedEventArgs e)
        {
            SourceCompany.Employees = SourceCompany.Employees.Where(x => x.ID != employeesList.SelectedItem.Cast<Person>().ID).ToList();
            DatabaseAccess.SaveOrUpdate(SourceCompany);
            var temp = SourceCompany;
            SourceCompany = null;
            SourceCompany = temp;
        }

        private void AddAddressClick(object sender, RoutedEventArgs e)
        {
            var newAddress = new Address();
            DatabaseAccess.SaveOrUpdate(newAddress);
            if(SourceCompany.Addresses == null)
            {
                SourceCompany.Addresses = new List<Address>();
            }
            SourceCompany.Addresses.Add(newAddress);
            DatabaseAccess.SaveOrUpdate(SourceCompany);
            RebindCompany();
        }

        private void DeleteAddressClick(object sender, RoutedEventArgs e)
        {
            var toDelete = addressesList.SelectedItem as Address;
            SourceCompany.Addresses = SourceCompany.Addresses.Where(x => x.ID != toDelete.ID).ToList();
            DatabaseAccess.SaveOrUpdate(SourceCompany);
            DatabaseAccess.Delete(toDelete);
            RebindCompany();
        }
    }
}
