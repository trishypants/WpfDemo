using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCollection.Model
{
    /// <summary>
    /// Company Model Object, SQLite doesn't have that many data types (4 types)
    /// </summary>
    public class Company
    {
        public string CompanyId { get; set; }
        public string Name { get; set; }
        public string WebSite { get; set; }
        public string Description { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

    }
}
