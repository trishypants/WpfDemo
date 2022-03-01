using LibraryCollection.Helper;
using LibraryCollection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCollection.ViewModels
{
    public class SonyGameItem : GameItem
    {
        private const string PS3 = "C7C34B75-E488-4812-88AD-F4E87CCE8F68";
        private const string PS4 = "AFE0486E-A001-405E-A85F-59E244ABB8CE";
        private const string PS2 = "B6CC17A3-3E25-4D93-9AA9-07F73501E4FD";
        private const string VITA = "D9991FB6-46FD-4CBA-96DD-6F29334CD820";


        public static string[] SystemIds = new string[] { PS3, PS4, PS2, VITA };

        public string SystemName => GetSystemName();

        private string GetSystemName()
        {
            if (SystemId == PS2) return "Playstation 2";
            if (SystemId == PS3) return "Playstation 3";
            if (SystemId == PS4) return "Playstation 4";
            if (SystemId == VITA) return "Playstation Vita";
            return string.Empty;
        }

        public SonyGameItem(LibraryDbContext dbContext, Game game, INavigate navigator) : base(dbContext, game, navigator)
        {
        }
    }
}
