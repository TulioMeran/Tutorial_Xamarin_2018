using App1.Models;
using App1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class AnimesViewModel: BaseViewModel
    {
        #region Services

        public ApiService apiService; 

        #endregion

        #region Atributos

        private ObservableCollection<Anime> animes;

        #endregion

        #region Propiedades

        public ObservableCollection<Anime> Animes
        {

            get { return animes; }

            set { SetValue(ref animes, value); }
        } 

        #endregion

        public AnimesViewModel()
        {
            apiService = new ApiService();
            LoadAnimes();
        }

        private async void LoadAnimes()
        {

            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");

                await Application.Current.MainPage.Navigation.PopAsync();

                return;
            }


            var response = await this.apiService.GetList<Anime>("https://gist.githubusercontent.com", "/aws1994", "/f583d54e5af8e56173492d3f60dd5ebf/raw/c7796ba51d5a0d37fc756cf0fd14e54434c547bc/anime.json");

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");

                await Application.Current.MainPage.Navigation.PopAsync();

                return;
            }

            var list = (List<Anime>)response.Result;
            this.Animes = new ObservableCollection<Anime>(list);
        }
    }
}
