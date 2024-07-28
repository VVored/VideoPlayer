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
using VideoPlayer.Model;

namespace VideoPlayer.View
{
    /// <summary>
    /// Логика взаимодействия для PersonalMoviePage.xaml
    /// </summary>
    public partial class PersonalMoviePage : Page
    {
        Movie movie;
        public PersonalMoviePage(Movie movie)
        {
            InitializeComponent();
            this.movie = movie;
            DataContext = movie;
        }

        private void GoForWatching(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PlayerPage(movie.FullVideoPath));
        }
    }
}
