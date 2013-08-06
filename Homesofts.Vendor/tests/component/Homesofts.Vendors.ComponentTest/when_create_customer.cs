using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Vendors.Service;
using Homesofts.Vendors.Repository;
using Homesofts.Vendors.Service.parameters;
using Homesofts.Vendors.Service.models;
using Homesofts.MongoConfiguration;
using MongoDB.Driver.Builders;
using Machine.Specifications;
using Homesofts.Vendors.Service.others;

namespace Homesofts.Vendors.ComponentTest
{
    public class when_create_customer : TestBase
    {
        static IVendorService serviceVendor;
        static IVendorRepository repositoryVendor;
        static string vendorId;

        Establish context = () =>
        {
            repositoryVendor = new VendorRepository(MongoConfig.Instance);
            serviceVendor = new VendorService(repositoryVendor);
        };

        Because of = () =>
        {
            List<CreateVendorContactParameter> contacts = new List<CreateVendorContactParameter>();
            contacts.Add(new CreateVendorContactParameter
            {
                Email = "denny@homesofts.com",
                Mobile = "08566584915",
                Name = "Denny"
            });
            contacts.Add(new CreateVendorContactParameter
            {
                Email = "denny1@inforsys.co.id",
                Mobile = "08566584915",
                Name = "Denny"
            });
            vendorId = serviceVendor.Create(new CreateVendorParameter
            {
                Code = "001",
                Name = "Anugerah Lestari",
                VendorType = Service.enums.VendorType.Customer,
                CurrencyId = "ccy-001",
                PaymentTermId = "term-001",
                OrganizationId = "denny@homesofts.com",
                Contacts = contacts
            });
        };

        It must_be_created = () =>
        {
            Vendor vendor = repositoryVendor.Get(vendorId);
            vendor.ShouldNotBeNull();
        };

        It must_be_of_type_customer = () =>
        {
            Vendor vendor = repositoryVendor.Get(vendorId);
            vendor.Type.ShouldEqual(Service.enums.VendorType.Customer);
        };

        It must_be_active = () =>
        {
            Vendor vendor = repositoryVendor.Get(vendorId);
            vendor.Status.ShouldEqual(Service.enums.Status.Active);
        };

        It contact_must_be_greater_than_zero = () =>
        {
            Vendor vendor = repositoryVendor.Get(vendorId);
            vendor.Contacts.Count().ShouldBeGreaterThan(0);
        };

        Cleanup remove_test_data = () =>
        {
            TestBase.RemoveOtherData();
            MongoConfig.Instance.Database.GetCollection<Vendor>().Remove(Query.EQ("_id", vendorId));
        };
    }
}
