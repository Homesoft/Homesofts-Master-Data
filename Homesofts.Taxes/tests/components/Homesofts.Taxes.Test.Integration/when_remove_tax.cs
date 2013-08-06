using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace Homesofts.Taxes.Test.Integration
{
    [Subject("Remove Tax")]
    public class when_remove_tax : behave_like_tax_created
    {
        Because of = () =>
        {
            Service.Remove(taxCreated.Id);
        };

        It should_be_removed = () =>
        {
            Repository.Exist(taxCreated.Code, taxCreated.OrganizationId).ShouldBeFalse();
        };
    }
}
