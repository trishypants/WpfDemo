using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryCollection.Helper
{
    public interface IHandleDropping
    {
        public void HandleDrop(DragEventArgs dropEvent);

        event EventHandler<ImageDroppedEventArg> ImageDropped;
    }
}
