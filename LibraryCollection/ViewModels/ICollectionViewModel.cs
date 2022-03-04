using System.Collections.ObjectModel;
using System.Windows.Data;

namespace LibraryCollection.ViewModels
{
    public interface ICollectionViewModel
    {
        ListCollectionView FilteredGames { get; set; }
        ObservableCollection<GameItem> Games { get; set; }
        string SearchGames { get; set; }
    }
}