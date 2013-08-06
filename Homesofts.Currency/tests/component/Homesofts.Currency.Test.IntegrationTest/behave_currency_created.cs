using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Homesofts.Currency.Service;
using Homesofts.MongoConfiguration;
using Homesofts.Currency.Repository;
using Homesofts.Currency.Service.parameters;
using Models = Homesofts.Currency.Service.models;

namespace Homesofts.Currency.Test.IntegrationTest
{
    public class behave_currency_created
    {
        protected static ICurrencyService Service;
        protected static ICurrencyRepository Repository;
        protected static string ccyId;

        Establish context = () =>
        {
            Repository = new CurrencyRepository(MongoConfig.Instance);
            Service = new CurrencyService(Repository);
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

        Cleanup clear_data_sample = () =>
        {
            Repository.Remove(ccyId);
        };
    }
}
