using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Extension;

namespace Homesofts.PaymentTerms.Service.Parameters
{
    public class CreateParameter
    {
        public int Value { get; set; }
        public string OrganizationId { get; set; }

        public void Validate()
        {
            if (Value.IsNull())
                throw new Exception("Jangka waktu termin pembayaran harus diisi");
            if (Value < 1)
                throw new Exception("Jangka waktu termin pembayaran minimal 1 hari");
            if (OrganizationId.IsNullOrWhiteSpace())
                throw new Exception("Id Perusahaan harus diisi");
        }

        public Models.PaymentTerm ParseToPaymentTerm()
        {
            Models.PaymentTerm term = new Models.PaymentTerm
            {
                Id = Guid.NewGuid().ToString(),
                Name = string.Format("{0} Hari", this.Value),
                Value = this.Value,
                OrganizationId = this.OrganizationId
            };
            return term;
        }
    }
}
