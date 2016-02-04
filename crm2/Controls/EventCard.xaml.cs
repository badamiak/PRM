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
using Xceed.Wpf.Toolkit;

namespace crm2.Controls
{
    /// <summary>
    /// Interaction logic for EventCard.xaml
    /// </summary>
    public partial class EventCard : UserControl, INotifyPropertyChanged
    {
        public static DependencyProperty SourceEventProperty = DependencyProperty.Register("SourceEvent", typeof(ProjectEvent), typeof(EventCard));

        public ProjectEvent SourceEvent { 
            get
            {
                return GetValue(SourceEventProperty) as ProjectEvent;
            }
            set
            {
                SetValue(SourceEventProperty, value);
                PropertyChanged.SafeRise(this, "SourceEvent");
            }
        }
        public EventCard()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
