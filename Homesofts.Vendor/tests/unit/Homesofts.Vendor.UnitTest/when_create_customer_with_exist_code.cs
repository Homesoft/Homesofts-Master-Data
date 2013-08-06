using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Homesofts.Vendors.Service.parameters;

namespace Homesofts.Vendors.UnitTest
{
    public class when_create_customer_with_exist_code : behave_like_vendor_created
    {
        It must_not_created = () =>
        {
            try
            {
                serviceVendor.Create(new CreateVendorParameter
                                        {
                                            Code = "001",
                                            Name = "Duta Komputer",
                                            VendorType = Service.enums.VendorType.Customer,
                                            CurrencyId = "ccy-001",
                                            PaymentTermId = "term-001",
                                            OrganizationId = "org-001"
                                        });
            }
            catch (Exception ex)
            {
                ex.ShouldNotBeNull();
            }
        };
    }
}
