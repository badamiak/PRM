using crm2.Views;
using System.Windows;

namespace crm2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var x = new MainView();
            x.Show();
            this.Close();

        }
    }
}
