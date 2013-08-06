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
    [Subject("Create Unit")]
    public class when_create_unit
    {
        static IUnitService Service;
        static IUnitRepository Repository;
        static Unit unit;

        Establish context = () =>
        {
            Repository = new UnitRepository(MongoConfig.Instance);
            Service = new UnitService(Repository);
        };

        Because of = () =>
        {
            unit = Service.Create(new Service.Parameters.CreateParameter
            {
                Code = "Pcs",
                Name = "Pieces",
                OrganizationId = "denny@homesofts.com"
            });
        };

        It should_be_created = () =>
        {
            Repository.Get(unit.Id).ShouldNotBeNull();
        };

        Cleanup clear_data = () =>
        {
            Repository.Remove(unit.Id);
        };
    }
}
