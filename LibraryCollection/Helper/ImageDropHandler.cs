using LibraryCollection.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryCollection.Helper
{
    /// <summary>
    /// process images that dropped on the application
    /// Copy the image to a dir and construct a DB Record and save
    /// Raise event with the Image model object
    /// </summary>
    public class ImageDropHandler : IHandleDropping
    {
        public event EventHandler<ImageDroppedEventArg> ImageDropped;
        private LibraryDbContext dbContext;
        private string imageExtension = "([^\\s]+(\\.(?i)(jpg|png|gif|bmp))$)"; // Simple limited set of image formats
        public ImageDropHandler(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        /// <summary>
        /// Item dropped on the application check if it's an image, and copy it to image location
        /// </summary>
        /// <param name="dropEvent"></param>
        public void HandleDrop(DragEventArgs dropEvent)
        {
            var filesDropped = dropEvent.Data.GetData("FileDrop") as string[];
            var imageFiles = filesDropped.Where(x=>Regex.IsMatch(x, imageExtension));
            if (imageFiles != null)
            {
                foreach (var file in imageFiles)
                {
                    //Copy and enter in to DB
                    FileInfo fileInfo = new FileInfo(file);
                    var imageModel = dbContext.Images.FirstOrDefault(x => x.name == fileInfo.Name);
                    if (imageModel == null)
                        imageModel = CreateImageRecord(fileInfo);

                    ImageDropped?.Invoke(this, new ImageDroppedEventArg { Image = imageModel });
                }
               
            }
        }

        /// <summary>
        /// Copy the image and create a DB record
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        private Image CreateImageRecord(FileInfo fileInfo)
        {
            File.Copy(fileInfo.FullName, $".\\Content\\Images\\Games\\{fileInfo.Name}", overwrite: true);

            var newImage = new Image
            {
                CreatedBy = "1",
                CreatedOn = DateTime.Now.ToShortDateString(),
                ImageId = Guid.NewGuid().ToString(),
                ModifiedBy = "1",
                ModifiedOn = DateTime.Now.ToShortDateString(),
                name = fileInfo.Name,
                path = $"Games\\{fileInfo.Name}"
            };
            dbContext.Images.Add(newImage);
            dbContext.SaveChanges();
            return newImage;
        }
    }
}
