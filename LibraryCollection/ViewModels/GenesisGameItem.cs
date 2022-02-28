using LibraryCollection.Helper;
using LibraryCollection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCollection.ViewModels
{
    public class GenesisGameItem : GameItem
    {
        public static string GenesisGUID = "DDF2C48B-F6A6-4544-B226-95E49809AEAE";
        public GenesisGameItem(LibraryDbContext dbContext, Game game, INavigate navigator) : base(dbContext, game, navigator)
        {
        }
    }
}
