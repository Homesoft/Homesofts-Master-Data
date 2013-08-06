using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Homesofts.Vendors.Service.models;

namespace Homesofts.Vendors.UnitTest
{
    class when_deactive_vendor : behave_like_vendor_created
    {
        Because of = () =>
        {
            serviceVendor.DeActivate(vendorId);
        };

        It must_be_inactive = () =>
        {
            Vendor vendor = repositoryVendor.Get(vendorId);
            vendor.Status.ShouldEqual(Service.enums.Status.InActive);
        };
    }
}
