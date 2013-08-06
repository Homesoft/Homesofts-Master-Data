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
    public class when_update_currency : behave_currency_created
    {
        Because of = () =>
        {
            Service.Update(new Service.parameters.UpdateParameter
            {
                Id = ccyId,
                Code = "USD",
                Name = "US Dollar",
                Rounding = 2,
                Symbol = "$"
            });
        };

        It code_should_be_USD = () =>
        {
            Models.Currency ccy = Repository.Get(ccyId);
            ccy.Code.ShouldEqual("USD");
        };

        It Name_should_be_US_Dollar = () =>
        {
            Models.Currency ccy = Repository.Get(ccyId);
            ccy.Name.ShouldEqual("US Dollar");
        };
    }
}
