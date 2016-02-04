using crm2.Controls.Interfaces;
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
    /// Interaction logic for LabeledTextBlock.xaml
    /// </summary>
    public partial class LabeledTextBlock : UserControl, INotifyPropertyChanged, IEnableEdit
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(string), typeof(LabeledTextBlock));
        public string Header
        {
            get
            {
                return (string)GetValue(HeaderProperty);
            }
            set
            {
                SetValue(HeaderProperty,value);
                NotifyPropertyChanged("Header");
            }
        }

        public static DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(LabeledTextBlock));
        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
                NotifyPropertyChanged("Text");
                DataChanged.RaiseEmpty(this);
            }
        }
        public static DependencyProperty EditModeProperty = DependencyProperty.Register("EditMode", typeof(bool), typeof(LabeledTextBlock));
        public bool EditMode
        {
            get
            {
                return (bool)GetValue(EditModeProperty);
            }
            set
            {
                SetValue(EditModeProperty, value);
                NotifyPropertyChanged("EditMode");
            }
        }
        public LabeledTextBlock()
        {
            InitializeComponent();
        }


        public event EventHandler DataChanged;
    }
}
