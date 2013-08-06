using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Currency.Service;
using Models = Homesofts.Currency.Service.models;
using Homesofts.Currency.Service.parameters;
using Machine.Specifications;
using Homesofts.Currency.Test.Component.fakerepository;

namespace Homesofts.Currency.Test.Component
{
    public class behave_currency_created
    {
        protected static ICurrencyService Service;
        protected static ICurrencyRepository Repository;
        protected static string ccyId;

        Establish context = () =>
        {
            Repository = new FakeCurrencyRepository();
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
    }
}
