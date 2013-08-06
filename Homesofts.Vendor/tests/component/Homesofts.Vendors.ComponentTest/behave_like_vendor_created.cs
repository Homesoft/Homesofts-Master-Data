using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Homesofts.Vendors.Service;
using Homesofts.Vendors.Repository;
using Homesofts.MongoConfiguration;
using Homesofts.Vendors.Service.parameters;
using MongoDB.Driver.Builders;
using Homesofts.Vendors.Service.models;

namespace Homesofts.Vendors.ComponentTest
{
    public class behave_like_vendor_created : TestBase
    {
        protected static string vendorId;
        protected static IVendorService serviceVendor;
        protected static IVendorRepository repositoryVendor;

        Establish context = () =>
        {
            repositoryVendor = new VendorRepository(MongoConfig.Instance);
            serviceVendor = new VendorService(repositoryVendor);

            vendorId = serviceVendor.Create(new CreateVendorParameter
            {
                Code = "001",
                Name = "Anugerah Lestari",
                VendorType = Service.enums.VendorType.Customer,
                CurrencyId = "ccy-001",
                PaymentTermId = "term-001",
                OrganizationId = "denny@homesofts.com"
            });
        };

        Cleanup remove_data_other = () =>
        {
            TestBase.RemoveOtherData();
            MongoConfig.Instance.Database.GetCollection<Vendor>().Remove(Query.EQ("_id", vendorId));
        };
    }
}
