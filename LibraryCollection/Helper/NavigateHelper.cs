using LibraryCollection.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace LibraryCollection.Helper
{
    /// <summary>
    /// Helper class to manage navigation between pages
    /// </summary>
    public class NavigateHelper : INavigate
    {
        private NavigationService navigation;
        public event EventHandler<NavigatingCancelEventArgs> Navigating;
        public NavigateHelper(NavigationService navigation)
        {
            this.navigation = navigation;
            this.navigation.Navigating += (s, e) => Navigating?.Invoke(s, e);
        }

        public void NavigateBack()
        {
          if( navigation.CanGoBack)
                navigation.GoBack();
        }

        public void NavigateTo<T>() where T : INavigationPage
        {
            NavigateTo<T>(null);
        }

        public void NavigateTo<T>(object state) where T : INavigationPage
        {
            navigation.Navigate(Construct<T>(), state);
        }

        /// <summary>
        /// Contruct the page to navigate to, would be better with IOC or some other system to manage creation
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private T Construct<T>() where T : INavigationPage
        {
            T page = (T)Activator.CreateInstance(typeof(T));

            if (page != null)
            {
                page.NavigatingTo(this);
            }
            return page;
        }
    }
}
