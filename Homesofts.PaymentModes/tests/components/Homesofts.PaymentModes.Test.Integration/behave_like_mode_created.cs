using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.PaymentModes.Service;
using Machine.Specifications;
using Homesofts.PaymentModes.Repository;
using Homesofts.MongoConfiguration;
using Homesofts.PaymentModes.Service.Models;

namespace Homesofts.PaymentModes.Test.Integration
{
    public class behave_like_mode_created
    {
        protected static IPaymentModeService Service;
        protected static IPaymentModeRepository Repository;
        protected static PaymentMode mode;

        Establish context = () =>
        {
            Repository = new PaymentModeRepository(MongoConfig.Instance);
            Service = new PaymentModeService(Repository);

            mode = Service.Create(new Service.Parameters.CreateParameter
            {
                Name = "VISA",
                OrganizationId = "denny@homesofts.com"
            });
        };

        Cleanup clear_data_sample = () =>
        {
            Repository.Remove(mode.Id);
        };
    }
}
