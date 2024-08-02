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

        public void RefreshTimeInfo()
        {
            sliderForVideo.Value = mediaElement.Position.TotalSeconds;
            lbTimer.Content = $"{mediaElement.Position.Hours}:{mediaElement.Position.Minutes}:{mediaElement.Position.Seconds} / {TotalTime.Hours}:{TotalTime.Minutes}:{TotalTime.Seconds}";
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
            RefreshTimeInfo();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            mediaElement.Position = TimeSpan.FromSeconds(mediaElement.Position.TotalSeconds - 5);
            RefreshTimeInfo();
        }

        private void mediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            TotalTime = mediaElement.NaturalDuration.TimeSpan;
            sliderForVideo.Maximum = TotalTime.TotalSeconds;
            mediaElement.Volume = sliderForAudio.Value;
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
                    RefreshTimeInfo();
                }
            }
        }

        private void sliderForVideo_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (TotalTime.TotalSeconds > 0)
            {
                mediaElement.Position = TimeSpan.FromSeconds(sliderForVideo.Value);
                lbTimer.Content = $"{mediaElement.Position.Hours}:{mediaElement.Position.Minutes}:{mediaElement.Position.Seconds} / {TotalTime.Hours}:{TotalTime.Minutes}:{TotalTime.Seconds}";
            }
            else
            {
                mediaElement.Position = TimeSpan.Zero;
            }
        }

        private void sliderForAudio_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaElement.Volume = sliderForAudio.Value;
        }

        private void cbSpeedRatio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mediaElement.SpeedRatio = double.Parse(cbSpeedRatio.SelectedValue.ToString().Substring(38));
        }
    }
}
