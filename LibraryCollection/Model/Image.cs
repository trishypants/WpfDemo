using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCollection.Model
{
    /// <summary>
    /// Image Model Object, SQLite doesn't have that many data types (4 types)
    /// </summary>
    public class Image
    {
        public string ImageId { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string CreatedBy { get; set; }

    }
}
