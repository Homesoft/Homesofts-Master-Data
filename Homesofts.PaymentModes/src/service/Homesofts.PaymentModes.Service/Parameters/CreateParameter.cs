using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Extension;

namespace Homesofts.PaymentModes.Service.Parameters
{
    public class CreateParameter
    {
        public string Name { get; set; }
        public string OrganizationId { get; set; }

        public void Validate()
        {
            if (this.Name.IsNullOrWhiteSpace())
                throw new Exception("Nama Jenis Pembayaran harus diisi.");
            if (this.OrganizationId.IsNullOrWhiteSpace())
                throw new Exception("Id Organisasi harus diisi.");
        }

        public Models.PaymentMode ParseToPaymentMode()
        {
            Models.PaymentMode mode = new Models.PaymentMode
            {
                Id = Guid.NewGuid().ToString(),
                Name = this.Name,
                OrganizationId = this.OrganizationId
            };
            return mode;
        }
    }
}
