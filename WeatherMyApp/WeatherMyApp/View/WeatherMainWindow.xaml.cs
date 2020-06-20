using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace WeatherMyApp.View
{
    /// <summary>
    /// Логика взаимодействия для WeatherMainWindow.xaml
    /// </summary>
    public partial class WeatherMainWindow : Window
    {
        public WeatherMainWindow()
        {
            InitializeComponent();
        }
        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WeatherResult2 weatherResult = new WeatherResult2();
            weatherResult.Show();
        }

        void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SoundPlayer sound = new SoundPlayer(@"C:\Users\User\source\repos\WeatherMyApp\WeatherMyApp\sound\sound01c.wav");

            //sound.SoundLocation = "sound/sound01c.wav";
            sound.Play();
        }
    }
}
