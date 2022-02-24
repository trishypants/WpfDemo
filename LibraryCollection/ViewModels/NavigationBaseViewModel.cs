using Common.WPF.ViewModel;
using LibraryCollection.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LibraryCollection.ViewModels
{
    /// <summary>
    /// A class to help ViewModel access and manage the Navigation Helper Object
    /// </summary>
    public abstract class NavigationBaseViewModel:BaseViewModel
    {
        protected INavigate navigator; 
        public event EventHandler ReceivedNavigator;
        public void NavigatedTo(INavigate navigator)
        {
            this.navigator = navigator;
            ReceivedNavigator?.Invoke(this, new EventArgs());
        }
    }
}
