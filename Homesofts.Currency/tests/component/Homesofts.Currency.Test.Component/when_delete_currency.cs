using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Models = Homesofts.Currency.Service.models;

namespace Homesofts.Currency.Test.Component
{
    [Subject("Delete Currency")]
    public class when_delete_currency : behave_currency_created
    {
        Because of = () =>
        {
            Service.Remove(ccyId);
        };

        It should_be_deleted = () =>
        {
            Repository.Get(ccyId).ShouldBeNull();
        };
    }
}
