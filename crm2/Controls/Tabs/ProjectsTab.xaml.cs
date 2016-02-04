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
using crm2.Utils;
using crm2.Database;

namespace crm2.Controls.Tabs
{
    /// <summary>
    /// Interaction logic for ProjectsTab.xaml
    /// </summary>
    public partial class ProjectsTab : UserControl, INotifyPropertyChanged
    {
        public Project _SelectedProject;
        public Project SelectedProject
        {
            get
            {
                return _SelectedProject;
            }
            set
            {
                _SelectedProject = value;
                PropertyChanged.SafeRise(this, HardType.GetName(() => SelectedProject));
            }
        }
        public static DependencyProperty ProjectsToDisplayProperty = DependencyProperty.Register("ProjectsToDisplay", typeof(List<Project>), typeof(ProjectsTab));
        public List<Project> ProjectsToDisplay
        {
            get
            {
                return GetValue(ProjectsToDisplayProperty) as List<Project>;
            }

            set
            {
                SetValue(ProjectsToDisplayProperty, value);
                PropertyChanged.SafeRise(this, HardType.GetName(() => ProjectsToDisplayProperty));
            }
        }
        public ProjectsTab()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void AddProjectClick(object sender, RoutedEventArgs e)
        {
            var newProject = new Project();
            ProjectsToDisplay.Add(newProject);
            DatabaseAccess.SaveOrUpdate(newProject);
            RebindProjectsList();
        }

        private void DelProjectClick(object sender, RoutedEventArgs e)
        {
            var toDelete = SelectedProject;
            ProjectsToDisplay = ProjectsToDisplay.Where(x => x.ID != toDelete.ID).ToList();;
            RebindProjectsList();
            DatabaseAccess.Delete(toDelete);
        }

        private void RebindProjectsList()
        {
            var temp = ProjectsToDisplay;
            ProjectsToDisplay = null;
            ProjectsToDisplay = temp;
        }

        private void RefreshButtonClick(object sender, RoutedEventArgs e)
        {
            ProjectsToDisplay = DatabaseAccess.GetEntitiesOfType<Project>().ToList();
        }

        private void ProjectsGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedProject = ProjectsGrid.SelectedItem as Project;
            PropertyChanged.SafeRise(this, HardType.GetName(() => SelectedProject));
        }
    }
}
