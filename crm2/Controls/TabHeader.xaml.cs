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
    /// Interaction logic for TabHeader.xaml
    /// </summary>
    public partial class TabHeader : UserControl, INotifyPropertyChanged
    {
        public TabHeader()
        {
            InitializeComponent();
        }

        private string _headerText = "default header";
        private Visibility _exitButtonVisibility = Visibility.Visible;
        [Browsable(true)]
        public Visibility ExitButtonVisibility 
        { 
            get 
            { 
                return _exitButtonVisibility; 
            } 
            set 
            { 
                _exitButtonVisibility= value; NotifyPropertyChanged("ExitButtonVisibility"); 
            } 
        }
        [Browsable(true)]
        public string HeaderText { get { return _headerText; } set { _headerText = value; NotifyPropertyChanged("HeaderText"); } }
        public event PropertyChangedEventHandler PropertyChanged;
        [Browsable(true)]
        public event EventHandler Closing;


        private void NotifyPropertyChanged(string propertyName)
        {
            if( PropertyChanged != null )
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            Closing.Raise(this, e);
        }
    }
}
