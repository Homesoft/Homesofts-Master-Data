using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Extension;

namespace Homesofts.PaymentTerms.Service.Parameters
{
    public class UpdateParameter
    {
        public string Id { get; set; }
        public int Value { get; set; }

        public void Validate()
        {
            if (Value.IsNull())
                throw new Exception("Jangka waktu termin pembayaran harus diisi");
            if (Value < 1)
                throw new Exception("Jangka waktu termin pembayaran minimal 1 hari");
        }
    }
}
