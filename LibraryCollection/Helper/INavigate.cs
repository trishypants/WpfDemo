using LibraryCollection.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace LibraryCollection.Helper
{
    public interface INavigate
    {
        void NavigateTo<T>() where T : INavigationPage;
        void NavigateTo<T>(object state) where T : INavigationPage;
        void NavigateBack();

        event EventHandler<NavigatingCancelEventArgs> Navigating;
    }
}
