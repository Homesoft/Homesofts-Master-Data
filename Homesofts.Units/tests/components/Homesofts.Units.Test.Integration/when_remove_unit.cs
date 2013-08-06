using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace Homesofts.Units.Test.Integration
{
    [Subject("Remove Unit")]
    public class when_remove_unit : behave_like_unit_created
    {
        Because of = () =>
        {
            Service.Remove(unitCreated.Id);
        };

        It should_be_deleted = () =>
        {
            Repository.Exist("Pcs", "denny@homesofts.com").ShouldBeFalse();
        };
    }
}
