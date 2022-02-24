using LibraryCollection.Helper;
using LibraryCollection.Model;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LibraryCollection.ViewModels
{
    public class DetailViewModel : NavigationBaseViewModel, ISupportDragDropPage
    {
        public GameItem Game { get => GetProperty<GameItem>(); set => SetProperty(value); }
        public ICommand GoBack { get => GetProperty<ICommand>(); set => SetProperty(value); }
        private IHandleDropping dropHandler; // Helper class to manage turning the image file path in to a Image Model
        private LibraryDbContext dbContext; // DB connection
       
        public DetailViewModel()
        {
            this.ReceivedNavigator += DetailViewModel_ReceivedNavigator;
            GoBack = new RelayCommand(NavigateToPreviousPage);
        }

        private void DetailViewModel_ReceivedNavigator(object? sender, EventArgs e)
        {
            navigator.Navigating += Navigator_Navigating;
            dbContext = new LibraryDbContext("../../../gamelib.sqlite3");
            dropHandler = new ImageDropHandler(dbContext);
            dropHandler.ImageDropped += UpdateGameImage;
        }

        /// <summary>
        /// Receieved an event that an Image was dropped and the help has finished processing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateGameImage(object? sender, ImageDroppedEventArg e)
        {
            if(Game.FrontImageData != e.Image)
                Game.FrontImageData = e.Image;
        }

        /// <summary>
        /// We been navigated to, need to check that we have game infomation to display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Navigator_Navigating(object? sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            if (e.ExtraData is GameItem game)
            {
                Game = game;
            }
        }

        /// <summary>
        /// Navigating away, Save the game and tell the navigator to go back
        /// </summary>
        private void NavigateToPreviousPage()
        {
            Game.Save();
            navigator.NavigateBack();
        }

        /// <summary>
        /// The page received a drop, pass it off to the drop handler helper to process
        /// </summary>
        /// <param name="dropEvent"></param>
        public void HandleDrop(DragEventArgs dropEvent)
        {
            if (dropHandler != null)
            {
                dropHandler.HandleDrop(dropEvent);
            }
        }
    }
}
