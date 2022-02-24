using LibraryCollection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCollection.Helper
{
    public class ImageDroppedEventArg : EventArgs
    {
        public Image Image { get; set; }
    }
}
