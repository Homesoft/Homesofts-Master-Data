using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Extension;

namespace Homesofts.Taxes.Service
{
    public class TaxService : ITaxService
    {
        private ITaxRepository repository;

        public TaxService(ITaxRepository repository)
        {
            this.repository = repository;
        }

        public Models.Tax Create(Parameters.CreateParameter param)
        {
            param.Validate();
            assertTaxNotExist(param.Code, param.OrganizationId);
            Models.Tax tax = param.ParseToTax();
            repository.Insert(tax);
            return tax;
        }

        public void Update(Parameters.UpdateParameter param)
        {
            param.Validate();
            Models.Tax tax = repository.Get(param.Id);
            if (tax.IsNull())
                throw new Exception("Pajak tidak di temukan");
            if (tax.Code.NotEquals(param.Code))
            {
                assertTaxNotExist(param.Code, tax.OrganizationId);
                tax.Code = param.Code;
            }
            if (tax.Name.NotEquals(param.Name))
                tax.Name = param.Name;
            if (tax.Value != param.Value)
                tax.Value = param.Value;
            if (tax.Type != param.Type)
                tax.Type = param.Type;

            repository.Update(tax);
        }

        public void Remove(string id)
        {
            repository.Remove(id);   
        }

        private void assertTaxNotExist(string code, string organizationId)
        {
            if (repository.Exist(code, organizationId))
                throw new Exception(string.Format("Kode pajak {0}, sudah terdaftar", code));
        }
    }
}
