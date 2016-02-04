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
using System.Windows.Shapes;
using crm2.Extensions;
using crm2.Utils;

namespace crm2.Views
{
    /// <summary>
    /// Interaction logic for SelectExistingCompanyView.xaml
    /// </summary>
    public partial class SelectExistingCompanyView : Window, INotifyPropertyChanged
    {
        public SelectExistingCompanyView()
        {
            InitializeComponent();
        }

        public Company SelectedCompany { get; private set; }
        private List<Company> _companiesToDisplay = new List<Company>();
        public List<Company> CompaniesToDisplay
        {
            get
            {
                return this._companiesToDisplay;
            }
            set
            {
                this._companiesToDisplay = value;
                PropertyChanged.SafeRise(this,HardType.GetName(()=>CompaniesToDisplay));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            SelectedCompany = null;
            this.Close();
        }

        private void SelectClick(object sender, RoutedEventArgs e)
        {
            SelectedCompany = companiesList.SelectedCompany;
            this.Close();
        }
    }
}
