using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace Homesofts.PaymentTerms.Test.Integration
{
    [Subject("Update Payment Term")]
    public class when_update_payment_term : behave_like_payment_term_created
    {
        Because of = () =>
        {
            Service.Update(new Service.Parameters.UpdateParameter
            {
                Id = term.Id,
                Value = 30
            });
        };

        It value_should_be_30 = () =>
        {
            Repository.Get(term.Id).Value.ShouldEqual(30);
        };

        It name_should_be_30_Hari = () =>
        {
            Repository.Get(term.Id).Name.ShouldEqual("30 Hari");
        };
    }
}
