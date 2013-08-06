using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Homesofts.PaymentModes.Service;
using Homesofts.PaymentModes.Repository;
using Homesofts.MongoConfiguration;
using Homesofts.PaymentModes.Service.Models;

namespace Homesofts.PaymentModes.Test.Integration
{
    [Subject("Create Payment Mode")]
    public class when_create_payment_mode
    {
        static IPaymentModeService Service;
        static IPaymentModeRepository Repository;
        static PaymentMode mode;

        Establish context = () =>
        {
            Repository = new PaymentModeRepository(MongoConfig.Instance);
            Service = new PaymentModeService(Repository);
        };

        Because of = () =>
        {
            mode = Service.Create(new Service.Parameters.CreateParameter
            {
                Name = "VISA",
                OrganizationId = "denny@homesofts.com"
            });
        };

        It should_be_created = () =>
        {
            Repository.Exist("VISA", "denny@homesofts.com").ShouldBeTrue();
        };

        Cleanup clear_data = () =>
        {
            Repository.Remove(mode.Id);
        };
    }
}
