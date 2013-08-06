using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Currency.Service;
using Homesofts.MongoConfiguration;
using Homesofts.Currency.Service.parameters;
using Models = Homesofts.Currency.Service.models;
using Homesofts.Currency.Test.Component.fakerepository;
using Machine.Specifications;

namespace Homesofts.Currency.Test.Component
{
    [Subject("Create Currency")]
    public class when_create_currency_with_existing_code : behave_currency_created
    {
        It should_not_created = () =>
        {
            try
            {
                Models.Currency ccy = Service.Create(new CreateParameter
                {
                    Code = "IDR",
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
