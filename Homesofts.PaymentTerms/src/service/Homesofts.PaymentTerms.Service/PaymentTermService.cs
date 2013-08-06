using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homesofts.PaymentTerms.Service
{
    public class PaymentTermService : IPaymentTermService
    {
        IPaymentTermRepository repository;
        public PaymentTermService(IPaymentTermRepository repository)
        {
            this.repository = repository;
        }

        public Models.PaymentTerm Create(Parameters.CreateParameter param)
        {
            param.Validate();
            assertPaymentTermNotExist(param.Value, param.OrganizationId);
            Models.PaymentTerm term = param.ParseToPaymentTerm();
            repository.Insert(term);
            return term;
        }

        public void Update(Parameters.UpdateParameter param)
        {
            param.Validate();
            Models.PaymentTerm term = repository.Get(param.Id);
            if (term.Value != param.Value)
            {
                assertPaymentTermNotExist(param.Value, term.OrganizationId);
                term.Value = param.Value;
                term.Name = string.Format("{0} Hari", term.Value);
            }
            repository.Update(term);
        }

        public void Remove(string id)
        {
            repository.Remove(id);
        }

        private void assertPaymentTermNotExist(int value, string organizationId)
        {
            if (repository.Exist(value, organizationId))
                throw new Exception(string.Format("Jangka waktu {0} hari telah terdaftar", value));
        }
    }
}
