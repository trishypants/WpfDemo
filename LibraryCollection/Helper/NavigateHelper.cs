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
    /// Helper class to manage navigation between pages,
    /// a light and modified design I wrote years ago, it's influned by the UWP (AppStore App) navigation
    /// </summary>
    public class NavigateHelper : INavigate
    {
        private Frame frame;
        public event EventHandler<NavigatingCancelEventArgs> Navigating;
        public NavigateHelper(Frame frame)
        {
            this.frame = frame;
            this.frame.Navigating += (s, e) => Navigating?.Invoke(s, e);
        }

        public void NavigateBack()
        {
          if( frame.CanGoBack)
                frame.GoBack();
        }

        public void NavigateTo<T>() where T : INavigationPage
        {
            var page = Construct<T>();
            frame.Navigate(page);
        }

        public void NavigateTo<T>(object state) where T : INavigationPage
        {
            var page = Construct<T>();
            frame.Navigate(page, state);
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
