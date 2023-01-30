using P03AplikacjaPogodaClientAPI.Models;
using P03AplikacjaPogodaClientAPI.Tools;
using P03AplikacjaPogodaClientAPI.ViewModels.Commands;
using P05Sklep.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03AplikacjaPogodaClientAPI.ViewModels
{
    public class WeatherVM : ViewModelBase
    {
        AccuWeatherTool accuWeatherTool;
        private string city;

        public string City
        {
            get { return city; }
            set 
            { city = value;
                OnPropertyChange("City");
            }
        }

        public ObservableCollection<CityVM> Cities { get; set; }

        private CityVM selectedCity;

        public CityVM SelectedCity
        {
            get { return selectedCity; }
            set 
            {
                selectedCity = value;
                GetCurrentWeather(selectedCity);
                OnPropertyChange("SelectedCity");
            }
        }

        private CurrentConditionsOfCityVM currentConditionsOfCityVM;

        

        public CurrentConditionsOfCityVM CurrentConditionsOfCityVM
        {
            get { return currentConditionsOfCityVM; }
            set 
            { 
                currentConditionsOfCityVM = value;
                OnPropertyChange("CurrentConditionsOfCityVM");
            }
        }


        public WeatherVM()
        {
            SearchCommand = new SearchCommand(this);
            accuWeatherTool = new AccuWeatherTool();
            Cities = new ObservableCollection<CityVM>();
            //MouseEnterCommand = new DelegateCommand(mouseEnter, null);
            MouseEnterCommand = new DelegateCommand(() =>
            {
                MainWindow.ShowText("mouse enter");
            }, null);

            GoToShopCommand = new DelegateCommand(() =>
            {
                MainWindow.ShowShopWindow();
            }, null);
        }
        public SearchCommand SearchCommand { get; set; }
        public DelegateCommand GoToShopCommand { get; set; }
        public DelegateCommand MouseEnterCommand { get; set; }

        //private void mouseEnter()
        //{
        //    MainWindow.ShowText("mouse enter");
        //}

        public async void FindCities()
        {
            City[]? cities = await accuWeatherTool.GetLocation(city);

            Cities.Clear();
            foreach (var c in cities)
                Cities.Add(
                    new CityVM
                    {
                        CityName = c.LocalizedName,
                        Key = c.Key
                    });
        }

        public async void GetCurrentWeather(CityVM city)
        {
            if(city != null)
            {
                var weather = await accuWeatherTool.GetCurrentCondition(city.Key);

                CurrentConditionsOfCityVM = new CurrentConditionsOfCityVM
                {
                    WeatherText = weather.WeatherText,
                    HasPrecipitation = weather.HasPrecipitation,
                    TemperatureValue = weather.Temperature.Metric.Value
                };
            }
            
        }

    }
}
