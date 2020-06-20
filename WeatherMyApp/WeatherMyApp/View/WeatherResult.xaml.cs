using System;
using WeatherMyApp.ViewModel;
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
using System.Windows.Shapes;

namespace WeatherMyApp.View
{
    /// <summary>
    /// Логика взаимодействия для WeatherResult.xaml
    /// </summary>
    public partial class WeatherResult : Window
    {
        public WeatherResult()
        {
            InitializeComponent();
        }

        //private void InitializeComponent()
        //{
        //    throw new NotImplementedException();
        //}

        public static implicit operator WeatherResult2(WeatherResult v)
        {
            if (v is null)
            {
                throw new ArgumentNullException(nameof(v));
            }

            throw new NotImplementedException();
        }
    }
}
