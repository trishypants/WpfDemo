using Common.WPF.Helpers;
using Common.WPF.ViewModel;
using LibraryCollection.Model;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryCollection.ViewModels
{
    public class CollectionViewModel : NavigationBaseViewModel
    {
        public ObservableCollection<GameItem> Games { get => GetProperty<ObservableCollection<GameItem>>(); set => SetProperty(value); }
        

        private LibraryDbContext dbContext;
        public CollectionViewModel()
        {
            this.ReceivedNavigator += NavigationReady;
        }

        /// <summary>
        /// Received the Navigation helper object so the page is loaded and we can create GameItems 
        /// that are allowed to navigate so we needed the navigation helper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NavigationReady(object? sender, EventArgs e)
        {
            dbContext = new LibraryDbContext("../../../gamelib.sqlite3");
            Games = new ObservableCollection<GameItem>(dbContext.Games.OrderBy(x=>x.Title).Select(x => new GameItem(dbContext, x, navigator)));
        }
    }
}
