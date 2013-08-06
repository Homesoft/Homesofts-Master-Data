using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Currency.Service;
using Homesofts.Currency.Test.Component.fakerepository;
using Homesofts.MongoConfiguration;
using Models = Homesofts.Currency.Service.models;
using Machine.Specifications;

namespace Homesofts.Currency.Test.Component
{
    [Subject("Update Currency")]
    public class when_update_currency_with_empty_code : behave_currency_created
    {
        It should_not_updated = () =>
        {
            try
            {
                Service.Update(new Service.parameters.UpdateParameter
                {
                    Id = ccyId,
                    Code = "",
                    Name = "US Dollar",
                    Rounding = 2,
                    Symbol = "$"
                });
            }
            catch (Exception ex)
            {
                ex.ShouldNotBeNull();
            }
        };
    }
}
