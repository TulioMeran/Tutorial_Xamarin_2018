using System;
using System.Collections.Generic;
using System.Text;

namespace App1.ViewModels
{
    public class MainViewModel
    {
        #region ViewModels
        public LoginViewModel Login
        {
            get;
            set;
        } 

        public AnimesViewModel Animes
        {
            get;
            set;
        }

        public AnimeViewModel Anime
        {
            get;
            set;
        }

        #endregion

        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }

        #region SingleTon

        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        } 

        #endregion
    }
}
