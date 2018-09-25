using App1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class AnimeViewModel : BaseViewModel
    {

        #region Propiedades

        public Anime Anime
        {
            get;
            set;

        }

        #endregion

        #region Constructor

        public AnimeViewModel(Anime anime)
        {
            this.Anime = anime;

 
        } 
        #endregion
    }
}
