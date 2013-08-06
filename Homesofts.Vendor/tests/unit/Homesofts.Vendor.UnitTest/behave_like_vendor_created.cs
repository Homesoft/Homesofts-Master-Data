using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Homesofts.Vendors.Service;
using Homesofts.Vendors.Service.parameters;

namespace Homesofts.Vendors.UnitTest
{
    public class behave_like_vendor_created
    {
        protected static string vendorId;
        protected static IVendorService serviceVendor;
        protected static IVendorRepository repositoryVendor;

        Establish context = () =>
        {
            repositoryVendor = new fakerepository.FakeVendorRepository();
            serviceVendor = new VendorService(repositoryVendor);

            vendorId = serviceVendor.Create(new CreateVendorParameter
            {
                Code = "001",
                Name = "Anugerah Lestari",
                VendorType = Service.enums.VendorType.Customer,
                CurrencyId = "ccy-001",
                PaymentTermId = "term-001",
                OrganizationId = "org-001"
            });
        };
    }
}
