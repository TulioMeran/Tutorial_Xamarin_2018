using App1.Models;
using App1.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class AnimeItemViewModel: Anime
    {
        public ICommand SelectAnimeCommand
        {
            get
            {
                return new RelayCommand(SelectAnime);
            }
        }

        private async void SelectAnime()
        {

            MainViewModel.GetInstance().Anime = new AnimeViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new AnimePage());

        }
    }
}
