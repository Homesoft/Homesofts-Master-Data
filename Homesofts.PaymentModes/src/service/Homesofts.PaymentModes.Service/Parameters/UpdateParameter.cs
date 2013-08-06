using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Extension;

namespace Homesofts.PaymentModes.Service.Parameters
{
    public class UpdateParameter
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public void Validate()
        {
            if (this.Name.IsNullOrWhiteSpace())
                throw new Exception("Nama Jenis Pembayaran harus diisi.");
        }
    }
}
