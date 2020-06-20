using System;
using WeatherMyApp.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherMyApp.ViewModel.Commands
{
    public class SearchCommand : ICommand
    {
        WeatherVM VM { get; set; }
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        public SearchCommand(WeatherVM vm)
        {
            VM = vm;
        }
        public bool CanExecute(object parameter)
        {
            return !String.IsNullOrEmpty(parameter as string);
        }

        public void Execute(object parameter)
        {
            VM.GetCities();
        }
    }
}
