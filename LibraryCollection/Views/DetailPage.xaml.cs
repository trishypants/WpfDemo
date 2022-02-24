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
    /// Interaction logic for DetailPage.xaml
    /// </summary>
    public partial class DetailPage: INavigationPage
    {
        public DetailPage()
        {
            InitializeComponent();
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

        /// <summary>
        /// Enable Drop in the XAML and capture the drop event and pass it to helper code outside of the CodeBehind
        /// </summary>
        /// <param name="e">Object passed by Windows when dragging and dropping</param>
        protected override void OnDrop(DragEventArgs e)
        {
            ISupportDragDropPage dropHandler = (ISupportDragDropPage)DataContext; // Assuming the ViewModel implements a ISupportDragDropPage.
            if (dropHandler != null)
            {
                dropHandler.HandleDrop(e);
            }
            base.OnDrop(e);
        }
    }
}
