using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace Homesofts.Units.Test.Integration
{
    public class when_create_unit_with_exist_name : behave_like_unit_created
    {
        It should_be_not_created = () =>
        {
            try
            {
                Service.Create(new Service.Parameters.CreateParameter
                {
                    Code = "abc",
                    Name = "Pieces",
                    OrganizationId = "denny@homesofts.com"
                });
            }
            catch (Exception ex)
            {
                ex.ShouldNotBeNull();
            }
        };
    }
}
