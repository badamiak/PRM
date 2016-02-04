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

namespace crm2.Controls.Tabs
{
    /// <summary>
    /// Interaction logic for CompaniesTab.xaml
    /// </summary>
    public partial class CompaniesTab : UserControl, INotifyPropertyChanged
    {
        private Company _selectedCompany;
        public Company SelectedCompany
        {
            get
            {
                return _selectedCompany;
            }
            private set
            {
                this._selectedCompany = value;
                NotifyPropertyChanged("SelectedCompany");
            }
        }
        public static DependencyProperty CompaniesProperty = DependencyProperty.Register("Companies", typeof(List<Company>), typeof(CompaniesTab));
        public List<Company> Companies
        {
            get
            {
                return (List<Company>)GetValue(CompaniesProperty);
            }
            set
            {
                SetValue(CompaniesProperty, value);
                NotifyPropertyChanged("Companies");
            }
        }

        public CompaniesTab()
        {
            InitializeComponent();
        }
        public CompaniesTab(List<Company> companies) : base()
        {
            this.Companies = companies;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void GridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedCompany = companiesGrid.SelectedItem as Company;
        }

        private void AddCompanyClick(object sender, RoutedEventArgs e)
        {
            var newCompany = new Company();
            Companies.Add(newCompany);
            DatabaseAccess.SaveOrUpdate(newCompany.SaveChildren());
            RebindCompanies();
            companiesGrid.SelectedValue = newCompany;
        }

        private void RebindCompanies()
        {
            var companiesTemp = Companies;
            Companies = null;
            Companies = companiesTemp;
        }

        private void DelCompanyClick(object sender, RoutedEventArgs e)
        {
            var companyToDelete = SelectedCompany;
            Companies =Companies.Where(x => x.ID != companyToDelete.ID).ToList();
            DatabaseAccess.Delete(companyToDelete);
            RebindCompanies();
        }
    }
}
