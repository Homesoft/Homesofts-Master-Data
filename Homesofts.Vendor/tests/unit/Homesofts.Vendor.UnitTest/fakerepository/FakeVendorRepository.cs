using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Vendors.Service;
using Homesofts.Vendors.Service.models;

namespace Homesofts.Vendors.UnitTest.fakerepository
{
    public class FakeVendorRepository:IVendorRepository
    {
        List<Vendor> vendors;
        List<string> paymentTerms;
        List<string> currencies;

        public FakeVendorRepository()
        {
            vendors = new List<Vendor>();
            paymentTerms = new List<string>(new string[] { "term-001", "term-002", "term-003" });
            currencies = new List<string>(new string[] { "ccy-001", "ccy-002", "ccy-003" });
        }

        public bool VendorExist(string code, string organizationId)
        {
            return vendors.Count(i => i.Code == code && i.OrganizationId == organizationId) > 0;
        }

        public bool PaymentTermExist(string paymentTermId, string organizationId)
        {
            return paymentTerms.Count(i => i == paymentTermId) > 0;
        }

        public bool CurrencyExist(string currencyId, string organizationId)
        {
            return currencies.Count(i => i == currencyId) > 0;
        }

        public void Save(Service.models.Vendor vendor)
        {
            vendors.Add(vendor);
        }

        public Service.models.Vendor Get(string id)
        {
            return vendors.FirstOrDefault(i => i.Id == id);
        }

        public void Update(Vendor vendor)
        {
            Vendor exist = vendors.FirstOrDefault(i => i.Id == vendor.Id);
            vendors.Remove(exist);
            vendors.Add(vendor);
        }
    }
}
