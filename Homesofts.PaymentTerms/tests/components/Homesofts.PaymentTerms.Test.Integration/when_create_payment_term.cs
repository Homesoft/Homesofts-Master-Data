using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Homesofts.PaymentTerms.Service;
using Homesofts.PaymentTerms.Repository;
using Homesofts.MongoConfiguration;
using Homesofts.PaymentTerms.Service.Models;

namespace Homesofts.PaymentTerms.Test.Integration
{
    [Subject("Create Payment Term")]
    public class when_create_payment_term
    {
        static IPaymentTermRepository Repository;
        static IPaymentTermService Service;
        static PaymentTerm term;

        Establish context = () =>
        {
            Repository = new PaymentTermRepository(MongoConfig.Instance);
            Service = new PaymentTermService(Repository);
        };

        Because of = () =>
        {
            term = Service.Create(new Service.Parameters.CreateParameter
            {
                OrganizationId = "denny@homesofts.com",
                Value = 15
            });
        };

        It should_be_created = () =>
        {
            Repository.Exist(15, "denny@homesofts.com").ShouldBeTrue();
        };

        It name_should_be_15_Hari = () =>
        {
            Repository.Get(term.Id).Name.ShouldEqual("15 Hari");
        };

        Cleanup clear_data = () =>
        {
            Repository.Remove(term.Id);
        };
    }
}
