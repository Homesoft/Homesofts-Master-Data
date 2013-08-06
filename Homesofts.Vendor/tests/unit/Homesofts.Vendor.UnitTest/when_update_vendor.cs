using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Homesofts.Vendors.Service.parameters;
using Homesofts.Vendors.Service.models;

namespace Homesofts.Vendors.UnitTest
{
    class when_update_vendor : behave_like_vendor_created
    {
        Because of = () =>
        {
            serviceVendor.Update(new UpdateVendorParameter
            {
                Id = vendorId,
                Name = "Duta Komputer",
                Address = "komplek mitra raya",
                PaymentTermId = "term-002",
                CurrencyId = "ccy-001",
                City = "Batam",
                Code = "001",
                Country = "Indonesia",
                Email = "denny@inforsys.co.id"
            });
        };

        It paymentterm_must_be_updated = () =>
        {
            Vendor vendor = repositoryVendor.Get(vendorId);
            vendor.PaymentTermId.ShouldEqual("term-002");
        };

        It address_must_be_updated = () =>
        {
            Vendor vendor = repositoryVendor.Get(vendorId);
            vendor.Address.ShouldEqual("komplek mitra raya");
        };

        It city_must_be_updated = () =>
        {
            Vendor vendor = repositoryVendor.Get(vendorId);
            vendor.City.ShouldEqual("Batam");
        };

        It code_must_be_updated = () =>
        {
            Vendor vendor = repositoryVendor.Get(vendorId);
            vendor.Code.ShouldEqual("001");
        };

        It country_must_be_updated = () =>
        {
            Vendor vendor = repositoryVendor.Get(vendorId);
            vendor.Country.ShouldEqual("Indonesia");
        };
    }
}
