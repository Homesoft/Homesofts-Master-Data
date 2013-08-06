using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace Homesofts.PaymentTerms.Test.Integration
{
    public class when_remove_payment_term : behave_like_payment_term_created
    {
        Because of = () =>
        {
            Service.Remove(term.Id);
        };

        It should_be_removed = () =>
        {
            Repository.Exist(term.Value, term.OrganizationId).ShouldBeFalse();
        };
    }
}
