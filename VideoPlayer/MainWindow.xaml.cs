using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VideoPlayer.Model;

namespace VideoPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ApplicationContext applicationContext = new ApplicationContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenMoviesCatalog(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new View.MoviesCatalogPage());
        }
    }
}