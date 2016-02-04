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

namespace crm2.Views
{
    /// <summary>
    /// Interaction logic for SelectExistingPersonView.xaml
    /// </summary>
    public partial class SelectExistingPersonView : Window, INotifyPropertyChanged
    {
        public SelectExistingPersonView()
        {
            InitializeComponent();
        }
        public Person SelectedPerson { get; private set; }
        private List<Person> _peopleToDisplay = new List<Person>();
        public List<Person> PeopleToDisplay {
            get
            {
                return this._peopleToDisplay;
            }
            set
            {
                this._peopleToDisplay = value;
                NotifyPropertyChanged("PeopleToDisplay");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            SelectedPerson = null;
            this.Close();
        }

        private void SelectClick(object sender, RoutedEventArgs e)
        {
            SelectedPerson = peopleList.SelectedPerson;
            this.Close();
        }
    }
}
