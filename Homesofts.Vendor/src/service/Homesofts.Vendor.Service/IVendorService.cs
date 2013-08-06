using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Vendors.Service.parameters;

namespace Homesofts.Vendors.Service
{
    public interface IVendorService
    {
        /// <summary>
        /// Create Vendor
        /// </summary>
        /// <param name="param">parameter</param>
        /// <returns>id vendor</returns>
        string Create(CreateVendorParameter param);

        /// <summary>
        /// Update Vendor
        /// </summary>
        /// <param name="updateVendorParameter">parameter</param>
        void Update(UpdateVendorParameter param);

        /// <summary>
        /// De Activate Vendor
        /// </summary>
        /// <param name="id">id vendor</param>
        void DeActivate(string id);

        /// <summary>
        /// Activate Vendor
        /// </summary>
        /// <param name="id">id vendor</param>
        void Activate(string id);
    }
}
