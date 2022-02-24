using Common.WPF.ViewModel;
using LibraryCollection.Helper;
using LibraryCollection.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LibraryCollection.Views
{
    public interface INavigationPage
    {
        void NavigatingTo(INavigate navigator);
    }
}
