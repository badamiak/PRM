using crm2.Controls;
using crm2.Controls.Tabs;
using crm2.Database;
using crm2.Extensions;
using crm2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace crm2.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window, INotifyPropertyChanged
    {
        public MainView()
        {
            InitializeComponent();
            Topmost = false;
            var dbAccess = DatabaseAccess.GetInstance();
            DatabaseAccess.UpdateSchema();

            var session = DatabaseAccess.GetOpenSession();

        }
        private void ExitMenuItemClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnTabCloseRequest(object sender, EventArgs e)
        {
            tabViewer.RemoveTabItem(sender as crm2.Controls.TabHeader);
        }

        private void MinimizeClick(object sender, RoutedEventArgs e)
        {
            WindowStyle = System.Windows.WindowStyle.SingleBorderWindow;
            WindowState = System.Windows.WindowState.Normal;
            Topmost = false;
        }

        private void MaximizeClick(object sender, RoutedEventArgs e)
        {
            WindowStyle = System.Windows.WindowStyle.None;
            WindowState = System.Windows.WindowState.Maximized;
            Topmost = true;
        }

        private static byte[] GetImageByteArray(string imagesource)
        {
            var stream = new FileStream(imagesource, FileMode.Open);
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, (int)stream.Length);
            return buffer;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void CompaniesButtonClick(object sender, RoutedEventArgs e)
        {
            var header = new TabHeader();
            header.HeaderText = "Companies";
            header.Closing += OnTabCloseRequest;
            var tab = new TabItem()
            {
                Header = header,
            };
            var companies = Database.DatabaseAccess.GetEntitiesOfType<Company>().ToList();
            var companiesTab = new CompaniesTab() { Companies = companies };
            tab.Content = companiesTab;
            tab.InvalidateArrange();
            tabViewer.Items.Add(tab);
            tabViewer.SelectedItem = tab;
            UpdateLayout();
        }

        private void CalendarButtonClick(object sender, RoutedEventArgs e)
        {
            var header = new TabHeader();
            header.HeaderText = "Calendar";
            header.Closing += OnTabCloseRequest;
            var tab = new TabItem()
            {
                Header = header,
            };
            var calendarTab = new CalendarTab();
            tab.Content = calendarTab;
            tab.InvalidateArrange();
            tabViewer.Items.Add(tab);
            tabViewer.SelectedItem = tab;
            UpdateLayout();
        }
        private void PeopleButtonClick(object sender, RoutedEventArgs e)
        {
            var header = new TabHeader();
            header.HeaderText = "People";
            header.Closing += OnTabCloseRequest;
            var tab = new TabItem()
            {
                Header = header,
            };
            var peopleTab = new PeopleTab();
            peopleTab.People = DatabaseAccess.GetEntitiesOfType<Person>() as IList<Person>;
            tab.Content = peopleTab;
            tab.InvalidateArrange();
            tabViewer.Items.Add(tab);
            tabViewer.SelectedItem = tab;
            UpdateLayout();
        }


        private void AboutButtonClick(object sender, RoutedEventArgs e)
        {
            var header = new TabHeader();
            header.HeaderText = "About";
            header.Closing += OnTabCloseRequest;
            var tab = new TabItem()
            {
                Header = header,
            };
            var aboutTab = new InfoTab();
            tab.Content = aboutTab;
            tab.InvalidateArrange();
            tabViewer.Items.Add(tab);
            tabViewer.SelectedItem = tab;
            UpdateLayout();
        }

        private void ProjectsButtonClick(object sender, RoutedEventArgs e)
        {
            var header = new TabHeader();
            header.HeaderText = "Projects";
            header.Closing += OnTabCloseRequest;
            var tab = new TabItem()
            {
                Header = header,
            };
            var projectsTab = new ProjectsTab();
            tab.Content = projectsTab;
            projectsTab.ProjectsToDisplay = DatabaseAccess.GetEntitiesOfType<Project>() as List<Project>;
            tab.InvalidateArrange();
            tabViewer.Items.Add(tab);
            tabViewer.SelectedItem = tab;
            UpdateLayout();
        }
    }
}
