using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Homesofts.Currency.Service;
using Homesofts.Currency.Repository;
using Homesofts.MongoConfiguration;
using Models = Homesofts.Currency.Service.models;
using Homesofts.Currency.Service.parameters;

namespace Homesofts.Currency.Test.IntegrationTest
{
    [Subject("Create Currency")]
    public class when_create_currency
    {
        static ICurrencyService Service;
        static ICurrencyRepository Repository;
        static string ccyId;

        Establish context = () =>
        {
            Repository = new CurrencyRepository(MongoConfig.Instance);
            Service = new CurrencyService(Repository);
        };

        Because of = () =>
        {
            Models.Currency ccy = Service.Create(new CreateParameter
            {
                Code = "IDR",
                Name = "Rupiah",
                Rounding = 2,
                Symbol = "Rp",
                OrganizationId = "denny@homesofts.com"
            });
            ccyId = ccy.Id;
        };

        It should_be_created = () =>
        {
            Repository.Exist("IDR", "denny@homesofts.com").ShouldNotBeNull();
        };

        Cleanup clear_data = () =>
        {
            Repository.Remove(ccyId);
        };
    }
}
