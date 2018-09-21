using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace App1.ViewModels
{
    public class LoginViewModel
    {
        #region Propiedades
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsRemember { get; set; }
        public bool IsRunning { get; set; }
        #endregion


        #region Comandos

        public ICommand SignIn { get; set; }


        #endregion

        #region Constructor

        public LoginViewModel()
        {
            this.IsRemember = true;
        }

        #endregion


    }
}
