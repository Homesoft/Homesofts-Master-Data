using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Homesofts.Taxes.Service;
using Homesofts.Taxes.Repository;
using Homesofts.MongoConfiguration;
using Homesofts.Taxes.Service.Models;

namespace Homesofts.Taxes.Test.Integration
{
    [Subject("Create Tax")]
    public class when_create_tax_vat
    {
        static ITaxRepository Repository;
        static ITaxService Service;
        static Tax tax;

        Establish context = () =>
        {
            Repository = new TaxRepository(MongoConfig.Instance);
            Service = new TaxService(Repository);
        };

        Because of = () =>
        {
            tax = Service.Create(new Service.Parameters.CreateParameter
            {
                Code = "PPN",
                Name = "Pajak Negara",
                Value = 10,
                Type = Taxes.Service.Enum.TaxType.Vat,
                OrganizationId = "denny@homesofts.com"
            });
        };

        It should_be_created = () =>
        {
            Repository.Get(tax.Id).ShouldNotBeNull();
        };

        Cleanup clear_data = () =>
        {
            Repository.Remove(tax.Id);
        };
    }
}
