using LibraryCollection.Helper;
using LibraryCollection.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryCollection.Views
{
    /// <summary>
    /// Interaction logic for CollectionPage.xaml
    /// </summary>
    public partial class CollectionPage : INavigationPage
    {
        public CollectionPage()
        {

            this.Loaded += CollectionPage_Loaded;
            InitializeComponent();
           
        }

        private void CollectionPage_Loaded(object sender, RoutedEventArgs e)
        {
            NavigatingTo(new NavigateHelper(NavigationService));
        }
       
        /// <summary>
        /// Capture the Navigation helper when the page is navigated to and pass it to it's BaseViewModel
        /// </summary>
        /// <param name="navigator">The Navigation Helper</param>
        public void NavigatingTo(INavigate navigator)
        {
            if (DataContext is NavigationBaseViewModel nbvm)
            {
                nbvm.NavigatedTo(navigator);
            }
        }
    }
}
