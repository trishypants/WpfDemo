using Common.WPF.Helpers;
using Common.WPF.ViewModel;
using LibraryCollection.Helper;
using LibraryCollection.Model;
using Microsoft.EntityFrameworkCore;
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
    public class CollectionViewModel : NavigationBaseViewModel, ICollectionViewModel
    {
        public ObservableCollection<GameItem> Games { get => GetProperty<ObservableCollection<GameItem>>(); set => SetProperty(value); }
        public ListCollectionView FilteredGames { get => GetProperty<ListCollectionView>(); set => SetProperty(value); }
        public string SearchGames { get => GetProperty<string>(); set => SetProperty(value); }

        private LibraryDbContext dbContext;
        public CollectionViewModel()
        {
            dbContext = new LibraryDbContext("../../../gamelib.sqlite3");
            Games = new ObservableCollection<GameItem>();
            FilteredGames = new ListCollectionView(Games);
            this.ReceivedNavigator += NavigationReady;
        }

        /// <summary>
        /// Received the Navigation helper object so the page is loaded and we can create GameItems 
        /// that are allowed to navigate so we needed the navigation helper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void NavigationReady(object? sender, EventArgs e)
        {
            RegisterPropertyMonitor(() => SearchGames, UpdateFilter);
            await LoadGamesAsync();
        }

        private async Task LoadGamesAsync()
        {
            foreach (var game in dbContext.Games.OrderBy(x => x.Title.ToLower()))
            {
                var gi = await GameItem.Construct(game, dbContext, navigator);
                Games.Add(gi); // This loads all games, and it's slow would be better to fetch in pages as it's scrolled and Async
                await Task.Delay(20);
            }
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
