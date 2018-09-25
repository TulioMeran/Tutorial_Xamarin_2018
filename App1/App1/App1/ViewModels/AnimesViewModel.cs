using App1.Models;
using App1.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class AnimesViewModel: BaseViewModel
    {
        #region Services

        public ApiService apiService; 

        #endregion

        #region Atributos

        private ObservableCollection<AnimeItemViewModel> animes;
        private bool isRefreshing;
        private string filter;
        private List<Anime> listAnimes;

        #endregion

        #region Propiedades

        public ObservableCollection<AnimeItemViewModel> Animes
        {

            get { return animes; }

            set { SetValue(ref animes, value); }
        } 

        public bool IsRefreshing
        {

            get { return isRefreshing; }

            set { SetValue(ref isRefreshing, value); }
        }

        public string Filter
        {
            get { return filter; }

            set {
                
                SetValue(ref filter, value);
                this.Search();
            }
        }

        #endregion

        #region Comandos

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadAnimes);
            }
        } 

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(Filter))
            {
                this.Animes = new ObservableCollection<AnimeItemViewModel>( this.ToAnimeItemViewModel());
            } else
            {
                this.Animes = new ObservableCollection<AnimeItemViewModel>(this.ToAnimeItemViewModel().Where(a => a.Name.ToLower().Contains(Filter.ToLower()) || a.Category.ToLower().Contains(Filter.ToLower())));
            }
        }


        #endregion

        private IEnumerable<AnimeItemViewModel> ToAnimeItemViewModel()
        {

            return this.listAnimes.Select(a => new AnimeItemViewModel
            {

                Name = a.Name,
                Category = a.Category,
                Description = a.Description,
                Episode = a.Episode,
                Rating = a.Rating,
                Studio = a.Studio,
                Img = a.Img

            });

        }


        public AnimesViewModel()
        {
            
            apiService = new ApiService();
            LoadAnimes();
        }

        private async void LoadAnimes()
        {
            IsRefreshing = true;

            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                IsRefreshing = false;

                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");

                await Application.Current.MainPage.Navigation.PopAsync();

                return;
            }


            var response = await this.apiService.GetList<Anime>("https://gist.githubusercontent.com", "/aws1994", "/f583d54e5af8e56173492d3f60dd5ebf/raw/c7796ba51d5a0d37fc756cf0fd14e54434c547bc/anime.json");

            if (!response.IsSuccess)
            {
                IsRefreshing = false;

                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");

                await Application.Current.MainPage.Navigation.PopAsync();

                return;
            }

             listAnimes = (List<Anime>)response.Result;
            this.Animes = new ObservableCollection<AnimeItemViewModel>(this.ToAnimeItemViewModel());
            IsRefreshing = false;
        }
    }
}
