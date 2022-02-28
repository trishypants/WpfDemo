using Common.WPF.ViewModel;
using LibraryCollection.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using LibraryCollection.Extensions;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.Input;
using LibraryCollection.Helper;
using LibraryCollection.Views;
using MImage = LibraryCollection.Model.Image;

namespace LibraryCollection.ViewModels
{
    public class GameItem : BaseViewModel
    {
        public string GameId { get => GetProperty<string>(); set => SetProperty(value); }
        public string Title { get => GetProperty<string>(); set => SetProperty(value); }
        public string ReleasedYear { get => GetProperty<string>(); set => SetProperty(value); }
        public string DeveloperId { get => GetProperty<string>(); set => SetProperty(value); }
        public CompanyItem Developer { get => GetProperty<CompanyItem>(); set => SetProperty(value); }
        public string PublisherId { get => GetProperty<string>(); set => SetProperty(value); }
        public CompanyItem Publisher { get => GetProperty<CompanyItem>(); set => SetProperty(value); }
        public string SystemId { get => GetProperty<string>(); set => SetProperty(value); }
        public string Description { get => GetProperty<string>(); set => SetProperty(value); }
        public string ImagePath { get => GetProperty<string>(); set => SetProperty(value); }
        public string CoverImage { get => GetProperty<string>(); set => SetProperty(value); }
        public string Status { get => GetProperty<string>(); set => SetProperty(value); }
        public string CreatedBy { get => GetProperty<string>(); set => SetProperty(value); }
        public string CreatedOn { get => GetProperty<string>(); set => SetProperty(value); }
        public string ModifiedOn { get => GetProperty<string>(); set => SetProperty(value); }
        public string ModifiedBy { get => GetProperty<string>(); set => SetProperty(value); }
        public string LoremIpsum { get => Filler(); }

        public ImageSource FrontImage { get => GetProperty<ImageSource>(); set => SetProperty(value); }
        public MImage FrontImageData { get => GetProperty<MImage>(); set => SetProperty(value); }
        public ICommand OpenDetails { get => GetProperty<ICommand>(); set => SetProperty(value); }

        private LibraryDbContext dbContext; // Db connection
        private INavigate navigator; // Navigation Control
        private Game gameModel; // Game Model, used to save
        public GameItem(LibraryDbContext dbContext, Game game, INavigate navigator)
        {
            this.dbContext = dbContext;
            this.navigator = navigator;
            this.gameModel = game;
            OpenDetails = new RelayCommand(NavigateToDetails);
            LoadFromDB(game);
            if (string.IsNullOrWhiteSpace(Description))
                Description = LoremIpsum;
            RegisterPropertyMonitor(() => FrontImageData, LoadImage); // Register a Action to be performed when FrontImageData is modified
        }

        /// <summary>
        /// Save changes to a db
        /// </summary>
        public void Save()
        {
            if (!string.Equals(Title, "Alien Isolation", StringComparison.CurrentCultureIgnoreCase))
            {
                LoadToDB(gameModel);
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Used by the Collection Page to navigate to the DetailsPage when a game is clicked
        /// </summary>
        private void NavigateToDetails()
        {
            navigator.NavigateTo<DetailPage>(this);
        }

        #region Code to make the demo function
        // This Region is all code that pulls data from the DB and other persistant store operations, it's not really
        // part of the demo and was not written to be "clean" just cobbling the Model and ViewModel to get some demo data.


        /// <summary>
        /// Load the Game Model Data in to the GameItem ViewModel, this could be done in many different ways
        /// I know some with make the Model handle the Notification of changes, but I just needed some information
        /// for the demo.
        /// </summary>
        /// <param name="game">Game Model</param>
        private void LoadFromDB(Game game)
        {
            foreach (var prop in typeof(Game).GetProperties(BindingFlags.Public | BindingFlags.Instance)) // Simple Property Copy 
            {
                if (prop.CanRead)
                {
                    var value = prop.GetValue(game);
                    if (value != null)
                        SetProperty(value, prop.Name, false);
                }
            }
            FrontImageData = dbContext.Images.FirstOrDefault(x => x.ImageId == game.CoverImage);
            Developer = new CompanyItem(dbContext.Companies.FirstOrDefault(x => x.CompanyId == game.DeveloperId));
            Publisher = new CompanyItem(dbContext.Companies.FirstOrDefault(x => x.CompanyId == game.PublisherId));
            LoadImage();
        }
        /// <summary>
        /// Same as above, hacked together to get data pushing back in to the database, it's not even really needed
        /// for the demo but it did allow for some "easiy" changes that would have taken longer to do by hand
        /// </summary>
        /// <param name="game">Game Model</param>
        private void LoadToDB(Game game)
        {
            foreach (var prop in typeof(Game).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (prop.CanRead)
                {
                    var value = GetProperty<string>(prop.Name);
                    if (value != null)
                        prop.SetValue(game, value);

                }
            }
        }

        /// <summary>
        /// Locate the image  and read it in to be displayed, this is not good because it doesn't unload for items not
        /// on screen or load items getting on screen, it chews up the memory
        /// </summary>
        private void LoadImage()
        {
            if (FrontImageData != null && !string.IsNullOrWhiteSpace(FrontImageData.path))
            {
                if (File.Exists($".\\Content\\Images\\{FrontImageData.path}"))
                {
                    FrontImage = ((Bitmap)Bitmap.FromFile($".\\Content\\Images\\{FrontImageData.path}")).BitmapToImageSource();
                }
                else
                {
                    Debug.WriteLine($"Missing image {FrontImageData.path}");
                }
                if (CoverImage != FrontImageData.ImageId)
                    CoverImage = FrontImageData.ImageId;
            }

        }
        /// <summary>
        /// Just some text filler because the db isn't complete and was just easier this way
        /// </summary>
        /// <returns></returns>
        private string Filler()
        {
            return @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Neque volutpat ac tincidunt vitae semper quis lectus nulla. Platea dictumst vestibulum rhoncus est pellentesque elit. Vel pharetra vel turpis nunc. Ac orci phasellus egestas tellus rutrum tellus. Amet consectetur adipiscing elit pellentesque habitant morbi tristique senectus. Fringilla urna porttitor rhoncus dolor purus non. Sit amet consectetur adipiscing elit ut. Ut tellus elementum sagittis vitae et leo. In hendrerit gravida rutrum quisque non tellus orci ac. Quam quisque id diam vel quam elementum. Arcu dictum varius duis at consectetur lorem donec. Sem nulla pharetra diam sit amet nisl. Mattis vulputate enim nulla aliquet porttitor lacus luctus accumsan tortor.

In fermentum et sollicitudin ac. At auctor urna nunc id cursus metus aliquam eleifend. Sapien pellentesque habitant morbi tristique senectus et netus et. Rhoncus dolor purus non enim praesent. Donec enim diam vulputate ut. Vitae turpis massa sed elementum tempus egestas sed sed. Amet facilisis magna etiam tempor. Ut tristique et egestas quis ipsum. At varius vel pharetra vel. Urna nunc id cursus metus. Velit euismod in pellentesque massa placerat duis ultricies. Lacus laoreet non curabitur gravida arcu. Id aliquet risus feugiat in ante metus dictum. Massa tincidunt nunc pulvinar sapien. Sed lectus vestibulum mattis ullamcorper velit sed ullamcorper. Amet dictum sit amet justo donec enim diam vulputate ut.

Fringilla phasellus faucibus scelerisque eleifend donec pretium. Duis ut diam quam nulla porttitor massa id neque aliquam. Pharetra sit amet aliquam id diam maecenas ultricies mi eget. Tellus rutrum tellus pellentesque eu tincidunt tortor aliquam nulla facilisi. Arcu cursus euismod quis viverra nibh cras. Ac felis donec et odio. Etiam dignissim diam quis enim. Vulputate eu scelerisque felis imperdiet proin fermentum leo vel. Mauris rhoncus aenean vel elit scelerisque. Faucibus vitae aliquet nec ullamcorper sit. Velit dignissim sodales ut eu sem integer. In pellentesque massa placerat duis ultricies lacus sed turpis. At augue eget arcu dictum varius duis. Sit amet dictum sit amet. Donec enim diam vulputate ut pharetra sit amet aliquam id. In cursus turpis massa tincidunt dui ut ornare. Interdum velit laoreet id donec ultrices. Nibh cras pulvinar mattis nunc sed blandit libero volutpat sed. Turpis egestas integer eget aliquet nibh praesent tristique. Faucibus purus in massa tempor nec.

Suspendisse faucibus interdum posuere lorem ipsum dolor sit. Nulla pellentesque dignissim enim sit. Semper quis lectus nulla at volutpat diam ut venenatis. Integer feugiat scelerisque varius morbi enim nunc faucibus a. Enim sed faucibus turpis in eu mi bibendum neque egestas. Habitasse platea dictumst quisque sagittis purus. Tempor orci eu lobortis elementum nibh tellus molestie nunc non. Enim sed faucibus turpis in eu mi bibendum neque. Sodales ut eu sem integer vitae justo eget magna. Purus non enim praesent elementum facilisis leo. Velit euismod in pellentesque massa placerat duis. Erat pellentesque adipiscing commodo elit at imperdiet dui accumsan.

Sed sed risus pretium quam vulputate dignissim suspendisse. Porttitor rhoncus dolor purus non enim praesent elementum facilisis. Vel quam elementum pulvinar etiam non quam lacus suspendisse faucibus. Feugiat in fermentum posuere urna nec tincidunt. Habitant morbi tristique senectus et netus et malesuada fames. Bibendum at varius vel pharetra vel turpis nunc eget. Netus et malesuada fames ac turpis egestas. Volutpat odio facilisis mauris sit amet massa vitae tortor. Neque gravida in fermentum et sollicitudin ac orci phasellus. Euismod lacinia at quis risus sed vulputate odio.";
        }
        #endregion
    }
}
