using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {
        #region Atributos
        private string password;
        private bool isRunning;
        private bool isEnabled;


        #endregion

        #region Propiedades
        public string Email { get; set; }
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

            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Email is empty", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Password is empty ", "Ok");
                return;
            }

            if(this.Email != "tulio007@hotmail.es" || this.Password != "guapo12")
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Password or Email is incorrect.", "Accept");
                this.Password = string.Empty;
                return;
            }

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
