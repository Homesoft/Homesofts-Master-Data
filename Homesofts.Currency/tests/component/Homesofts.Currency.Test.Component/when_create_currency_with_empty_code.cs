using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Homesofts.Currency.Service;
using Homesofts.Currency.Test.Component.fakerepository;
using Homesofts.MongoConfiguration;
using Models = Homesofts.Currency.Service.models;
using Homesofts.Currency.Service.parameters;

namespace Homesofts.Currency.Test.Component
{
    [Subject("Create Currency")]
    public class when_create_currency_with_empty_code
    {
        static ICurrencyService Service;
        static ICurrencyRepository Repository;

        Establish context = () =>
        {
            Repository = new FakeCurrencyRepository();
            Service = new CurrencyService(Repository);
        };

        It should_not_created = () =>
        {
            try
            {
                Models.Currency ccy = Service.Create(new CreateParameter
                {
                    Code = "",
                    Name = "Rupiah",
                    Rounding = 2,
                    Symbol = "Rp",
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
