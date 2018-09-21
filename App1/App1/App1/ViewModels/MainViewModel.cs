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
        #endregion

        public MainViewModel()
        {
            this.Login = new LoginViewModel();
        }
    }
}
