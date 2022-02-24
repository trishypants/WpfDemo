using Common.WPF.ViewModel;
using LibraryCollection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCollection.ViewModels
{
    public class CompanyItem : BaseViewModel
    {
        public string CompanyId { get => GetProperty<string>(); set => SetProperty(value); }
        public string Name { get => GetProperty<string>(); set => SetProperty(value); }
        public string WebSite { get => GetProperty<string>(); set => SetProperty(value); }
        public string Description { get => GetProperty<string>(); set => SetProperty(value); }
        public string Address1 { get => GetProperty<string>(); set => SetProperty(value); }
        public string Address2 { get => GetProperty<string>(); set => SetProperty(value); }
        public string State { get => GetProperty<string>(); set => SetProperty(value); }
        public string City { get => GetProperty<string>(); set => SetProperty(value); }
        public string Zip { get => GetProperty<string>(); set => SetProperty(value); }
        public string Phone { get => GetProperty<string>(); set => SetProperty(value); }
        public string Email { get => GetProperty<string>(); set => SetProperty(value); }
        public string Image { get => GetProperty<string>(); set => SetProperty(value); }
        public string CreatedOn { get => GetProperty<string>(); set => SetProperty(value); }
        public string CreatedBy { get => GetProperty<string>(); set => SetProperty(value); }
        public string ModifiedOn { get => GetProperty<string>(); set => SetProperty(value); }
        public string ModifiedBy { get => GetProperty<string>(); set => SetProperty(value); }


        public CompanyItem(Company company)
        {
            LoadFromDB(company);
        }

        /// <summary>
        /// Much like the GameItem's LoadFromDB, copies the properties from the Company Model object to this
        /// it's a quick hack to the information and was only done for the demo
        /// </summary>
        /// <param name="company"></param>
        private void LoadFromDB(Company company)
        {
            foreach (var prop in typeof(Company).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (prop.CanRead)
                {
                    var value = prop.GetValue(company);
                    if (value != null)
                        SetProperty(value, prop.Name, false);
                }
            }
        }
    }
}
