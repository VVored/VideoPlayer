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

namespace VideoPlayer.View
{
    /// <summary>
    /// Логика взаимодействия для PlayerPage.xaml
    /// </summary>
    public partial class PlayerPage : Page
    {
        Uri MoviePath;
        public PlayerPage(Uri MoviePath)
        {
            this.MoviePath = MoviePath;
            InitializeComponent();
        }

        private void PlayClick(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
            mediaElement.Play();
        }
    }
}
