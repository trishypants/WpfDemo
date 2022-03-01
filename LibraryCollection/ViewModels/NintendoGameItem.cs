using LibraryCollection.Helper;
using LibraryCollection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCollection.ViewModels
{
    internal class NintendoGameItem : GameItem
    {
        private const string WII = "0277F367-16C7-452D-B7D2-E0F2CA82ED7F";
        private const string GAMECUBE = "9AB1BFF3-6C07-436A-839B-84A9B85E3CC4";
        private const string NES = "AD32A736-98BF-49FA-9E08-3ACEEEFC1F49";
        private const string SNES = "BCDCE2C8-3426-4501-8948-E239CC3DB959";
        private const string WIIU = "DAB02D99-0C55-46DC-B7BF-E1F5CF1EF6A2";
        private const string N3DS = "F4046E9D-1A5C-4DEA-A6B5-EB41BE97FA39";



        public static string[] SystemIds = new string[]  {NES,SNES,GAMECUBE,WII,WIIU,N3DS};

        public string SystemName => GetSystemName();

        private string GetSystemName()
        {
            if (SystemId == NES) return "NES";
            if (SystemId == SNES) return "SNES";
            if (SystemId == GAMECUBE) return "GameCube";
            if (SystemId == WII) return "Wii";
            if (SystemId == WIIU) return "Wii U";
            if (SystemId == N3DS) return "3DS";
            return string.Empty;
        }

            public NintendoGameItem(LibraryDbContext dbContext, Game game, INavigate navigator) : base(dbContext, game, navigator)
        {
        }
    }
}
