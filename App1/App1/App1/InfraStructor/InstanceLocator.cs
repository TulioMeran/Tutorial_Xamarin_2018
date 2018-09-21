using System;
using System.Collections.Generic;
using System.Text;
using App1.ViewModels;

namespace App1.InfraStructor
{
    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }


        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }

    
}
