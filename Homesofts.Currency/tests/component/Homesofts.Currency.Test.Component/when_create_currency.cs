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
    public class when_create_currency
    {
        static ICurrencyService Service;
        static ICurrencyRepository Repository;
        static string ccyId;

        Establish context = () =>
        {
            Repository = new FakeCurrencyRepository();
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

        It should_created = () =>
        {
            Models.Currency ccy = Repository.Get(ccyId);
            ccy.ShouldNotBeNull();
        };

        It code_should_be_IDR = () =>
        {
            Models.Currency ccy = Repository.Get(ccyId);
            ccy.Code.ShouldEqual("IDR");
        };

        It name_should_be_Rupiah = () =>
        {
            Models.Currency ccy = Repository.Get(ccyId);
            ccy.Name.ShouldEqual("Rupiah");
        };
    }
}
