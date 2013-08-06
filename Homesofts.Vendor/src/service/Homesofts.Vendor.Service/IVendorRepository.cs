using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Vendors.Service.models;

namespace Homesofts.Vendors.Service
{
    public interface IVendorRepository
    {
        bool VendorExist(string code, string organizationId);

        bool PaymentTermExist(string paymentTermId, string organizationId);

        bool CurrencyExist(string currencyId, string organizationId);

        void Save(Vendor vendor);

        Vendor Get(string id);

        void Update(Vendor vendor);
    }
}
