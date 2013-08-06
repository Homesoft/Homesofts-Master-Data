using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Extension;

namespace Homesofts.Vendors.Service.models
{
    public class VendorContact
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public bool IsDefault { get; set; }

        public VendorContact(parameters.CreateVendorContactParameter param)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Name = param.Name;
            this.Email = param.Email.IsNull() ? "" : param.Email;
            this.Phone = param.Phone.IsNull() ? "" : param.Phone;
            this.Mobile = param.Mobile.IsNull() ? "" : param.Mobile;
            this.IsDefault = param.IsDefault;
        }
    }
}
