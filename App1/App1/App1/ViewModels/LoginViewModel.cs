using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using App1.Views;

namespace App1.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {
        #region Atributos
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;


        #endregion

        #region Propiedades
        public string Email
        {

            get { return email; }

            set { SetValue(ref email, value); }

        }
        public string Password
        {
            get { return password; }

            set { SetValue(ref password, value); }
        }

        public bool IsRemember { get; set; }
        public bool IsRunning
        {
            get { return isRunning; }

            set { SetValue(ref isRunning, value); }

        }
        public bool IsEnabled
        {
            get { return isEnabled; }

            set { SetValue(ref isEnabled, value); }
        }
        #endregion

        #region Comandos

        public ICommand SignInCommand
        {
            get
            {
                return new RelayCommand(SignIn);

            }
        }

        private async void SignIn()
        {
            this.IsRunning = true;
            this.IsEnabled = false;

            if (string.IsNullOrEmpty(this.Email))
            {
                this.IsRunning = false;
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert("Error", "Email is empty", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                this.IsRunning = false;
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert("Error", "Password is empty ", "Ok");
                return;
            }

            if(this.Email != "tulio007@hotmail.es" || this.Password != "guapo12")
            {
                this.IsRunning = false;
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert("Error", "Password or Email is incorrect.", "Accept");
                this.Password = string.Empty;
                return;
            }

            this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.Password = string.Empty;

            MainViewModel.GetInstance().Animes = new AnimesViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new AnimesPage());

        }


        #endregion

        #region Constructor

        public LoginViewModel()
        {
            this.IsRemember = true;
            this.Email = "tulio007@hotmail.es";
            this.Password = "guapo12";
            this.IsEnabled = true;
        }

        #endregion


    }
}
