using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Homesofts.Units.Service;
using Homesofts.Units.Repository;
using Homesofts.MongoConfiguration;
using Homesofts.Units.Service.Models;

namespace Homesofts.Units.Test.Integration
{
    public class behave_like_unit_created
    {
        protected static IUnitService Service;
        protected static IUnitRepository Repository;
        protected static Unit unitCreated;

        Establish context = () =>
        {
            Repository = new UnitRepository(MongoConfig.Instance);
            Service = new UnitService(Repository);

            unitCreated = Service.Create(new Service.Parameters.CreateParameter
            {
                Code = "Pcs",
                Name = "Pieces",
                OrganizationId = "denny@homesofts.com"
            });
        };

        Cleanup clear_data_sample = () =>
        {
            Repository.Remove(unitCreated.Id);
        };
    }
}
