using WeatherMyApp.Model;
using WeatherMyApp.ViewModel;
using WeatherMyApp.ViewModel.Commands;
using WeatherMyApp.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMyApp.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {
        private string query;
        private CurrentCondition currentCondition;
        private City selectedCity;
        public ObservableCollection<City> Cities { get; set; } = new ObservableCollection<City>();
        //     public List<City> Cities { get; set; } = new List<City>();
        public SearchCommand SearchCommand { get; set; }

        public WeatherVM()
        {
            SearchCommand = new SearchCommand(this);
        }

        public City SelectedCity
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;
                GetCurrentConditions();
                NotifyPropertyChanged();
            }
        }

        public CurrentCondition CurrentCondition
        {
            get { return currentCondition; }
            set
            {
                currentCondition = value;
                NotifyPropertyChanged();
            }
        }


        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                NotifyPropertyChanged();
            }
        }

        public async void GetCities()
        {
            var cities = await WeatherHelper.GetCities(Query);
            Cities.Clear();
            foreach (var item in cities)
            {
                Cities.Add(item);
            }
            Query = String.Empty;
        }

        public async void GetCurrentConditions()
        {
            CurrentCondition = await WeatherHelper.GetCurrentCondition(SelectedCity.Key);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
