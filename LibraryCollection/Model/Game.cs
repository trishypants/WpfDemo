using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCollection.Model
{
    /// <summary>
    /// Game Model Object, SQLite doesn't have that many data types (4 types)
    /// </summary>
    public class Game
    {
        public string GameId { get; set; }
        public string Title { get; set; }
        public string? ReleasedYear { get; set; }
        public string DeveloperId { get; set; }
        public string PublisherId { get; set; }
        public string SystemId { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public string? CoverImage { get; set; }
        public string? Status { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

       

    }
}
