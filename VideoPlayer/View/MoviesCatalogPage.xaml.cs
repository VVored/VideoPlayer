using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для MoviesCatalogPage.xaml
    /// </summary>
    public partial class MoviesCatalogPage : Page
    {
        List<Movie> movies = MainWindow.applicationContext.Movies.ToList();
        public MoviesCatalogPage()
        {
            InitializeComponent();
            lvMovies.ItemsSource = movies;
        }

        private void lvMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedMovie = lvMovies.SelectedItem as Movie;
            if (selectedMovie != null) 
            {
                NavigationService.Navigate(new PersonalMoviePage(selectedMovie));
                
            }
        }
    }
}
