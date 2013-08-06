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
    public class behave_like_payment_term_created
    {
        protected static IPaymentTermService Service;
        protected static IPaymentTermRepository Repository;
        protected static PaymentTerm term;

        Establish context = () =>
        {
            Repository = new PaymentTermRepository(MongoConfig.Instance);
            Service = new PaymentTermService(Repository);

            term = Service.Create(new Service.Parameters.CreateParameter
            {
                OrganizationId = "denny@homesofts.com",
                Value = 15
            });
        };

        Cleanup clear_data_sample = () =>
        {
            Repository.Remove(term.Id);
        };
    }
}
