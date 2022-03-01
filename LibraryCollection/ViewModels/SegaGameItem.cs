using LibraryCollection.Helper;
using LibraryCollection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCollection.ViewModels
{
    public class SegaGameItem : GameItem
    {
        private const string GENESIS = "DDF2C48B-F6A6-4544-B226-95E49809AEAE";
        public static string[] SystemIds =new string[] { GENESIS };

        public string SystemName => GetSystemName();

        private string GetSystemName()
        {
            if (SystemId == GENESIS) return "Genesis";
            return string.Empty;
        }

            public SegaGameItem(LibraryDbContext dbContext, Game game, INavigate navigator) : base(dbContext, game, navigator)
        {
        }
    }
}
