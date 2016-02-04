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
    /// Interaction logic for ShowCompanyDetailsView.xaml
    /// </summary>
    public partial class ShowCompanyDetailsView : Window, INotifyPropertyChanged
    {
        public ShowCompanyDetailsView()
        {
            InitializeComponent();
        }

        public ShowCompanyDetailsView(Company source) : this()
        {
            SelectedCompany = source;
            this.ShowDialog();
        }
        private Company _selectedCompany;
        public Company SelectedCompany
        {
            get
            {
                return _selectedCompany;
            }
            set
            {
                _selectedCompany = value;
                PropertyChanged.SafeRise(this, HardType.GetName(() => SelectedCompany));
            }
        }
    
public event PropertyChangedEventHandler PropertyChanged;
}
}
