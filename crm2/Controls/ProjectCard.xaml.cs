using crm2.Model;
using System;
using System.Collections.Generic;
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
using System.ComponentModel;
using crm2.Database;
using crm2.Views;
using crm2.Utils;

namespace crm2.Controls
{
    /// <summary>
    /// Interaction logic for ProjectCard.xaml
    /// </summary>
    public partial class ProjectCard : UserControl, INotifyPropertyChanged
    {
        public static DependencyProperty SourceProjectProperty = DependencyProperty.Register("SourceProject", typeof(Project), typeof(ProjectCard));
        public Project SourceProject
        {
            get
            {
                return GetValue(SourceProjectProperty) as Project;
            }
            set
            {
                SetValue(SourceProjectProperty, value);
                PropertyChanged.SafeRise(this, Utils.HardType.GetName(()=>SourceProject));
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
                PropertyChanged.SafeRise(this, "EditMode");
            }
        }

        private static List<ProjectState> _possibleStates = DatabaseAccess.GetEntitiesOfType<ProjectState>().ToList();
        public List<ProjectState> PossibleStates { get { return _possibleStates; } }

        public ProjectCard()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void TargetCompanyShowDetails(object sender, RoutedEventArgs e)
        {
            if(SourceProject.TargetCompany.IsNull())
            {
                return;
            }
            new ShowCompanyDetailsView(SourceProject.TargetCompany);
        }

        private void InvolvedCompanyShowDetails(object sender, RoutedEventArgs e)
        {
            var selectedItem = InvolvedCompaniesListBox.SelectedItem;
            if(selectedItem.IsNull())
            {
                return;
            }
            var detailWindow = new ShowCompanyDetailsView();
            detailWindow.SelectedCompany = selectedItem as Company;
            detailWindow.ShowDialog();
        }

        private void AddInvolvedComapnyClicked(object sender, RoutedEventArgs e)
        {
            if(SourceProject == null)
            {
                return;
            }
            var toAdd = SelectExistingCompany();
            if (toAdd == null)
            {
                return;
            }
            if (SourceProject.InvolvedCompanies == null)
            {
                SourceProject.InvolvedCompanies = new List<Company>();
            }

            SourceProject.InvolvedCompanies.Add(toAdd);
            DatabaseAccess.SaveOrUpdate(SourceProject);
            RebindSourceProject();
        }

        private Company SelectExistingCompany()
        {
            var selectCompanyDialog = new SelectExistingCompanyView();
            selectCompanyDialog.CompaniesToDisplay = DatabaseAccess.GetEntitiesOfType<Company>().ToList();
            selectCompanyDialog.ShowDialog();
            return selectCompanyDialog.SelectedCompany;
        }

        private void DelInvolvedCompany(object sender, RoutedEventArgs e)
        {
            var toDelete = InvolvedCompaniesListBox.SelectedItem as Company;
            SourceProject.InvolvedCompanies = SourceProject.InvolvedCompanies.Where(x => x.ID != toDelete.ID).ToList();
            DatabaseAccess.SaveOrUpdate(SourceProject);
        }

        private void RebindSourceProject()
        {
            var temp = SourceProject;
            SourceProject = null;
            SourceProject = temp;
        }

        private void SetTargetCompanyClick(object sender, RoutedEventArgs e)
        {
            var toSet = SelectExistingCompany();
            if(toSet.IsNull())
            {
                return;
            }
            SourceProject.TargetCompany = toSet;
            RebindSourceProject();
        }
        Project preEditData;
        private void SaveEditedDataClick(object sender, RoutedEventArgs e)
        {
            DatabaseAccess.SaveOrUpdate(SourceProject);
            EditMode = false;
        }

        private void EditDataClick(object sender, RoutedEventArgs e)
        {
            if(SourceProject.IsNull())
            {
                return;
            }
            preEditData = SourceProject.Clone() as Project;
            EditMode = true;
            RebindSourceProject();
        }

        private void CancelEditionClicked(object sender, RoutedEventArgs e)
        {
            SourceProject.SetValues(preEditData);
            EditMode = false;
            PropertyChanged.SafeRise(this, HardType.GetName(() => SourceProject));
        }
    }
}
