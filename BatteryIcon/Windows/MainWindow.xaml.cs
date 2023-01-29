using System.Windows;

namespace BatteryIcon.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_SelectProcess_Click(object sender, RoutedEventArgs e)
        {
            //SaveSelectedProcess();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //LoadProcesses();
            //SelectSavedProcess();
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
