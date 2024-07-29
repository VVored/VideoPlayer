using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace VideoPlayer.View
{
    /// <summary>
    /// Логика взаимодействия для PlayerPage.xaml
    /// </summary>
    public partial class PlayerPage : Page
    {
        Uri MoviePath;
        private TimeSpan TotalTime;
        public PlayerPage(string MoviePath)
        {
            InitializeComponent();
            this.MoviePath = new Uri(MoviePath, UriKind.Absolute);
            mediaElement.Source = this.MoviePath;
        }

        private void PlayClick(object sender, RoutedEventArgs e)
        {
            PauseButton.Visibility = Visibility.Visible;
            PlayButton.Visibility = Visibility.Collapsed;
            mediaElement.Play();
        }

        private void PauseClick(object sender, RoutedEventArgs e)
        {
            PlayButton.Visibility = Visibility.Visible;
            PauseButton.Visibility = Visibility.Collapsed;
            mediaElement.Pause();
        }

        private void ForwardClick(object sender, RoutedEventArgs e)
        {
            mediaElement.Position = TimeSpan.FromSeconds(mediaElement.Position.TotalSeconds + 5);
            sliderForVideo.Value = mediaElement.Position.TotalSeconds;
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            mediaElement.Position = TimeSpan.FromSeconds(mediaElement.Position.TotalSeconds - 5);
            sliderForVideo.Value = mediaElement.Position.TotalSeconds;
        }

        private void mediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            TotalTime = mediaElement.NaturalDuration.TimeSpan;
            sliderForVideo.Maximum = TotalTime.TotalSeconds;
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (mediaElement.NaturalDuration.TimeSpan.TotalSeconds > 0)
            {
                if (TotalTime.TotalSeconds > 0)
                {
                    sliderForVideo.Value = mediaElement.Position.TotalSeconds;
                }
            }
        }

        private void sliderForVideo_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (TotalTime.TotalSeconds > 0)
            {
                mediaElement.Position = TimeSpan.FromSeconds(sliderForVideo.Value);
            }
            else
            {
                mediaElement.Position = TimeSpan.Zero;
            }
        }
    }
}
