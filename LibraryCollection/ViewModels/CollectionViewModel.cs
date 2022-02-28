using Common.WPF.Helpers;
using Common.WPF.ViewModel;
using LibraryCollection.Helper;
using LibraryCollection.Model;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace LibraryCollection.ViewModels
{
    public class CollectionViewModel : NavigationBaseViewModel
    {
        public ObservableCollection<GameItem> Games { get => GetProperty<ObservableCollection<GameItem>>(); set => SetProperty(value); }
        public ListCollectionView FilteredGames { get => GetProperty<ListCollectionView>(); set => SetProperty(value); }
        public string SearchGames { get => GetProperty<string>(); set => SetProperty(value); }

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
            Games = new ObservableCollection<GameItem>(dbContext.Games.OrderBy(x => x.Title).Select(x => Map(x, dbContext,navigator))); // This loads all games, and it's slow would be better to fetch in batchest as it's scrolled and Async
            FilteredGames = new ListCollectionView(Games);
            RegisterPropertyMonitor(() => SearchGames, UpdateFilter);
        }

        private static GameItem Map(Game game, LibraryDbContext dbContext, INavigate navigator)
        {
            return game.SystemId == GenesisGameItem.GenesisGUID ? new GenesisGameItem(dbContext, game, navigator): new GameItem(dbContext, game, navigator);
        }

        private void UpdateFilter()
        {
            FilteredGames.Filter = (e) =>
            {
                if (e is GameItem item)
                {
                    return item.Title.StartsWith(SearchGames, StringComparison.CurrentCultureIgnoreCase);
                }
                return false;
            };

        }
    }
}
