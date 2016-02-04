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
    /// Interaction logic for PeopleTab.xaml
    /// </summary>
    public partial class PeopleTab : UserControl, INotifyPropertyChanged
    {
        public PeopleTab()
        {
            InitializeComponent();

        }
        private Person _selectedPerson;

        public Person SelectedPerson
        {
            get
            {
                return _selectedPerson;
            }
            set
            {
                _selectedPerson = value;
                NotifyPropertyChanged("SelectedPerson");
            }
        }
        public static DependencyProperty PeopleProperty = DependencyProperty.Register("People",typeof(IList<Person>),typeof(PeopleTab));
        public IList<Person> People { 
            get
        {
            return GetValue(PeopleProperty) as IList<Person>;

        }
            set
            {
                SetValue(PeopleProperty, value);
                NotifyPropertyChanged("People");
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        private void GridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = peopleGrid.SelectedItem as Person;
            SelectedPerson = null;
            SelectedPerson = selected;
            
            NotifyPropertyChanged("SelectedPerson");
            selectedContactCard.UpdateLayout();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void AddContactClick(object sender, RoutedEventArgs e)
        {
            var newPerson = new Person();
            People.Add(newPerson);
            DatabaseAccess.SaveOrUpdate(newPerson);
            NotifyPropertyChanged("People");
            peopleGrid.SelectedValue = newPerson;
        }

        private void DelContactClick(object sender, RoutedEventArgs e)
        {
            var personToDelete = SelectedPerson;
            if (personToDelete != null)
            {
                People = People.Where(x => x.ID != personToDelete.ID).ToList();
                DatabaseAccess.Delete(personToDelete);
                NotifyPropertyChanged("People");
            }
        }
    }
}
