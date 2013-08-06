using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace Homesofts.PaymentModes.Test.Integration
{
    [Subject("Remove Payment Mode")]
    public class when_remove_payment_mode : behave_like_mode_created
    {
        Because of = () =>
        {
            Service.Remove(mode.Id);
        };

        It should_be_removed = () =>
        {
            Repository.Exist("VISA", "denny@homesofts.com").ShouldBeFalse();
        };
    }
}
