using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Homesofts.Vendors.Service.models;

namespace Homesofts.Vendors.UnitTest
{
    class when_activate_vendor:behave_like_vendor_created
    {
        Establish context = () =>
        {
            serviceVendor.DeActivate(vendorId);
        };

        Because of = () =>
        {
            serviceVendor.Activate(vendorId);
        };

        It must_be_active = () =>
        {
            Vendor vendor = repositoryVendor.Get(vendorId);
            vendor.Status.ShouldEqual(Service.enums.Status.Active);
        };
    }
}
