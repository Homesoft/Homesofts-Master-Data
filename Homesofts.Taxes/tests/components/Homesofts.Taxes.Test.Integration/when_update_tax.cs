using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace Homesofts.Taxes.Test.Integration
{
    [Subject("Update Tax")]
    public class when_update_tax : behave_like_tax_created
    {
        Because of = () =>
        {
            Service.Update(new Service.Parameters.UpdateParameter
            {
                Id = taxCreated.Id,
                Code = "PPN",
                Type = Taxes.Service.Enum.TaxType.Vat,
                Name = "Pajak Penghasilan Negara",
                Value = 9
            });
        };

        It name_should_be_Pajak_Penghasilan_Negara = () =>
        {
            Repository.Get(taxCreated.Id).Name.ShouldEqual("Pajak Penghasilan Negara");
        };

        It value_should_be_9 = () =>
        {
            Repository.Get(taxCreated.Id).Value.ShouldEqual(9);
        };
    }
}
