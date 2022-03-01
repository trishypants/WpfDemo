using LibraryCollection.Helper;
using LibraryCollection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCollection.ViewModels
{
    internal class MicrosoftGameItem : GameItem
    {
        private const string XBOX = "CBBC3BF7-6E9E-446A-B4CE-98B90A48A3E9";
        private const string XBOX360 = "196ABC75-39C6-4A17-AC9F-F8B58A442502";

        public static string[] SystemIds = new string[] { XBOX, XBOX360 };

        public string SystemName => GetSystemName();

        private string GetSystemName()
        {
            if (SystemId == XBOX) return "Xbox";
            if (SystemId == XBOX360) return "Xbox 360";
            return string.Empty;
        }

            public MicrosoftGameItem(LibraryDbContext dbContext, Game game, INavigate navigator) : base(dbContext, game, navigator)
        {
        }
    }
}
