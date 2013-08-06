using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace Homesofts.Units.Test.Integration
{
    [Subject("Update Unit")]
    public class when_update_unit : behave_like_unit_created
    {
        Because of = () =>
        {
            Service.Update(new Service.Parameters.UpdateParameter
            {
                Id = unitCreated.Id,
                Code = "Pcs",
                Name = "Piece"
            });
        };

        It name_should_be_Piece = () =>
        {
            Repository.Get(unitCreated.Id).Name.ShouldEqual("Piece");
        };
    }
}
