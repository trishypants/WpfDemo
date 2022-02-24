using LibraryCollection.Helper;
using LibraryCollection.Views;
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

namespace LibraryCollection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NavigateHelper navigator; // Object to help with Navigation and removes code from CodeBehind.
        public MainWindow()
        {
            InitializeComponent();
            navigator = new NavigateHelper(frame);
            navigator.NavigateTo<CollectionPage>();
        }

        private void Frame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            INavigationPage page = (INavigationPage)e.Content; // Assuming a page is always a INavigationPage
            if (page != null)
            {
                page.NavigatingTo(navigator); // Pass the Navigation helper to the next page
            }
        }

    }
}
