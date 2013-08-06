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
    public class behave_like_tax_created
    {
        protected static ITaxService Service;
        protected static ITaxRepository Repository;
        protected static Tax taxCreated;

        Establish context = () =>
        {
            Repository = new TaxRepository(MongoConfig.Instance);
            Service = new TaxService(Repository);

            taxCreated = Service.Create(new Service.Parameters.CreateParameter
            {
                Code = "PPN",
                Name = "Pajak Negara",
                Value = 10,
                Type = Taxes.Service.Enum.TaxType.Vat,
                OrganizationId = "denny@homesofts.com"
            });
        };

        Cleanup clear_data_sample = () =>
        {
            Repository.Remove(taxCreated.Id);
        };
    }
}
