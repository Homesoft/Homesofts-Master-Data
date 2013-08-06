using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace Homesofts.PaymentModes.Test.Integration
{
    [Subject("Update Payment Mode")]
    public class when_update_payment_mode : behave_like_mode_created
    {
        Because of = () =>
        {
            Service.Update(new Service.Parameters.UpdateParameter
            {
                Id = mode.Id,
                Name = "Master Card"
            });
        };

        It should_be_updated = () =>
        {
            Repository.Get(mode.Id).Name.ShouldEqual("Master Card");
        };
    }
}
